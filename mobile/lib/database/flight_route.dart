class FlightRoute {
  final int? id;
  final String departure;
  final String arrival;
  final List<String> scale;

  FlightRoute({
    required this.id,
    required this.departure,
    required this.arrival,
    required this.scale,
  });

  factory FlightRoute.fromMap(Map<String, dynamic> json) => FlightRoute(
      id: json['id'],
      departure: json['departure'],
      arrival: json['arrival'],
      scale: json['scale']);

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'departure': departure,
      'arrival': arrival,
      'scale': scale,
    };
  }
}
