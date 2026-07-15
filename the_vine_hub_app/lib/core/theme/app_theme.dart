import 'package:flutter/material.dart';

class AppTheme {
  // Light Theme Colors
  static const Color primaryColor = Color(0xFF1A237E); // Deep Navy
  static const Color secondaryColor = Color(0xFFFFD600); // Warm Gold
  static const Color backgroundColor = Color(0xFFF8F9FA);
  static const Color onSurfaceColor = Color(0xFF191C1D);

  // Dark Theme Colors
  static const Color primaryColorDark = Color(0xFFC5CAE9); // Desaturated Indigo
  static const Color backgroundColorDark = Color(0xFF1A1C1E); // Deep Navy Charcoal
  static const Color onSurfaceColorDark = Color(0xFFE2E2E6);

  static ThemeData get lightTheme {
    return ThemeData(
      useMaterial3: true,
      colorScheme: ColorScheme.fromSeed(
        seedColor: primaryColor,
        primary: primaryColor,
        secondary: secondaryColor,
        surface: backgroundColor,
        onSurface: onSurfaceColor,
        brightness: Brightness.light,
      ),
      textTheme: _textTheme,
      appBarTheme: const AppBarTheme(
        backgroundColor: primaryColor,
        foregroundColor: Colors.white,
        elevation: 0,
      ),
      navigationBarTheme: NavigationBarThemeData(
        backgroundColor: Colors.white,
        indicatorColor: secondaryColor.withValues(alpha: 0.2),
        iconTheme: WidgetStateProperty.resolveWith((states) {
          if (states.contains(WidgetState.selected)) {
            return const IconThemeData(color: primaryColor);
          }
          return const IconThemeData(color: Colors.grey);
        }),
      ),
    );
  }

  static ThemeData get darkTheme {
    return ThemeData(
      useMaterial3: true,
      colorScheme: ColorScheme.fromSeed(
        seedColor: primaryColor,
        primary: primaryColorDark,
        secondary: secondaryColor,
        surface: backgroundColorDark,
        onSurface: onSurfaceColorDark,
        brightness: Brightness.dark,
      ),
      textTheme: _textTheme.apply(
        bodyColor: onSurfaceColorDark,
        displayColor: onSurfaceColorDark,
      ),
      appBarTheme: const AppBarTheme(
        backgroundColor: backgroundColorDark,
        foregroundColor: onSurfaceColorDark,
        elevation: 0,
      ),
      navigationBarTheme: NavigationBarThemeData(
        backgroundColor: backgroundColorDark,
        indicatorColor: primaryColorDark.withValues(alpha: 0.2),
        iconTheme: WidgetStateProperty.resolveWith((states) {
          if (states.contains(WidgetState.selected)) {
            return const IconThemeData(color: primaryColorDark);
          }
          return const IconThemeData(color: Colors.grey);
        }),
      ),
    );
  }

  static const TextTheme _textTheme = TextTheme(
    displayLarge: TextStyle(
      fontFamily: 'Inter',
      fontWeight: FontWeight.w800,
      fontSize: 32,
      letterSpacing: -0.02,
    ),
    headlineMedium: TextStyle(
      fontFamily: 'Inter',
      fontWeight: FontWeight.w600,
      fontSize: 24,
      letterSpacing: -0.01,
    ),
    bodyLarge: TextStyle(
      fontFamily: 'Inter',
      fontWeight: FontWeight.w400,
      fontSize: 18,
    ),
    bodyMedium: TextStyle(
      fontFamily: 'Inter',
      fontWeight: FontWeight.w400,
      fontSize: 16,
    ),
    labelLarge: TextStyle(
      fontFamily: 'Inter',
      fontWeight: FontWeight.w500,
      fontSize: 14,
    ),
    labelSmall: TextStyle(
      fontFamily: 'Inter',
      fontWeight: FontWeight.w600,
      fontSize: 12,
    ),
  );
}
