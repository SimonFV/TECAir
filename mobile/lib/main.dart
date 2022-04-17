import 'package:flutter/material.dart';
import 'package:device_preview/device_preview.dart';
import 'package:mobile/database/database_manager.dart';
import 'package:mobile/database/flight_route.dart';
import 'package:mobile/screens/login/login.dart';
import 'package:flutter/widgets.dart';
import 'package:sqflite/sqflite.dart';
import 'package:http/http.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  Database db = await DatabaseManager.instance.database;

  if (await DatabaseManager.instance.isTableEmpty()) {
    await DatabaseManager.instance.addRoute(
        FlightRoute(id: 1, departure: "Costa Rica", arrival: "USA", scale: 65));
    await DatabaseManager.instance.addRoute(
        FlightRoute(id: 2, departure: "USA", arrival: "Costa Rica", scale: 65));
    await DatabaseManager.instance.addRoute(FlightRoute(
        id: 3, departure: "Mexico", arrival: "Costa Rica", scale: 43));
    await DatabaseManager.instance.addRoute(FlightRoute(
        id: 4, departure: "Costa Rica", arrival: "Mexico", scale: 43));
  }

  //Run the interface
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // Root widget of application.
  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'TEC Air',
      debugShowCheckedModeBanner: false,
      home: Login(),
    );
  }
}
