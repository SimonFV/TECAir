import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:mobile/database/database_manager.dart';
import 'package:mobile/database/dog.dart';

class Flights extends StatefulWidget {
  const Flights({Key? key}) : super(key: key);

  @override
  _FlightsState createState() => _FlightsState();
}

class _FlightsState extends State<Flights> {
  final textController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: AnnotatedRegion<SystemUiOverlayStyle>(
            value: SystemUiOverlayStyle.light,
            child: Stack(children: <Widget>[
              Container(
                  height: double.infinity,
                  width: double.infinity,
                  padding: const EdgeInsets.all(30),
                  decoration: const BoxDecoration(
                      gradient: LinearGradient(
                          begin: Alignment.topCenter,
                          end: Alignment.bottomCenter,
                          colors: [
                        Color.fromARGB(244, 192, 255, 224),
                        Color.fromARGB(170, 202, 240, 255),
                        Color.fromARGB(170, 202, 240, 255),
                        Color.fromARGB(170, 79, 155, 255),
                      ])),
                  child: SingleChildScrollView(
                      child: Column(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: <Widget>[
                        const SizedBox(height: 50),
                        const Text('Flights',
                            style: TextStyle(
                                color: Color.fromARGB(255, 0, 115, 161),
                                fontSize: 40,
                                fontWeight: FontWeight.bold)),
                        const SizedBox(height: 50),
                        TextFormField(
                            keyboardType: TextInputType.text,
                            decoration: const InputDecoration(
                                labelText: "Origin Airport",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.flight))),
                        const SizedBox(height: 25),
                        TextFormField(
                            keyboardType: TextInputType.text,
                            decoration: const InputDecoration(
                                labelText: "Destination Airport",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.flight))),
                        const SizedBox(height: 50),
                        Container(
                            height: 60,
                            width: double.infinity,
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(100),
                                gradient: const LinearGradient(colors: [
                                  Colors.blueAccent,
                                  Colors.greenAccent
                                ])),
                            child: MaterialButton(
                                onPressed: () {},
                                child: const Text('RESERVE',
                                    style: TextStyle(
                                        fontSize: 25,
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold)))),
                        const SizedBox(height: 50),
                        const Divider(
                          height: 30,
                          color: Colors.grey,
                        ),
                        TextButton(
                            onPressed: () {
                              Navigator.pop(context);
                            },
                            child: const Text('Sign out'))
                      ])))
            ])));
  }
}
