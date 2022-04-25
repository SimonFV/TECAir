using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Entities;
using Npgsql;

namespace api
{
    public static class DAL
    {
        /* 
        Get Baggage
        Returns all bags in the database.
        @param: void
        @throws: void
        */
        public static void Get_baggage()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT " + "\"Id\"" + ",ssn,weight,color FROM baggage";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3} \n", n[0], n[1], n[2], n[3]);

                con.Close();
            }
        }

        /* 
        Insert Baggage
        Create a baggage.
        @param:
            Email: Owner email
            Weight: Baggage weight
            Color: Baggage color
        @throws: 
            Boolean: 
                True if the Baggage is create
                False if not
        */
        public async static Task<Boolean> Insert_baggage(string email, int weight, string color)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                try
                {
                    string query = @"SELECT " + "\"Id\"" + " FROM " + "\"AspNetUsers\"" + " WHERE " + "\"Email\"" + " = '" + email + "';";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    con.Open();
                    NpgsqlDataReader m = await cmd.ExecuteReaderAsync();
                    int id = -1;
                    while (m.Read())
                        id = (int)m[0];
                    con.Close();
                    if (id == -1)
                        return false;

                    query = @"INSERT INTO baggage(id_user, weight, color) VALUES (" + id + ", " + weight + ", '" + color + "');";
                    cmd = new NpgsqlCommand(query, con);
                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("Baggage created");
                    con.Close();
                    return true;
                }
                catch
                {
                    Console.Write("Error");
                    con.Close();
                    return false;
                }
            }
        }

        /* 
        Get Book
        Returns all Books in the database.
        @param: void
        @throws: void
        */
        public static void Get_book()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT ssn,id_flight,seat FROM book";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2} \n", n[0], n[1], n[2]);

                con.Close();
            }
        }

        /* 
        Insert Book
        Create a Book
        @param:
            Email: Customer email
            Id_flight: Flight ID
            Status: Status of the book 
        @throws:
            Boolean: 
                True if the book is create
                False if not
        */
        public async static Task<Boolean> Insert_book(string Email, int id_flight, string status)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                try
                {
                    string query = @"SELECT " + "\"Id\"" + " FROM " + "\"AspNetUsers\"" + " WHERE " + "\"Email\"" + " = '" + Email + "';";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    con.Open();
                    NpgsqlDataReader n = await cmd.ExecuteReaderAsync();
                    int id = -1;
                    while (n.Read())
                        id = (int)n[0];
                    con.Close();
                    if (id == -1)
                        return false;

                    query = @"INSERT INTO book(id_user, id_flight, status) VALUES (" + id + ", " + id_flight + ", '" + status + "');";
                    cmd = new NpgsqlCommand(query, con);
                    con.Open();

                    int m = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return true;
                }
                catch (Exception err)
                {
                    Console.Write(err);
                    con.Close();
                    return false;
                }
            }
        }

        /* 
        Update Book
        Actualize Book
        @param:
            Email: Customer email
            Id_flight: Flight ID
            Seat: Flight Seat
            Status: Status of the book
        @throws:
            Boolean: 
                True if the book is update
                False if not
        */
        public async static Task<Boolean> Update_book(string Email, int id_flight, string seat, string status)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                try
                {
                    string query = @"SELECT " + "\"Id\"" + " FROM " + "\"AspNetUsers\"" + " WHERE " + "\"Email\"" + " = '" + Email + "';";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    con.Open();
                    NpgsqlDataReader n = await cmd.ExecuteReaderAsync();
                    int id = -1;
                    while (n.Read())
                        id = (int)n[0];
                    con.Close();
                    if (id == -1)
                        return false;

                    query = @"UPDATE book SET seat = '" + seat + "', status = '" + status + "' WHERE id_user = " + id + " AND id_flight = " + id_flight + ";";
                    cmd = new NpgsqlCommand(query, con);
                    con.Open();

                    int m = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return true;
                }
                catch (Exception err)
                {
                    Console.Write(err);
                    con.Close();
                    return false;
                }
            }
        }

        /* 
        Get Planes
        Returns all planes free in the database.
        @param: void
        @throws: void
        */
        public static void Get_planes()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT airplane_license,model FROM plane WHERE plane.status = 'Free'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1} \n", n[0], n[1]);

                con.Close();
            }
        }

        /* 
        Insert Plane
        Create a Plane
        @param:
            Airplane_license: License Airplane
            Capacity: Airplane capacity
            Model: Airplane model
        @throws:
            Boolean: 
                True if the plane is create
                False if not
        */
        public async static Task<Boolean> Insert_plane(string airplane_license, int capacity, string model)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO plane(airplane_license, capacity, model) VALUES ('" + airplane_license + "', " + capacity + ", '" + model + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return true;
                }
                catch
                {
                    Console.Write("Error: Airplane License is in use");
                    con.Close();
                    return false;
                }
            }
        }

        /* 
        Get Flight
        Returns all flight no close in the database.
        @param: void
        @throws: void
        */
        public async static Task<List<FlightResponse>> Get_flights()
        {
            List<FlightResponse> flights = new List<FlightResponse>();
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT flight." + "\"Id\"" + ", rute.departure, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane  WHERE flight.status != 'Close' " +
                                "AND flight.airplane_license = plane.airplane_license AND flight.id_rute = rute." + "\"Id\"" + ";";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = await cmd.ExecuteReaderAsync();

                while (n.Read())
                {
                    var flight = new FlightResponse()
                    {
                        Id = (int)n[0],
                        Departure = (string)n[1],
                        Arrival = (string)n[2],
                        Model = (string)n[3],
                        Schedule = (DateTime)n[4],
                        Deals = (n[5] as int?) ?? 0
                    };
                    flights.Add(flight);
                }
                con.Close();
                foreach (var flight in flights)
                {
                    query = @"SELECT place FROM scale WHERE scale.route_id = " +
                        "(SELECT " + "\"Id\"" + " FROM rute WHERE rute.departure = '" + flight.Departure + "' AND rute.arrival = '" + flight.Arrival + "');";
                    NpgsqlCommand cmd3 = new NpgsqlCommand(query, con);
                    con.Open();
                    NpgsqlDataReader o = await cmd3.ExecuteReaderAsync();
                    List<string> scales = new List<string>();

                    while (o.Read())
                    {
                        scales.Add((string)o[0]);
                    }

                    for (int i = 0; i < flights.Count; i++)
                        flights[i].Scale = scales;

                    con.Close();
                }
            }
            return flights;
        }

        /* 
        Get Flight by Rute
        Returns all flights that meet the condition in the database.
        @param:
            Departure: Departure of the flight
            Arrival: Arrival of the flight
        @throws: 
            List of Flight
        */
        public async static Task<List<FlightResponse>> Get_flight_by_rute(string departure, string arrival)
        {
            List<FlightResponse> flights = new List<FlightResponse>();
            using (NpgsqlConnection con = GetConnection())
            {
                int id_route = -1;
                string query = @"SELECT " + "\"Id\"" + " FROM rute WHERE rute.departure = '" + departure + "' AND rute.arrival = '" + arrival + "';";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader m = await cmd2.ExecuteReaderAsync();
                while (m.Read())
                    id_route = (int)m[0];
                con.Close();

                query = @"SELECT flight." + "\"Id\"" + ", rute.departure, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane WHERE flight.id_rute ="
                     + id_route + " AND flight.airplane_license = plane.airplane_license AND flight.status != 'Close' AND flight.id_rute = rute." + "\"Id\"" + ";";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = await cmd1.ExecuteReaderAsync();

                while (n.Read())
                {
                    var flight = new FlightResponse()
                    {
                        Id = (int)n[0],
                        Departure = (string)n[1],
                        Arrival = (string)n[2],
                        Model = (string)n[3],
                        Schedule = (DateTime)n[4],
                        Deals = (n[5] as int?) ?? 0
                    };
                    flights.Add(flight);
                }
                con.Close();

                query = @"SELECT place FROM scale WHERE scale.route_id = " + id_route + ";";
                NpgsqlCommand cmd3 = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader o = await cmd3.ExecuteReaderAsync();
                List<string> scales = new List<string>();

                while (o.Read())
                {
                    scales.Add((string)o[0]);
                }

                for (int i = 0; i < flights.Count; i++)
                    flights[i].Scale = scales;

                con.Close();

            }
            return flights;
        }

        /* 
        Get Flight by Deals
        Returns all flights who have deals in the database.
        @param: void
        @throws: 
            List of Flight
        */
        public async static Task<List<FlightResponse>> Get_flights_deals()
        {
            List<FlightResponse> flights = new List<FlightResponse>();
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT flight." + "\"Id\"" + ", rute.departure, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane "
                    + "WHERE flight.deals != 0 AND flight.airplane_license = plane.airplane_license AND flight.status != 'Close' AND flight.id_rute = rute." + "\"Id\"" + ";";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = await cmd.ExecuteReaderAsync();

                while (n.Read())
                {
                    var flight = new FlightResponse()
                    {
                        Id = (int)n[0],
                        Departure = (string)n[1],
                        Arrival = (string)n[2],
                        Model = (string)n[3],
                        Schedule = (DateTime)n[4],
                        Deals = (n[5] as int?) ?? 0
                    };
                    flights.Add(flight);
                }
                con.Close();
                foreach (var flight in flights)
                {
                    query = @"SELECT place FROM scale WHERE scale.route_id = " +
                        "(SELECT " + "\"Id\"" + " FROM rute WHERE rute.departure = '" + flight.Departure + "' AND rute.arrival = '" + flight.Arrival + "');";
                    NpgsqlCommand cmd3 = new NpgsqlCommand(query, con);
                    con.Open();
                    NpgsqlDataReader o = await cmd3.ExecuteReaderAsync();
                    List<string> scales = new List<string>();

                    while (o.Read())
                    {
                        scales.Add((string)o[0]);
                    }

                    for (int i = 0; i < flights.Count; i++)
                        flights[i].Scale = scales;

                    con.Close();
                }
            }
            return flights;
        }

        /* 
        Insert Flight
        Create a Flight
        @param:
            Airplane_license: Airplane License of the plane
            Departure: Departure of the flight
            Arrival: Arrival of the flight
            Gate: Boarding gate
            Schedule: Departure time
        @throws:
            Boolean: 
                True if the Flight is create
                False if not
        */
        public async static Task<Boolean> Insert_flight(string airplane_license, string departure, string arrival, string gate, string schedule, int deals)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                int id_rute = -1;
                string query = @"SELECT " + "\"Id\"" + " FROM rute WHERE departure = '" + departure + "' AND arrival = '" + arrival + "';";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader m = await cmd.ExecuteReaderAsync();
                while (m.Read())
                    id_rute = (int)m[0];
                con.Close();

                if (id_rute == -1)
                {
                    Console.Write("Route not found");
                    return false;
                }

                query = @"insert into flight(airplane_license,id_rute,gate,schedule,deals) values('" + airplane_license + "', " +
                            id_rute + ", '" + gate + "', '" + schedule + "', " + deals + "); UPDATE plane SET status = 'Occupied' WHERE airplane_license = '" +
                            airplane_license + "'; ";
                cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception err)
                {
                    Console.Write(err);
                    con.Close();
                    return false;
                }
            }
            return true;
        }

        /* 
        Update Flight Deal
        Modify the deal of the flight
        @param: 
            Id_flight: Flight who want to modificate
            Deal: New deal
        @throws: 
            Boolean: 
                True if the Flight is update
                False if not
        */
        public async static Task<Boolean> Update_flight_deal(int id_flight, int deal)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"UPDATE flight SET deals = " + deal + " WHERE " + "\"Id\"" + " = " + id_flight + ";";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                try
                {
                    int n = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                }
                catch (Exception err)
                {
                    Console.Write(err);
                    con.Close();
                    return false;
                }
            }
            return true;
        }

        /* 
        Get Rutes
        Returns all rutes in the database.
        @param: void
        @throws: void
        */
        public static void Get_rutes()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT * FROM rute";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3} \n", n[0], n[1], n[2], n[3]);

                con.Close();
            }
        }

        /* 
        Insert Rute
        Create a rute
        @param:
            Departure: Departure of the rute
            Scale: Scale of the rute
            Arrival: Arrival of the rute
            Miles: Miles of the rute
        @throws:
            Boolean: 
                True if the rute is create
                False if not
        */
        public async static Task<Boolean> Insert_rute(string departure, List<string> scale, string arrival, int miles)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"Insert into rute(departure, arrival, miles) values('" + departure + "', '" + arrival + "', " + miles + ");";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    NpgsqlDataReader n = await cmd.ExecuteReaderAsync();
                    con.Close();
                }
                catch (Exception err)
                {
                    Console.Write(err);
                    con.Close();
                    return false;
                }

                int id = -1;
                query = @"SELECT " + "\"Id\"" + " FROM rute WHERE rute.departure = '" + departure + "' AND rute.arrival = '" + arrival + "';";
                cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader m = await cmd.ExecuteReaderAsync();
                while (m.Read())
                    id = (int)m[0];
                con.Close();


                for (int i = 0; i < scale.Count; i++)
                {
                    query = @"Insert into scale(route_id, place, order_landing) values(" + id + ", '" + scale[i] + "', " + (i + 1) + ");";
                    cmd = new NpgsqlCommand(query, con);
                    con.Open();

                    try
                    {
                        int n = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception err)
                    {
                        Console.Write(err);
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        /* 
        Get School ID
        Returns all School ID in the database.
        @param: void
        @throws: void
        */
        public static void Get_schoolid()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT * FROM schoolid";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1} \n", n[0], n[1]);

                con.Close();
            }
        }

        /* 
        Insert School ID
        Create a School ID
        @param:
            Number: College ID
            Mile: Accumulated miles
        @throws:
            Boolean: 
                True if the School ID is create
                False if not
        */
        public static Boolean Insert_schoolid(int number, int mile)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO schoolid(number, mile) VALUES (" + number + ", " + mile + ");";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("School ID created");
                    con.Close();
                    return true;
                }
                catch
                {
                    Console.Write("Error");
                    con.Close();
                    return false;
                }
            }
        }

        /* 
        Get Users
        Returns all users ID in the database.
        @param: void
        @throws: void
        */
        public static void Get_users()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT ssn,schoolid,first_name,last_name_1,last_name_2,phone,email,university FROM user";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7} \n", n[0], n[1], n[2], n[3], n[4], n[5], n[6], n[7]);

                con.Close();
            }
        }

        /* 
        Get Seats by Flight
        Returns all seats in the specific flight.
        @param:
            Id_flight: Flight ID
        @throws:
            List of Seats
        */
        public async static Task<List<SeatsResponse>> get_seats_flight(int id_flight)
        {
            List<SeatsResponse> seats = new();
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT ssn,seat,status FROM book WHERE id_flight = " + id_flight + ");";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = await cmd.ExecuteReaderAsync();

                while (n.Read())
                    seats.Add(new SeatsResponse() { Ssn = (int)n[0], Seat = (string)n[1], Status = (string)n[2] });

                con.Close();
            }
            return seats;
        }

        /* 
        Insert User
        Create a Customer
        @param:
            SSN
            School ID
            First Name
            Last Name 1
            Last Name 2
            Phone
            Email
            University
            Password
        @throws:
            Boolean: 
                True if the customer is create
                False if not
        */
        public static Boolean Insert_user(int ssn, int schoolid, string first_name, string last_name_1, string last_name_2, int phone, string email, string university, string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO user(ssn,schoolid,first_name,last_name_1,last_name_2,phone,email,university,password) VALUES (" + ssn + "," + schoolid + ",'" + first_name + "','" + last_name_1 + "','" + last_name_2 + "'," + phone + ",'" + email + "','" + university + "','" + password + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("User created");
                    con.Close();
                    return true;
                }
                catch
                {
                    Console.Write("Error");
                    con.Close();
                    return false;
                }
            }
        }

        /* 
        TestConnection
        Test the connection with the Data Base
        @param: void
        @throws: void
        */
        private static void TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connected");
                }
                else
                {
                    Console.WriteLine("Error in the connection");
                }
                con.Close();
            }
        }

        /* 
        GetConnection
        Define the connection with the Data Base
        @param: void
        @throws: Data Base Connection
        */
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=TecAirDB;");
        }
    }
}