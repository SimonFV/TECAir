import 'package:flutter/material.dart';
import 'package:device_preview/device_preview.dart';
import 'package:mobile/screens/login/login.dart';

void main() {
  runApp(
    DevicePreview(
      //enabled: !kReleaseMode,
      builder: (context) => const MyApp(), // Wrap your app
    ),
  );
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'TEC Air',
      useInheritedMediaQuery: true,
      locale: DevicePreview.locale(context),
      builder: DevicePreview.appBuilder,
      home: Login(),
    );
  }
}
