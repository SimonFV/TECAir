import 'package:sqflite/sqflite.dart';
import 'dart:io';
import 'package:path/path.dart';
import 'package:path_provider/path_provider.dart';
import 'package:mobile/database/dog.dart';

class DatabaseManager {
  DatabaseManager._privateConstructor();
  static final DatabaseManager instance = DatabaseManager._privateConstructor();

  static Database? _database;
  Future<Database> get database async => _database ?? await _initDatabase();

  Future<Database> _initDatabase() async {
    Directory documentsDirectory = await getApplicationDocumentsDirectory();
    String path = join(documentsDirectory.path, 'dogs.db');
    print(path);
    return await openDatabase(
      path,
      version: 1,
      onCreate: _onCreate,
    );
  }

  Future _onCreate(Database db, int version) async {
    await db.execute('''CREATE TABLE dogs(
        id INTEGER PRIMARY KEY, 
        name TEXT,
        age INTEGER
      )
    ''');
  }

  Future<List<Dog>> getDogs() async {
    Database db = await instance.database;
    var dogs = await db.query('dogs', orderBy: 'name');
    List<Dog> dogList =
        dogs.isEmpty ? [] : dogs.map((c) => Dog.fromMap(c)).toList();
    return dogList;
  }

  Future<int> addDog(Dog dog) async {
    Database db = await instance.database;
    return await db.insert('dogs', dog.toMap());
  }
}
