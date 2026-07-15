import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../../dio_provider.dart';
import '../../../../shared/domain/api_response.dart';

part 'locations_api.g.dart';

class LocationsApi {
  final Dio _dio;

  LocationsApi(this._dio);

  Future<List<dynamic>> getLocationData() async {
    final response = await _dio.get('/api/location');
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success) {
      return apiResponse.data!;
    }
    throw Exception(apiResponse.errors.join(', '));
  }
}

@riverpod
LocationsApi locationsApi(Ref ref) {
  return LocationsApi(ref.watch(dioProvider));
}
