import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:mobile/database/database_manager.dart';
import 'package:mobile/database/flight_route.dart';
import 'package:dropdown_search/dropdown_search.dart';
import 'package:mobile/database/user.dart';

class Flights extends StatefulWidget {
  final User activeUser;

  const Flights({Key? key, required this.activeUser}) : super(key: key);

  @override
  _FlightsState createState() => _FlightsState();
}

class _FlightsState extends State<Flights> {
  final textController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            backgroundColor: const Color.fromARGB(193, 38, 240, 172),
            title: Text(widget.activeUser.email == ""
                ? "Offline Mode"
                : widget.activeUser.email)),
        body: AnnotatedRegion<SystemUiOverlayStyle>(
            value: SystemUiOverlayStyle.light,
            child: Stack(children: <Widget>[
              Container(
                  height: double.infinity,
                  width: double.infinity,
                  padding: const EdgeInsets.fromLTRB(30, 0, 30, 30),
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
                        const SizedBox(height: 30),
                        FutureBuilder<List<FlightRoute>>(
                            future: DatabaseManager.instance.getRoutes(),
                            builder: (BuildContext context,
                                AsyncSnapshot<List<FlightRoute>> snapshot) {
                              if (!snapshot.hasData) {
                                return const Center(child: Text("Loading..."));
                              }
                              return Column(
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: <Widget>[
                                    DropdownSearch<String>(
                                      mode: Mode.DIALOG,
                                      showSelectedItems: true,
                                      showSearchBox: true,
                                      items: snapshot.data!
                                          .map((e) => e.toMap()['departure'])
                                          .toList()
                                          .cast<String>(),
                                      onChanged: print,
                                      selectedItem: "Costa Rica",
                                      dropdownSearchDecoration:
                                          const InputDecoration(
                                              labelText: "Origin Airport"),
                                    ),
                                    DropdownSearch<String>(
                                      mode: Mode.DIALOG,
                                      showSelectedItems: true,
                                      showSearchBox: true,
                                      items: snapshot.data!
                                          .map((e) => e.toMap()['arrival'])
                                          .toList()
                                          .cast<String>(),
                                      onChanged: print,
                                      selectedItem: "Mexico",
                                      dropdownSearchDecoration:
                                          const InputDecoration(
                                              labelText: "Destination Airport"),
                                    )
                                  ]);
                            }),
                        const SizedBox(height: 40),
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
                                        fontWeight: FontWeight.bold))))
                      ])))
            ])));
  }
}
