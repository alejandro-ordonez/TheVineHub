-- 0005_initial_seeds.surql
INSERT INTO role [
    { id: role:Admin, name: 'Admin', description: 'Full system access' },
    { id: role:Leader, name: 'Leader', description: 'Cell group leader' },
    { id: role:Guide, name: 'Guide', description: 'Disciple journey teacher/coordinator' },
    { id: role:Disciple, name: 'Disciple', description: 'Standard user' }
] ON DUPLICATE KEY UPDATE name = $input.name, description = $input.description;

LET $defaultDoc = '123456789';
LET $admin_id = type::record('user', $defaultDoc);
LET $existing = (SELECT * FROM $admin_id)[0];

IF $existing == NONE {
    CREATE $admin_id SET
        name = "Default",
        last_name = "Admin",
        email = "default.admin@jmministry.com",
        password = crypto::argon2::generate("Admin123!"),
        gender = "Other",
        marital_status = "Single",
        birthday = d'2000-01-01T00:00:00Z',
        phone = "0000000000",
        address = "Default System Address",
        neighborhood = "System",
        educational_level = "None",
        profession = "System",
        occupation = "System Admin",
        photo_path = "",
        last_access = time::now();

    RELATE $admin_id->member_of->role:Admin;
};

UPDATE city:bogota CONTENT {
    name: 'Bogotá'
};

UPDATE locality:fontibon CONTENT { name: 'Fontibón' };
UPDATE locality:bosa CONTENT { name: 'Bosa' };
UPDATE locality:ciudad_bolivar CONTENT { name: 'Ciudad Bolívar' };
UPDATE locality:kennedy CONTENT { name: 'Kennedy' };
UPDATE locality:rafael_uribe_uribe CONTENT { name: 'Rafael Uribe Uribe' };
UPDATE locality:tunjuelito CONTENT { name: 'Tunjuelito' };
UPDATE locality:puente_aranda CONTENT { name: 'Puente Aranda' };
UPDATE locality:teusaquillo CONTENT { name: 'Teusaquillo' };
UPDATE locality:engativa CONTENT { name: 'Engativá' };
UPDATE locality:barrios_unidos CONTENT { name: 'Barrios Unidos' };
UPDATE locality:antonio_narino CONTENT { name: 'Antonio Nariño' };
UPDATE locality:san_cristobal CONTENT { name: 'San Cristóbal' };
UPDATE locality:sumapaz CONTENT { name: 'Sumapaz' };
UPDATE locality:usme CONTENT { name: 'Usme' };
UPDATE locality:los_martires CONTENT { name: 'Los Mártires' };
UPDATE locality:chapinero CONTENT { name: 'Chapinero' };
UPDATE locality:suba CONTENT { name: 'Suba' };
UPDATE locality:usaquen CONTENT { name: 'Usaquén' };
UPDATE locality:santa_fe CONTENT { name: 'Santa Fe' };
UPDATE locality:la_candelaria CONTENT { name: 'La Candelaria' };

DELETE part_of WHERE out = city:bogota;

RELATE locality:fontibon->part_of->city:bogota;
RELATE locality:bosa->part_of->city:bogota;
RELATE locality:ciudad_bolivar->part_of->city:bogota;
RELATE locality:kennedy->part_of->city:bogota;
RELATE locality:rafael_uribe_uribe->part_of->city:bogota;
RELATE locality:tunjuelito->part_of->city:bogota;
RELATE locality:puente_aranda->part_of->city:bogota;
RELATE locality:teusaquillo->part_of->city:bogota;
RELATE locality:engativa->part_of->city:bogota;
RELATE locality:barrios_unidos->part_of->city:bogota;
RELATE locality:antonio_narino->part_of->city:bogota;
RELATE locality:san_cristobal->part_of->city:bogota;
RELATE locality:sumapaz->part_of->city:bogota;
RELATE locality:usme->part_of->city:bogota;
RELATE locality:los_martires->part_of->city:bogota;
RELATE locality:chapinero->part_of->city:bogota;
RELATE locality:suba->part_of->city:bogota;
RELATE locality:usaquen->part_of->city:bogota;
RELATE locality:santa_fe->part_of->city:bogota;
RELATE locality:la_candelaria->part_of->city:bogota;
