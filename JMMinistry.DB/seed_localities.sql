-- Update existing localities to link them to Bogotá
UPDATE "Locality"
SET "CityId" = c."Id"
FROM "Cities" c
WHERE c."Name" = 'Bogotá';

-- Insert missing localities linked to Bogotá
INSERT INTO "Locality" ("Name", "CityId")
SELECT loc.name, c."Id"
FROM (VALUES
    ('Fontibón'),
    ('Bosa'),
    ('Ciudad Bolívar'),
    ('Kennedy'),
    ('Rafael Uribe Uribe'),
    ('Tunjuelito'),
    ('Puente Aranda'),
    ('Teusaquillo'),
    ('Engativá'),
    ('Barrios Unidos'),
    ('Antonio Nariño'),
    ('San Cristóbal'),
    ('Sumapaz'),
    ('Usme'),
    ('Los Mártires'),
    ('Chapinero'),
    ('Suba'),
    ('Usaquén'),
    ('Santa Fe'),
    ('La Candelaria')
) AS loc(name)
CROSS JOIN "Cities" c
WHERE c."Name" = 'Bogotá'
  AND NOT EXISTS (
    SELECT 1 FROM "Locality" l WHERE l."Name" = loc.name
  );
