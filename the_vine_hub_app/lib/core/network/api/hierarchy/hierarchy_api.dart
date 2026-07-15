import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:jm_ministry_app/core/network/dio_provider.dart';
import 'package:jm_ministry_app/shared/domain/api_response.dart';

part 'hierarchy_api.g.dart';

class HierarchyApi {
  final Dio _dio;

  HierarchyApi(this._dio);

  Future<bool> isLeaderInHierarchy(String discipleId) async {
    final response = await _dio.get('/api/users/$discipleId/is-leader');
    final apiResponse = ApiResponse<bool>.fromJson(
      response.data,
      (json) => json as bool,
    );

    if (apiResponse.success) {
      return apiResponse.data!;
    }
    throw Exception(apiResponse.errors.join(', '));
  }
}

@riverpod
HierarchyApi hierarchyApi(Ref ref) {
  return HierarchyApi(ref.watch(dioProvider));
}
