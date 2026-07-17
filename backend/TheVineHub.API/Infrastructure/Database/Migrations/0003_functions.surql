-- 0003_functions.surql

-- 1. Recursive Cell Management Check
DEFINE FUNCTION fn::can_manage_cell($requestor: record<user>, $cell: record<cell>) {
    -- Admin shortcut: Does the requestor have the 'Admin' role?
    IF fn::is_authorized($requestor, ['Admin']) { RETURN true };

    -- Direct leadership: Is the requestor in the list of leaders for this cell?
    IF ($cell<-leads<-user) CONTAINS $requestor { RETURN true };

    -- Recursive check: find parent cells of this cell
    -- (A parent cell is one where a leader of the current cell is a disciple)
    LET $parent_cells = $cell<-leads<-user->disciple_in->cell;

    FOR $parent_cell IN $parent_cells {
        IF fn::can_manage_cell($requestor, $parent_cell) {
            RETURN true;
        };
    };

    RETURN false;
};

-- 2. Disciple/Person Leadership Check
DEFINE FUNCTION fn::is_leader($requestor: record<user>, $target: record<user>) {
    IF $requestor == $target { RETURN true };

    -- Check if requestor can manage any cell where the target is a disciple
    LET $target_cells = $target->disciple_in->cell;

    FOR $target_cell IN $target_cells {
        IF fn::can_manage_cell($requestor, $target_cell) {
            RETURN true;
        };
    };

    RETURN false;
};

-- 3. Cell Viewing Check
DEFINE FUNCTION fn::can_view_cell_disciples($requestor: record<user>, $cell: record<cell>) {
    IF fn::can_manage_cell($requestor, $cell) { RETURN true };

    -- Members can see their peers
    RETURN ($cell<-disciple_in<-user) CONTAINS $requestor;
};

DEFINE FUNCTION fn::is_authorized($user: record<user>, $roles: array<string>) {
    RETURN count(SELECT * FROM $user->member_of->role WHERE name IN $roles) > 0;
};

DEFINE FUNCTION fn::marry_users($person: record<user>, $spouse: record<user>) {
    UPDATE $person SET spouse = $spouse, marital_status = 'Married';
    UPDATE $spouse SET spouse = $person, marital_status = 'Married';
};
