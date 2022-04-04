import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class Register extends StatefulWidget {
  const Register({Key? key}) : super(key: key);

  @override
  _RegisterState createState() => _RegisterState();
}

class _RegisterState extends State<Register> {
  bool _obscurePassword = true;
  bool _isStudent = false;

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
                            keyboardType: TextInputType.name,
                            decoration: const InputDecoration(
                                labelText: "Name",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.person))),
                        const SizedBox(height: 25),
                        TextFormField(
                            keyboardType: TextInputType.name,
                            decoration: const InputDecoration(
                                labelText: "Last Name",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.person))),
                        const SizedBox(height: 25),
                        TextFormField(
                            keyboardType: TextInputType.name,
                            decoration: const InputDecoration(
                                labelText: "Second Last Name",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.person))),
                        const SizedBox(height: 25),
                        TextFormField(
                            keyboardType: TextInputType.emailAddress,
                            decoration: const InputDecoration(
                                labelText: "Email",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.email))),
                        const SizedBox(height: 25),
                        TextFormField(
                            keyboardType: TextInputType.phone,
                            decoration: const InputDecoration(
                                labelText: "Phone Number",
                                border: OutlineInputBorder(),
                                prefixIcon: Icon(Icons.phone))),
                        const SizedBox(height: 25),
                        TextFormField(
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
                              keyboardType: TextInputType.text,
                              decoration: const InputDecoration(
                                  labelText: "College",
                                  border: OutlineInputBorder(),
                                  prefixIcon: Icon(Icons.school))),
                        const SizedBox(height: 25),
                        if (_isStudent)
                          TextFormField(
                              keyboardType: TextInputType.number,
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
                                onPressed: () {},
                                child: const Text('CREATE ACCOUNT',
                                    style: TextStyle(
                                        fontSize: 25,
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold)))),
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
