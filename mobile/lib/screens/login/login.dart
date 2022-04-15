import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:mobile/screens/flights/flights.dart';
import 'package:mobile/screens/register/register.dart';
import 'package:http/http.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  bool _obscurePassword = true;
  String accessToken = "";
  String errorMessage = "";
  final userEmail = TextEditingController();
  final userPassword = TextEditingController();

  @override
  void dispose() {
    // Clean up the controller when the widget is disposed.
    userEmail.dispose();
    userPassword.dispose();
    super.dispose();
  }

  void loginPost() async {
    if (userEmail.text.isEmpty || userPassword.text.isEmpty) {
      setState(() {
        errorMessage = "Empty field.";
      });
      return;
    }
    try {
      final response = await post(
          Uri.parse("http://192.168.1.7:5001/Authentication/login"),
          headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
          },
          body: jsonEncode(
              {"email": userEmail.text, "password": userPassword.text}));
      final jsonBody = jsonDecode(response.body);
      if (jsonBody['success'] == true) {
        accessToken = jsonBody['token'];
        setState(() {
          errorMessage = "";
        });
      } else {
        setState(() {
          errorMessage = jsonBody['errors'][0];
        });
        return;
      }
    } catch (err) {
      setState(() {
        errorMessage = err.toString();
      });
      return;
    }

    Navigator.of(context).push(MaterialPageRoute(
        builder: (context) => Flights(accessToken: accessToken)));
  }

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
                        const Text('Sign In',
                            style: TextStyle(
                                color: Color.fromARGB(255, 0, 115, 161),
                                fontSize: 40,
                                fontWeight: FontWeight.bold)),
                        const SizedBox(height: 50),
                        TextFormField(
                            controller: userEmail,
                            keyboardType: TextInputType.emailAddress,
                            decoration: const InputDecoration(
                                labelText: "Email",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.email))),
                        const SizedBox(height: 25),
                        TextFormField(
                            controller: userPassword,
                            keyboardType: TextInputType.visiblePassword,
                            obscureText: _obscurePassword,
                            decoration: InputDecoration(
                                labelText: "Password",
                                border: const OutlineInputBorder(),
                                prefixIcon: const Icon(Icons.lock),
                                suffixIcon: IconButton(
                                  onPressed: () {
                                    setState(() {
                                      _obscurePassword = !_obscurePassword;
                                    });
                                  },
                                  icon: _obscurePassword
                                      ? const Icon(Icons.visibility)
                                      : const Icon(Icons.visibility_off),
                                ))),
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
                                onPressed: () {
                                  loginPost();
                                },
                                child: const Text('LOGIN',
                                    style: TextStyle(
                                        fontSize: 25,
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold)))),
                        const SizedBox(height: 50),
                        Text(errorMessage,
                            style: const TextStyle(
                                color: Color.fromARGB(207, 255, 73, 73),
                                fontSize: 14)),
                        const SizedBox(height: 50),
                        const Divider(
                          height: 30,
                          color: Colors.grey,
                        ),
                        TextButton(
                            onPressed: () {
                              Navigator.of(context).push(MaterialPageRoute(
                                  builder: (context) => const Register()));
                            },
                            child: const Text('Create New Account'))
                      ])))
            ])));
  }
}
