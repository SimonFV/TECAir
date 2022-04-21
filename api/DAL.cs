using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DAL
{
    class DAL
    {
        /*
        static void Main(string[] args)
        {
            TestConnection();
            Console.ReadKey();
        }
        */

        private static void Get_planes()
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

        private static Boolean Insert_plane(string airplane_license, int capacity, string model)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO plane(airplane_license, capacity, model) VALUES (" + airplane_license + ", " + capacity + ", " + model + ");";
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

        private static void Get_flight()
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

        private static void Get_flight_by_rute(string departure, string arrival)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT flight.id, rute.departure, rute.scale, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane WHERE flight.status != 'Close' AND rute.departure = " + departure + " AND rute.arrival = " + arrival;
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", n[0], n[1], n[2], n[3], n[4], n[5], n[6]);

                con.Close();
            }
        }

        private static void Get_flight_by_deals()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"SELECT flight.id, rute.departure, rute.scale, rute.arrival, plane.model, flight.schedule, flight.deals FROM flight,rute,plane WHERE flight.status != 'Close' AND flight.deals != 0";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader n = cmd.ExecuteReader();

                while (n.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6} \n", n[0], n[1], n[2], n[3], n[4], n[5], n[6]);

                con.Close();
            }
        }

        private static Boolean Insert_flight(int id, string airplane_license, int id_rute, int gate, string schedule)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"insert into flight(id,airplane_license,id_rute,gate,schedule,seat_available) values(" + id + ", " + airplane_license + ", " + id_rute + ", " + gate + ", " + schedule + ", (select capacity from plane where airplane_license = " + airplane_license + ")); UPDATE plane SET status = 'Occupied' WHERE airplane_license = " + airplane_license + "; ";
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

        private static void Get_rutes()
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

        private static Boolean Insert_rute(int id, string departure, string scale, string arrival)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"Insert into rute (id, departure, scale, arrival) values(" + id + ", " + departure + ", " + scale + ", " + arrival + "); ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    Console.Write("Rute created");
                    con.Close();
                    return true;
                }
                catch
                {
                    Console.Write("Error: Id Rute is in use");
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
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password= ;Database=tecair;");
        }
    }
}
