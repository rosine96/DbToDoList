using MySql.Data.MySqlClient;

namespace DB_toDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choix = 1, reponse = 1;
            string setting = "Server=localhost;Database=todolist_db;Uid=root;Pwd=rosine28;";
            try
            {
                using(MySqlConnection connection=new MySqlConnection(setting))
                {
                    connection.Open();
                    Console.WriteLine("connection ouverte");
                    do
                    {
                        Console.WriteLine(@"bienvenue sur db-todolist,que voulez vous faire?
                        1-ajouter une tache
                        2-supprimer une tache
                        3-marquer une tache comme terminer
                        4-afficher la liste des taches
                        5-afficher les taches terminees");
                        choix=int.Parse(Console.ReadLine());
                        switch(choix)
                        {
                            case 1:
                                Console.WriteLine("entrer l'intitule de la tache");
                                string intitule=Console.ReadLine();
                                Console.WriteLine("entrer l'heure de debut de la tache format" +
                                    "heure:minute:seconde exemple 10:15:00");
                                string h_debut = Console.ReadLine();
                                Console.WriteLine("entrer l'heure de fin de la tache format " +
                                    "heure:minute:seconde exemple 10:15:00");
                                                                        
                                string h_fin = Console.ReadLine();
                                Task tache=new Task(intitule, h_debut, h_fin);
                                Console.WriteLine("tache cree");
                                tache.AddTask(connection);
                                break;
                            case 2:
                                Console.WriteLine("entrer l'intitule de la tache a supprimer");
                                 intitule = Console.ReadLine();
                                Task.DeleteTask(connection, intitule);
                                break;
                            case 3:
                                Console.WriteLine("entrer l'intitule de la tache terminee");
                                intitule = Console.ReadLine();
                                Task.MarkAsFinish(connection, intitule);
                                break;
                            case 4:
                                Task.ListTask(connection);
                                break;
                            case 5:
                                Task.NotFinishTask(connection);
                                break;
                            default: 
                                Console.WriteLine("choisissez un chiffres correspondant aux " +
                                    "actions ci dessous");
                                break;


                        }
                        Console.WriteLine(@"avez vous besoin d'effectuer une autre action?
                                            1-oui
                                            2-non");
                        reponse=int.Parse(Console.ReadLine());

                    } while (reponse == 1); 
                }
            }
            catch (MySqlException e) 
            { 
                Console.WriteLine(e.Message);
            }
        }
    }
}   