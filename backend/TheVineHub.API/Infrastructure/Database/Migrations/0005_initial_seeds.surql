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

INSERT INTO city [
    { id: city:bogota, name: 'Bogotá' }
] ON DUPLICATE KEY UPDATE name = $input.name;

INSERT INTO locality [
    { id: locality:fontibon, name: 'Fontibón' },
    { id: locality:bosa, name: 'Bosa' },
    { id: locality:ciudad_bolivar, name: 'Ciudad Bolívar' },
    { id: locality:kennedy, name: 'Kennedy' },
    { id: locality:rafael_uribe_uribe, name: 'Rafael Uribe Uribe' },
    { id: locality:tunjuelito, name: 'Tunjuelito' },
    { id: locality:puente_aranda, name: 'Puente Aranda' },
    { id: locality:teusaquillo, name: 'Teusaquillo' },
    { id: locality:engativa, name: 'Engativá' },
    { id: locality:barrios_unidos, name: 'Barrios Unidos' },
    { id: locality:antonio_narino, name: 'Antonio Nariño' },
    { id: locality:san_cristobal, name: 'San Cristóbal' },
    { id: locality:sumapaz, name: 'Sumapaz' },
    { id: locality:usme, name: 'Usme' },
    { id: locality:los_martires, name: 'Los Mártires' },
    { id: locality:chapinero, name: 'Chapinero' },
    { id: locality:suba, name: 'Suba' },
    { id: locality:usaquen, name: 'Usaquén' },
    { id: locality:santa_fe, name: 'Santa Fe' },
    { id: locality:la_candelaria, name: 'La Candelaria' }
] ON DUPLICATE KEY UPDATE name = $input.name;

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
