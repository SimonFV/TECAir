class User {
  String email;
  String password;
  String token;

  User({required this.email, required this.password, required this.token});

  factory User.fromMap(Map<String, dynamic> json) => User(
      email: json['email'], password: json['password'], token: json['token']);

  Map<String, dynamic> toMap() {
    return {'email': email, 'password': password, 'token': token};
  }
}
