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
        static void Main(string[] args)
        {
            TestConnection();
            Console.ReadKey();
        }
        */

        public static void Get_baggage()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT uniqueid,ssn,weight,color FROM baggage";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3} \n", n[0], n[1], n[2], n[3]);

                con.Close();
            }
        }

        public static Boolean Insert_baggage(int uniqueid, int ssn, int weight, string color)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO baggage(uniqueid, ssn, weight, color) VALUES (" + uniqueid + ", " + ssn + ", " + weight + ", '" + color + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
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

        public static Boolean Insert_book(int ssn, int id_flight, string seat)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO book(ssn, id_flight, seat) VALUES (" + ssn + ", " + id_flight + ", '" + seat + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("Book created");
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

        public static Boolean Insert_plane(string airplane_license, int capacity, string model)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO plane(airplane_license, capacity, model) VALUES ('" + airplane_license + "', " + capacity + ", '" + model + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("Airplane created");
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

        public static void Get_flight()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT flight.id, rute.departure, rute.scale, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane  WHERE flight.status != 'Close'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", n[0], n[1], n[2], n[3], n[4], n[5], n[6]);

                con.Close();
            }
        }

        public async static Task<List<FlightResponse>> Get_flight_by_rute(string departure, string arrival)
        {
            List<FlightResponse> flights = new List<FlightResponse>();
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT flight.id, rute.departure, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane WHERE flight.status != 'Close' AND rute.departure = '" + departure + "' AND rute.arrival = '" + arrival + "';";
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

                int id_route = -1;
                query = @"SELECT id FROM rute WHERE rute.departure = '" + departure + "' AND rute.arrival = '" + arrival + "';";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader m = await cmd2.ExecuteReaderAsync();
                while (m.Read())
                    id_route = (int)m[0];
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

        public static void Get_flight_by_deals()
        {

            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT flight.id, rute.departure, rute.scale, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane WHERE flight.status != 'Close' AND flight.deals != 0";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                {
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", n[0], n[1], n[2], n[3], n[4], n[5], n[6]);
                }
                con.Close();
            }
        }

        public static Boolean Insert_flight(int id, string airplane_license, int id_rute, int gate, DateTimeOffset schedule)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"insert into flight(id,airplane_license,id_rute,gate,schedule) values(" + id + ", '" + airplane_license + "', " + id_rute + ", '" + gate + "', '" + schedule + "'); UPDATE plane SET status = 'Occupied' WHERE airplane_license = '" + airplane_license + "'; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("Flight created");
                    con.Close();
                    return true;
                }
                catch
                {
                    Console.Write("Error: Id Flight is in use");
                    con.Close();
                    return false;
                }
            }
        }

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

        public static Boolean Insert_rute(int id, string departure, List<string> scale, string arrival, int miles)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"Insert into rute(id, departure, arrival, miles) values(" + id + ", '" + departure + "', '" + arrival + "', " + miles + ");";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("Rute created");
                    con.Close();
                }
                catch
                {
                    Console.Write("Error: Id Rute is in use");
                    con.Close();
                    return false;
                }

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
                return true;

            }
        }

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

        public static void Get_user()
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

        private static NpgsqlConnection GetConnection()
        {
            // Enter password
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=TecAirDB;");
        }
    }
}