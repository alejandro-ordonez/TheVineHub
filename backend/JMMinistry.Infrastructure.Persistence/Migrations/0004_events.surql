-- 0004_events.surql
DEFINE EVENT auto_regular_role ON TABLE user WHEN $event == "CREATE" THEN {
    LET $user_id = $value.id;
    LET $role_id = (SELECT VALUE id FROM role WHERE name == "Regular")[0];
    IF $role_id != NONE {
        RELATE $user_id->member_of->$role_id;
    };
};

DEFINE EVENT spouse_leads_future_sync ON TABLE leads WHEN $event == "CREATE" THEN {
    LET $spouse_id = (SELECT VALUE spouse FROM user WHERE id = $value.in)[0];
    IF $spouse_id != NONE {
        LET $cell_id = $value.out;
        LET $since_date = $value.since;
        IF (SELECT id FROM leads WHERE in = $spouse_id AND out = $cell_id).len() == 0 {
            RELATE $spouse_id -> leads -> $cell_id SET since = $since_date;
        };
    };
};

DEFINE EVENT auto_guide_role ON TABLE guides WHEN $event == "CREATE" THEN {
    LET $user_id = $value.in;
    LET $role_id = (SELECT VALUE id FROM role WHERE name == "Guide")[0];
    IF $role_id != NONE {
        IF (SELECT id FROM member_of WHERE in == $user_id AND out == $role_id).len() == 0 {
            RELATE $user_id->member_of->$role_id;
        };
    };
};

DEFINE EVENT audit_user_update ON TABLE user WHEN $event == "UPDATE" THEN {
    LET $user_id = $value.id;
    UPDATE $user_id SET last_updated = time::now();
};

DEFINE EVENT cycle_enrollment_increment ON TABLE enrolled_to WHEN $event == "CREATE" THEN {
    LET $cycle_id = $value.out;
    UPDATE $cycle_id SET enrolled_count += 1;
};

DEFINE EVENT cycle_enrollment_decrement ON TABLE enrolled_to WHEN $event == "DELETE" THEN {
    LET $cycle_id = $before.out;
    UPDATE $cycle_id SET enrolled_count -= 1;
};
