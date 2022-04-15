import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:http/http.dart';
import 'dart:convert';

class Register extends StatefulWidget {
  const Register({Key? key}) : super(key: key);

  @override
  _RegisterState createState() => _RegisterState();
}

class _RegisterState extends State<Register> {
  bool _registrationSuccess = false;
  bool _obscurePassword = true;
  bool _isStudent = false;
  String accessToken = "";
  String errorMessage = "";
  final userName = TextEditingController();
  final userLastName1 = TextEditingController();
  final userLastName2 = TextEditingController();
  final userSsn = TextEditingController();
  final userPhone = TextEditingController();
  final userSchoolId = TextEditingController();
  final userCollege = TextEditingController();
  final userEmail = TextEditingController();
  final userPassword = TextEditingController();

  @override
  void dispose() {
    // Clean up the controller when the widget is disposed.
    userName.dispose();
    userLastName1.dispose();
    userLastName2.dispose();
    userSsn.dispose();
    userPhone.dispose();
    userSchoolId.dispose();
    userCollege.dispose();
    userEmail.dispose();
    userPassword.dispose();
    super.dispose();
  }

  void registerPost() async {
    _registrationSuccess = false;
    if (userEmail.text.isEmpty ||
        userPassword.text.isEmpty ||
        userName.text.isEmpty ||
        userLastName1.text.isEmpty ||
        userLastName2.text.isEmpty ||
        userSsn.text.isEmpty ||
        userPhone.text.isEmpty) {
      setState(() {
        errorMessage = "Empty field.";
      });
      return;
    }
    if (_isStudent && (userSchoolId.text.isEmpty || userCollege.text.isEmpty)) {
      setState(() {
        errorMessage = "Empty field.";
      });
      return;
    }
    try {
      final response = await post(
          Uri.parse("http://192.168.1.7:5001/Authentication/register"),
          headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
          },
          body: jsonEncode({
            "email": userEmail.text,
            "password": userPassword.text,
            "firstName": userName.text,
            "lastName1": userLastName1.text,
            "lastName2": userLastName2.text,
            "ssn": userSsn.text,
            "phoneNumber": userPhone.text,
            "schoolId": _isStudent ? userSchoolId.text : null,
            "university": _isStudent ? userCollege.text : null
          }));
      final jsonBody = jsonDecode(response.body);
      if (jsonBody['success'] == true) {
        setState(() {
          errorMessage = "Account created!\nTry logging in again.";
          _registrationSuccess = true;
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
                        const SizedBox(height: 25),
                        const Text('Register',
                            style: TextStyle(
                                color: Color.fromARGB(255, 0, 115, 161),
                                fontSize: 40,
                                fontWeight: FontWeight.bold)),
                        const SizedBox(height: 25),
                        TextFormField(
                            controller: userName,
                            keyboardType: TextInputType.name,
                            decoration: const InputDecoration(
                                labelText: "Name",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.person))),
                        const SizedBox(height: 25),
                        TextFormField(
                            controller: userLastName1,
                            keyboardType: TextInputType.name,
                            decoration: const InputDecoration(
                                labelText: "Last Name",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.person))),
                        const SizedBox(height: 25),
                        TextFormField(
                            controller: userLastName2,
                            keyboardType: TextInputType.name,
                            decoration: const InputDecoration(
                                labelText: "Second Last Name",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.person))),
                        const SizedBox(height: 25),
                        TextFormField(
                            controller: userSsn,
                            keyboardType: TextInputType.text,
                            decoration: const InputDecoration(
                                labelText: "Ssn",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.health_and_safety))),
                        const SizedBox(height: 25),
                        TextFormField(
                            controller: userEmail,
                            keyboardType: TextInputType.emailAddress,
                            decoration: const InputDecoration(
                                labelText: "Email",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.email))),
                        const SizedBox(height: 25),
                        TextFormField(
                            controller: userPhone,
                            keyboardType: TextInputType.phone,
                            decoration: const InputDecoration(
                                labelText: "Phone Number",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.phone))),
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
                        const SizedBox(height: 25),
                        Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              const Text('I\'m a student',
                                  style: TextStyle(
                                      fontSize: 16,
                                      color: Color.fromARGB(255, 99, 99, 99))),
                              Checkbox(
                                  value: _isStudent,
                                  onChanged: (value) {
                                    setState(() {
                                      _isStudent = value!;
                                    });
                                  }),
                            ]),
                        const SizedBox(height: 25),
                        if (_isStudent)
                          TextFormField(
                              controller: userCollege,
                              keyboardType: TextInputType.text,
                              decoration: const InputDecoration(
                                  labelText: "College",
                                  border: OutlineInputBorder(),
                                  prefixIcon: Icon(Icons.school))),
                        const SizedBox(height: 25),
                        if (_isStudent)
                          TextFormField(
                              controller: userSchoolId,
                              keyboardType: TextInputType.text,
                              decoration: const InputDecoration(
                                  labelText: "School Card Number",
                                  border: OutlineInputBorder(),
                                  prefixIcon: Icon(Icons.credit_card))),
                        const SizedBox(height: 25),
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
                                  registerPost();
                                },
                                child: const Text('CREATE ACCOUNT',
                                    style: TextStyle(
                                        fontSize: 25,
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold)))),
                        const SizedBox(height: 12),
                        Text(errorMessage,
                            style: TextStyle(
                                color: _registrationSuccess
                                    ? const Color.fromARGB(207, 0, 177, 0)
                                    : const Color.fromARGB(207, 255, 73, 73),
                                fontSize: 14)),
                        const SizedBox(height: 25),
                        const Divider(
                          height: 30,
                          color: Colors.grey,
                        ),
                        TextButton(
                            onPressed: () {
                              Navigator.pop(context);
                            },
                            child: const Text('Back to Login'))
                      ])))
            ])));
  }
}
