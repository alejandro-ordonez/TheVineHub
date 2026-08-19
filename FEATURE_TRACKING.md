# Project Feature Tracking

This document tracks the implementation status of features across the .NET Backend and Flutter Frontend.

## Summary

*   **Backend**: Mostly complete. Provides comprehensive REST endpoints for most features using a CQRS (Mediator) architecture.
*   **Frontend**: In progress. Many core features have API clients created, but some specific endpoints and the matching UI components are still pending.

---

## 1. Cells (Ministry)

| Action / Description | Backend Endpoint | Backend Status | Frontend API Client | Frontend UI Status |
| :--- | :--- | :--- | :--- | :--- |
| **Get All Cells** | `GET /api/ministry` | ✅ Implemented | ✅ Implemented (`getCells`) | ✅ UI exists (`cells_screen.dart`) |
| **Get Cell Details** | `GET /api/ministry/{cellId}` | ✅ Implemented | ✅ Implemented (`getCell`) | ✅ UI exists (`cell_details_screen.dart`) |
| **Create/Update Cell** | `POST /api/cells` | ✅ Implemented | ✅ Implemented (`upsertCell`) | ⏳ Pending |
| **Get Disciples in Cell** | `GET /api/ministry/disciples/{cellId}` | ✅ Implemented | ✅ Implemented (`getDisciples`) | ✅ Partially integrated in Cell Details |
| **Add Disciples** | `POST /api/ministry/disciples/{cellId}` | ✅ Implemented | ✅ Implemented (`addDisciples`) | ⏳ Pending |
| **Remove Disciple** | `DELETE /api/ministry/disciples/{cellId}/{discipleId}` | ✅ Implemented | ✅ Implemented (`removeDisciple`) | ⏳ Pending |
| **Get Cell Attendances** | `GET /api/ministry/attendances/{cellId}` | ✅ Implemented | ✅ Implemented (`getCellAttendances`) | ⏳ Pending / Needs integration |
| **Record Attendance** | `POST /api/ministry/attendances/{cellId}` | ✅ Implemented | ✅ Implemented (`recordAttendance`) | ⏳ Pending |
| **Update Attendance** | `PUT /api/ministry/attendances/{cellId}/{attendanceId}` | ✅ Implemented | ✅ Implemented (`updateAttendance`) | ⏳ Pending |

## 2. Discipleship (Notes & Mentorship)

| Action / Description | Backend Endpoint | Backend Status | Frontend API Client | Frontend UI Status |
| :--- | :--- | :--- | :--- | :--- |
| **Get Notes** | `GET /api/discipleship/{discipleId}/notes` | ✅ Implemented | ✅ Implemented (`getDiscipleshipNotes`) | ✅ UI exists (`disciple_profile_screen.dart`) |
| **Get Note By Id** | `GET /api/discipleship/{discipleId}/notes/{noteId}` | ✅ Implemented | ✅ Implemented (`getDiscipleshipNoteById`) | ⏳ Pending |
| **Create Note** | `POST /api/discipleship/{discipleId}/notes` | ✅ Implemented | ✅ Implemented (`createNote`) | ⏳ Pending |
| **Get Note Entries** | `GET /api/discipleship/{discipleId}/notes/{noteId}/entries` | ✅ Implemented | ✅ Implemented (`getNoteEntries`) | ⏳ Pending |
| **Create Note Entry** | `POST /api/discipleship/{discipleId}/notes/{noteId}/entries` | ✅ Implemented | ✅ Implemented (`createNoteEntry`) | ⏳ Pending |

## 3. Disciple Journey (Training / Equipping)

| Action / Description | Backend Endpoint | Backend Status | Frontend API Client | Frontend UI Status |
| :--- | :--- | :--- | :--- | :--- |
| **Get Steps** | `GET /api/disciplejourney/steps` | ✅ Implemented | ✅ Implemented (`getSteps`) | ✅ UI exists (`training_screen.dart`) |
| **Create Step** | `POST /api/disciplejourney/steps` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Update Step** | `PUT /api/disciplejourney/steps/{stepId}` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Delete Step** | `DELETE /api/disciplejourney/steps/{stepId}` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Step Eligible Disciples** | `GET /api/disciplejourney/steps/{stepId}/eligible-disciples` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Step Disciples** | `GET /api/disciplejourney/steps/{stepId}/disciples` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Complete Step** | `POST /api/disciplejourney/steps/{stepId}/completions` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Update Completion** | `PUT /api/disciplejourney/steps/{stepId}/completions/{discipleId}` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Cycles** | `GET /api/disciplejourney/steps/{stepId}/cycles` | ✅ Implemented | ✅ Implemented (`getCycles`) | ⏳ Pending |
| **Get Active Cycles** | `GET /api/disciplejourney/steps/{stepId}/cycles/active` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Create Cycle** | `POST /api/disciplejourney/steps/{stepId}/cycles` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Update Cycle** | `PUT /api/disciplejourney/steps/{stepId}/cycles/{cycleId}` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Delete Cycle** | `DELETE /api/disciplejourney/steps/{stepId}/cycles/{cycleId}` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Cycle Details** | `GET /api/disciplejourney/cycles/{cycleId}/details` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Enrollments** | `GET /api/disciplejourney/cycles/{cycleId}/enrollments` | ✅ Implemented | ✅ Implemented (`getEnrollments`) | ⏳ Pending |
| **Enroll Disciples** | `POST /api/disciplejourney/cycles/{cycleId}/enrollments` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Update Enrollment Status** | `PUT /api/disciplejourney/cycles/{cycleId}/enrollments/{enrollmentId}/status`| ✅ Implemented | ❌ Missing | ❌ Missing |
| **Assign Guide** | `PUT /api/disciplejourney/cycles/{cycleId}/enrollments/assign-guide` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Sessions** | `GET /api/disciplejourney/cycles/{cycleId}/sessions` | ✅ Implemented | ✅ Implemented (`getSessions`) | ⏳ Pending |
| **Create Session** | `POST /api/disciplejourney/cycles/{cycleId}/sessions` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Delete Session** | `DELETE /api/disciplejourney/cycles/{cycleId}/sessions/{sessionId}` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Staff** | `GET /api/disciplejourney/cycles/{cycleId}/staff` | ✅ Implemented | ✅ Implemented (`getStaff`) | ⏳ Pending |
| **Create Staff** | `POST /api/disciplejourney/cycles/{cycleId}/staff` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Delete Staff** | `DELETE /api/disciplejourney/cycles/{cycleId}/staff/{staffId}` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Get Cycle Attendance** | `GET /api/disciplejourney/cycles/{cycleId}/attendance` | ✅ Implemented | ❌ Missing | ⏳ UI exists (`attendance_screen.dart`), client missing |
| **Record Attendance** | `POST /api/disciplejourney/cycles/{cycleId}/sessions/{sessionId}/attendance` | ✅ Implemented | ✅ Implemented (`recordAttendance`) | ⏳ Pending |

## 4. Users & Authentication

| Action / Description | Backend Endpoint | Backend Status | Frontend API Client | Frontend UI Status |
| :--- | :--- | :--- | :--- | :--- |
| **Authenticate** | `POST /api/users/auth` | ✅ Implemented | ✅ Implemented (`authenticate`) | ✅ UI exists (`login_screen.dart`) |
| **Refresh Token** | `POST /api/users/refresh` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Create User** | `POST /api/users/register` | ✅ Implemented | ✅ Implemented (`createUser`) | ⏳ Pending |
| **Update User** | `PUT /api/users` | ✅ Implemented | ✅ Implemented (`updateUser`) | ⏳ Pending |
| **Get User Info** | `GET /api/users/{document?}` | ✅ Implemented | ✅ Implemented (`getUserInfo`) | ⏳ Pending |
| **Check Document** | `GET /api/users/check/{document}` | ✅ Implemented | ✅ Implemented (`checkDocument`) | ⏳ Pending |
| **Search User** | `POST /api/users/search` | ✅ Implemented | ✅ Implemented (`getUserInfoByCriteria`) | ⏳ Pending |
| **Import Users** | `POST /api/users/import` | ✅ Implemented | ✅ Implemented (`importUsers`) | ⏳ Pending |
| **Upload Photo** | `POST /api/users/{document}/photo` | ✅ Implemented | ✅ Implemented (`uploadPhoto`) | ⏳ Pending |
| **Delete Photo** | `DELETE /api/users/{document}/photo` | ✅ Implemented | ❌ Missing | ❌ Missing |
| **Marry Leaders** | `POST /api/users/marry` | ✅ Implemented | ✅ Implemented (`marryLeaders`) | ⏳ Pending |

## 5. Meetings

| Action / Description | Backend Endpoint | Backend Status | Frontend API Client | Frontend UI Status |
| :--- | :--- | :--- | :--- | :--- |
| **Get Meetings** | `GET /api/meetings` | ✅ Implemented | ✅ Implemented (`getMeetings`) | ✅ UI exists (`meetings_admin_screen.dart`) |
| **Create Meeting** | `POST /api/meetings` | ✅ Implemented | ✅ Implemented (`createMeeting`) | ⏳ Pending |
| **Update Meeting** | `PUT /api/Meetings/{id}` | ✅ Implemented | ✅ Implemented (`updateMeeting`) | ⏳ Pending |
| **Delete Meeting** | `DELETE /api/Meetings/{id}` | ✅ Implemented | ✅ Implemented (`deleteMeeting`) | ⏳ Pending |

## 6. Locations

| Action / Description | Backend Endpoint | Backend Status | Frontend API Client | Frontend UI Status |
| :--- | :--- | :--- | :--- | :--- |
| **Get Location Data** | `GET /api/location` | ✅ Implemented | ✅ Implemented (`getLocationData`) | ⏳ Pending |

## 7. Hierarchy

| Action / Description | Backend Endpoint | Backend Status | Frontend API Client | Frontend UI Status |
| :--- | :--- | :--- | :--- | :--- |
| **Check If Leader** | `GET /api/users/{discipleId}/is-leader` | ✅ Implemented | ✅ Implemented (`isLeaderInHierarchy`) | ⏳ Pending |
