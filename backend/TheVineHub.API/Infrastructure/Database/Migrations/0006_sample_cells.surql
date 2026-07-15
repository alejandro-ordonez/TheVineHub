-- 0006_sample_cells.surql

-- 0. COMPREHENSIVE CLEANUP
DELETE disciple_in WHERE in INSIDE [user:john_doe, user:jane_smith, user:mike_ross, user:sarah_connor];
DELETE leads WHERE in INSIDE [user:john_doe, user:jane_smith, user:mike_ross, user:sarah_connor, user:`123456789`];
DELETE member_of WHERE in INSIDE [user:john_doe, user:jane_smith, user:mike_ross, user:sarah_connor];
DELETE located_in WHERE in INSIDE [cell:central, cell:north, cell:south, cell:east_daughter, cell:west_daughter];

DELETE cell WHERE id INSIDE [cell:central, cell:north, cell:south, cell:east_daughter, cell:west_daughter];
DELETE user WHERE id INSIDE [user:john_doe, user:jane_smith, user:mike_ross, user:sarah_connor];

-- 0.1 MANUALLY REBUILD INDEXES
-- This ensures the index is clean and synchronized before re-insertion
REBUILD INDEX unique_disciple ON TABLE disciple_in;
REBUILD INDEX unique_located_in ON TABLE located_in;

-- 1. Create Sample Users (Complete Profiles)
INSERT INTO user [
    {
        id: user:john_doe,
        name: "John",
        last_name: "Doe",
        email: "john.doe@example.com",
        phone: "3101234567",
        birthday: d'1990-05-15T00:00:00Z',
        gender: "Male",
        marital_status: "Married",
        photo_path: "https://i.pravatar.cc/150?u=john",
        educational_level: "University",
        profession: "Engineer",
        occupation: "Software Developer",
        address: "Calle 100 # 15-20",
        neighborhood: "Chico",
        last_access: time::now(),
        password: crypto::argon2::generate("Password123!")
    },
    {
        id: user:jane_smith,
        name: "Jane",
        last_name: "Smith",
        email: "jane.smith@example.com",
        phone: "3209876543",
        birthday: d'1995-08-20T00:00:00Z',
        gender: "Female",
        marital_status: "Single",
        photo_path: "https://i.pravatar.cc/150?u=jane",
        educational_level: "Master",
        profession: "Doctor",
        occupation: "Pediatrician",
        address: "Carrera 15 # 120-10",
        neighborhood: "Usaquen",
        last_access: time::now(),
        password: crypto::argon2::generate("Password123!")
    },
    {
        id: user:mike_ross,
        name: "Mike",
        last_name: "Ross",
        email: "mike.ross@example.com",
        phone: "3154445566",
        birthday: d'1992-03-10T00:00:00Z',
        gender: "Male",
        marital_status: "Single",
        photo_path: "https://i.pravatar.cc/150?u=mike",
        educational_level: "Bachelor",
        profession: "Lawyer",
        occupation: "Junior Associate",
        address: "Ave 68 # 45-30",
        neighborhood: "Salitre",
        last_access: time::now(),
        password: crypto::argon2::generate("Password123!")
    },
    {
        id: user:sarah_connor,
        name: "Sarah",
        last_name: "Connor",
        email: "sarah.connor@example.com",
        phone: "3007778899",
        birthday: d'1985-11-30T00:00:00Z',
        gender: "Female",
        marital_status: "Divorced",
        photo_path: "https://i.pravatar.cc/150?u=sarah",
        educational_level: "High School",
        profession: "Technician",
        occupation: "Security Consultant",
        address: "Calle 80 # 20-45",
        neighborhood: "Minuto de Dios",
        last_access: time::now(),
        password: crypto::argon2::generate("Password123!")
    }
];

-- 2. Create Sample Cells
INSERT INTO cell [
    {
        id: cell:central,
        name: "Cell Central",
        description: "Main cell led by Admin",
        main_cell: true,
        address: "Ave 26 # 45-12",
        day: "Wednesday",
        opening_date: d'2024-01-01T19:00:00Z'
    },
    {
        id: cell:north,
        name: "Cell North",
        description: "Northern cell led by Admin",
        main_cell: false,
        address: "Calle 140 # 15-30",
        day: "Friday",
        opening_date: d'2024-03-15T19:30:00Z'
    },
    {
        id: cell:south,
        name: "Cell South",
        description: "Southern cell led by Admin",
        main_cell: false,
        address: "Diagonal 45 Sur # 10-05",
        day: "Thursday",
        opening_date: d'2024-02-10T18:30:00Z'
    },
    {
        id: cell:east_daughter,
        name: "Cell East (Daughter)",
        description: "Daughter cell of Central, led by John Doe",
        main_cell: false,
        address: "Carrera 7 # 32-50",
        day: "Tuesday",
        opening_date: d'2024-05-20T19:00:00Z'
    },
    {
        id: cell:west_daughter,
        name: "Cell West (Daughter)",
        description: "Daughter cell of North, led by Jane Smith",
        main_cell: false,
        address: "Calle 80 # 70-15",
        day: "Saturday",
        opening_date: d'2024-04-05T17:00:00Z'
    }
];

-- 3. Locality Relations
RELATE cell:central->located_in->locality:teusaquillo;
RELATE cell:north->located_in->locality:usaquen;
RELATE cell:south->located_in->locality:usme;
RELATE cell:east_daughter->located_in->locality:chapinero;
RELATE cell:west_daughter->located_in->locality:engativa;

-- 4. Leadership Relations
LET $admin = user:`123456789`;
RELATE $admin->leads->cell:central SET since = d'2024-01-01T00:00:00Z';
RELATE $admin->leads->cell:north SET since = d'2024-03-15T00:00:00Z';
RELATE $admin->leads->cell:south SET since = d'2024-02-10T00:00:00Z';
RELATE user:john_doe->leads->cell:east_daughter SET since = d'2024-05-20T00:00:00Z';
RELATE user:jane_smith->leads->cell:west_daughter SET since = d'2024-04-05T00:00:00Z';

-- 5. Membership Relations
RELATE user:john_doe->disciple_in->cell:central SET since = d'2024-01-15T00:00:00Z';
RELATE user:mike_ross->disciple_in->cell:central SET since = d'2024-02-01T00:00:00Z';
RELATE user:jane_smith->disciple_in->cell:north SET since = d'2024-04-01T00:00:00Z';
RELATE user:sarah_connor->disciple_in->cell:east_daughter SET since = d'2024-06-01T00:00:00Z';

-- 6. Roles
RELATE user:john_doe->member_of->role:Leader;
RELATE user:jane_smith->member_of->role:Leader;
RELATE user:mike_ross->member_of->role:Disciple;
RELATE user:sarah_connor->member_of->role:Disciple;
