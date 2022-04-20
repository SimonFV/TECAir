class Flight {
  final int? id;
  final int? idRute;
  final String airplaneLicense;
  final String gate;
  final String schedule;
  final String status;
  final int deals;

  Flight(
      {required this.id,
      required this.idRute,
      required this.airplaneLicense,
      required this.gate,
      required this.schedule,
      required this.status,
      required this.deals});

  factory Flight.fromMap(Map<String, dynamic> json) => Flight(
      id: json['id'],
      idRute: json['idRute'],
      airplaneLicense: json['airplaneLicense'],
      gate: json['gate'],
      schedule: json['schedule'],
      status: json['status'],
      deals: json['deals']);

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'idRute': idRute,
      'airplaneLicense': airplaneLicense,
      'gate': gate,
      'schedule': schedule,
      'status': status,
      'deals': deals,
    };
  }
}
