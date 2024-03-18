using System.Text.Json;

namespace Ksiegarnia
{
    class Program
    {
        static void AddBook(List<Ksiazka> ksiazki)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwe książki");
            string nazwa = Console.ReadLine();
            Console.WriteLine("Podaj opis książki");
            string opis = Console.ReadLine();
            Console.WriteLine("Podaj wydawce książki");
            string wydawca = Console.ReadLine();
            Console.WriteLine("Podaj autora książki");
            string autor = Console.ReadLine();
            ksiazki.Add(new Ksiazka() {
                Id=ksiazki.Count + 1,
                Nazwa= nazwa,
                Opis=opis,
                Wydawca=wydawca,
                Autor=autor
                });
            string path = @"C:\Users\danypolska\source\repos\Ksiegarnia\Ksiegarnia\data.json";
            string json = JsonSerializer.Serialize<List<Ksiazka>>(ksiazki);
            File.WriteAllText(path, json);
            Console.WriteLine("Książka dodana!");
            Console.ReadKey();
        }
        static void ShowBooks(List<Ksiazka> ksiazki)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Obecne książki:");
            foreach(Ksiazka ksiazka in ksiazki)
            {
                Console.WriteLine($"{ksiazka.Id} | {ksiazka.Nazwa} | {ksiazka.Opis} | {ksiazka.Wydawca} | {ksiazka.Autor}");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Czy chcesz przeprowadzić akcje na użytkowniku?\n1.Usuń ksiazke\n2.Edytuj ksiaze");
            int ch2 = Convert.ToInt16(Console.ReadLine());
            switch (ch2)
            {
                case 1:
                    Console.WriteLine("Podaj ID użytkownika:");
                    int id = Convert.ToInt16(Console.ReadLine());
                    Ksiazka bookToRemove = ksiazki.FirstOrDefault(n => n.Id == id);
                    if (bookToRemove != null)
                        ksiazki.Remove(bookToRemove);
                    string path = @"C:\Users\danypolska\source\repos\Ksiegarnia\Ksiegarnia\data.json";
                    string json = JsonSerializer.Serialize<List<Ksiazka>>(ksiazki);
                    File.WriteAllText(path, json);
                    Console.WriteLine("Usunięto książke!");
                    Console.ReadKey();
                    break;
                    case 2:
                    Console.WriteLine("Podaj ID użytkownika");
                    int sID = Convert.ToInt16(Console.ReadLine());

                    Ksiazka booktoedit = ksiazki.FirstOrDefault(e => e.Id == sID);
                    if(booktoedit != null)
                    {
                        Console.WriteLine("Podaj nową nazwe:");
                        string nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj nowy opis:");
                        string opis = Console.ReadLine();
                        Console.WriteLine("Podaj nowego wydawce:");
                        string wydawca = Console.ReadLine();
                        Console.WriteLine("Podaj nowego autora:");
                        string autor = Console.ReadLine();
                        booktoedit.Nazwa = nazwa;
                        booktoedit.Opis = opis;
                        booktoedit.Wydawca = wydawca;
                        booktoedit.Autor = autor;
                        string pathB = @"C:\Users\danypolska\source\repos\Ksiegarnia\Ksiegarnia\data.json";
                        string jsonB = JsonSerializer.Serialize<List<Ksiazka>>(ksiazki);
                        File.WriteAllText(pathB, jsonB);
                        Console.WriteLine("Zedytowano książke");
                        Console.ReadKey();  
                    }
                    break;
            }
            Console.ReadKey();
        }
        
        public static void Main(string[] args)
        {
            bool repeat = true;
            string path = @"C:\Users\danypolska\source\repos\Ksiegarnia\Ksiegarnia\data.json";
            List<Ksiazka> ksiazki = new List<Ksiazka>();
            try
            {
                if(!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                string json = File.ReadAllText(path);
                ksiazki = JsonSerializer.Deserialize<List<Ksiazka>>(json);
                while (repeat)
                {
                    Console.Clear();
                    Console.WriteLine("Witaj w naszej księgarni! \nWybierz opcje:\n1. Dodaj książe\n2. Zobacz nasze książki\n3. Wyjdz");

                    int choice = Convert.ToInt16(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddBook(ksiazki);
                            break;
                        case 2:
                            ShowBooks(ksiazki);
                            break;
                        case 3:
                            Console.WriteLine("Wychodzenie....");
                            repeat = false;
                            break;
                        default:
                            repeat = false;
                            break;
                    }
                }
            }catch (Exception ex) { 
            
            Console.WriteLine(ex.ToString());}
        }
    }
}