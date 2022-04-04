import 'package:flutter/material.dart';
import 'package:device_preview/device_preview.dart';
import 'package:mobile/database/database_manager.dart';
import 'package:mobile/screens/login/login.dart';
import 'package:flutter/widgets.dart';
import 'package:sqflite/sqflite.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  Database db = await DatabaseManager.instance.database;
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
