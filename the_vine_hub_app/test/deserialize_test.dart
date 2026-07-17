import 'package:flutter_test/flutter_test.dart';
import 'package:the_vine_hub_app/features/cells/domain/cell_dto.dart';
import 'package:the_vine_hub_app/features/cells/domain/disciple_dto.dart';

void main() {
  test('deserialize CellDto', () {
    final json = {
      "id": "north",
      "name": "Cell North",
      "description": "Northern cell led by Admin",
      "mainCell": false,
      "address": "Calle 140 # 15-30",
      "level": 1,
      "memberCount": 0,
      "day": 5,
      "openingDate": "2024-03-15",
      "leaders": [
        {"id": "123456789", "photoUrl": "", "fullName": "Default Admin"},
      ],
    };
    final dto = CellDto.fromJson(json);
    expect(dto.id, 'north');
  });

  test('deserialize DiscipleDto', () {
    final json = {
      "memberSince": "2024-04-01T00:00:00Z",
      "cellId": "north",
      "discipleStep": "",
      "id": "jane_smith",
      "fullName": "Jane Smith",
      "phone": "3209876543",
      "gender": 1,
      "photoPath": "https://i.pravatar.cc/150?u=jane",
    };
    final dto = DiscipleDto.fromJson(json);
    expect(dto.id, 'jane_smith');
  });
}
