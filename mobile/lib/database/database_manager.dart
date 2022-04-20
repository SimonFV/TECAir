import 'package:sqflite/sqflite.dart';
import 'dart:io';
import 'package:path/path.dart';
import 'package:path_provider/path_provider.dart';
import 'package:mobile/database/flight_route.dart';

class DatabaseManager {
  DatabaseManager._privateConstructor();
  static final DatabaseManager instance = DatabaseManager._privateConstructor();

  static Database? _database;
  Future<Database> get database async => _database ?? await _initDatabase();

  Future<Database> _initDatabase() async {
    Directory documentsDirectory = await getApplicationDocumentsDirectory();
    String path = join(documentsDirectory.path, 'mobileapp.db');
    return await openDatabase(
      path,
      version: 1,
      onCreate: _onCreate,
    );
  }

  Future _onCreate(Database db, int version) async {
    await db.execute('''CREATE TABLE flight(
        id INTEGER PRIMARY KEY,
        idRute INTEGER FOREIGN,
        airplaneLicense TEXT,
        gate TEXT,
        schedule TEXT,
        status TEXT,
        deals deals,
        FOREIGN (idRute) REFERENCES route(id),
        FOREIGN (airplaneLicense) REFERENCES plane(airplaneLicense))
    ''');
    await db.execute('''CREATE TABLE route(
        id INTEGER PRIMARY KEY, 
        departure TEXT,
        arrival TEXT,
        scale TEXT)
    ''');
    await db.execute('''CREATE TABLE airplane(
        airplaneLicense TEXT PRIMARY KEY, 
        capacity INTEGER)
    ''');
  }

  Future<List<FlightRoute>> getRoutes() async {
    Database db = await instance.database;
    var routes = await db.query('route', orderBy: 'id');
    List<FlightRoute> routeList = routes.isEmpty
        ? []
        : routes.map((c) => FlightRoute.fromMap(c)).toList();
    return routeList;
  }

  Future<int> addRoute(FlightRoute route) async {
    Database db = await instance.database;
    return await db.insert('route', route.toMap());
  }

  Future<bool> isTableEmpty() async {
    Database db = await instance.database;
    int? count =
        Sqflite.firstIntValue(await db.rawQuery('SELECT COUNT(*) FROM route'));
    return count == 0;
  }
}
