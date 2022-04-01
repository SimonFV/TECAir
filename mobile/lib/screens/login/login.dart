import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class Login extends StatefulWidget {
  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
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
                        const Text('Sign In',
                            style: TextStyle(
                                color: Color.fromARGB(255, 0, 115, 161),
                                fontSize: 40,
                                fontWeight: FontWeight.bold)),
                        const SizedBox(height: 50),
                        TextFormField(
                            keyboardType: TextInputType.emailAddress,
                            decoration: const InputDecoration(
                                labelText: "Email",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.email))),
                        const SizedBox(height: 25),
                        TextFormField(
                            keyboardType: TextInputType.visiblePassword,
                            decoration: const InputDecoration(
                                labelText: "Password",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.lock),
                                suffixIcon: Icon(Icons.remove_red_eye))),
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
                                child: const Text('LOGIN',
                                    style: TextStyle(
                                        fontSize: 25,
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold)))),
                        const SizedBox(height: 50),
                        const Divider(
                          height: 30,
                          color: Colors.grey,
                        ),
                        Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              TextButton(
                                  onPressed: () {},
                                  child: const Text('Register Account'))
                            ])
                      ])))
            ])));
  }
}
