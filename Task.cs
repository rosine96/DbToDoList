using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DB_toDoList
{
    internal class Task
    {
        public string? intitule { get;private set; }
        public string heure_debut { get; private set; }
        public string heure_fin { get; private set; }
        public int finish { get; private set; }
        public Task(string intitule,string heure_debut,string heure_fin)
        {
            this.intitule = intitule;
            this.heure_debut = heure_debut;
            this.heure_fin = heure_fin;
            this.finish = 0;
            
        }
        public static void ListTask(MySqlConnection connection)
        {
            string query = "select * from task";
            using(MySqlCommand cmd = new MySqlCommand(query,connection))
            {
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["intitule"]);
                    }
                }
            }
        }
        public static void MarkAsFinish(MySqlConnection connection,string tache)
        {
            string query = "update task set termine=true where intitule=@tache";
            using(MySqlCommand cmd= new MySqlCommand(query,connection))
            {
                cmd.Parameters.AddWithValue("@tache",tache);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteTask(MySqlConnection connection,string tache)
        {
            string query = "delete from task where intitule=@tache";
            using (MySqlCommand cmd= new MySqlCommand(query,connection))
            {
                cmd.Parameters.AddWithValue("@tache", tache);
                cmd.ExecuteNonQuery();
            }
        }
        public static void NotFinishTask(MySqlConnection connection)
        {
            string query = "select * from task where termine=1";
            using (MySqlCommand cmd= new MySqlCommand(query,connection))
            {
                using(MySqlDataReader rd = cmd.ExecuteReader())
                { while (rd.Read())
                    {
                        Console.WriteLine(rd["intitule"]);
                    }
                        
                            
                }
            }
        }
        public void AddTask(MySqlConnection connection)
        {
            string query = "insert into task(intitule,termine,heure_debut,heure_final) values(@intitule,@termine,@heure_debut,@heure_final)";
            using(MySqlCommand cmd=new MySqlCommand(query,connection))
            {
                cmd.Parameters.AddWithValue("@intitule", this.intitule);
                cmd.Parameters.AddWithValue("@termine", this.finish);
                cmd.Parameters.AddWithValue("@heure_debut", this.heure_debut);
                cmd.Parameters.AddWithValue("@heure_final", this.heure_fin);
                
                cmd.ExecuteNonQuery ();

            }
        }
    }
}
