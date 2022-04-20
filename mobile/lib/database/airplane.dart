class Airplane {
  final String airplaneLicense;
  final int capacity;

  Airplane({required this.airplaneLicense, required this.capacity});

  factory Airplane.fromMap(Map<String, dynamic> json) => Airplane(
      airplaneLicense: json['airplaneLicense'], capacity: json['capacity']);

  Map<String, dynamic> toMap() {
    return {
      'airplaneLicense': airplaneLicense,
      'capacity': capacity,
    };
  }
}
