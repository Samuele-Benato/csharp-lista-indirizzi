namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\HP\\source\\repos\\BooleanC#\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addresses.csv";
            string pathclone = "C:\\Users\\HP\\source\\repos\\BooleanC#\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addressesClone.csv";
            /*
            Medoto 1 che mi legge il file e mi stampa riga per riga
            StreamReader file = File.OpenText(path);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                Console.WriteLine(line);
            }
            file.Close();
            
            Metodo 2 che mi legge e stampa il file in un unica riga
            string readfile = File.ReadAllText(path);
            Console.WriteLine(readfile);
            */

            var addresses = GetFileData(path);
            foreach ( var address in addresses )
            {
                Console.WriteLine(address.ToString());
            }
            MakeAClone(addresses, pathclone);
          
        }
        public static List<Address> GetFileData(string path)
        {
            List<Address> addresses = new List<Address>();
            var stream = File.OpenText(path);

            stream.ReadLine();
            while (!stream.EndOfStream)
            {
                string readfile = stream.ReadLine();

                try
                {
                    var data = readfile.Split(",");
                    string name = data[0];
                    string surname = data[1];
                    string street = data[2];
                    string city = data[3];
                    string province = data[4];
                    string zip = data[5];

                    Address a = new Address(name, surname, street, city, province, zip);
                    addresses.Add(a);
                }
                catch (FormatException e)
                {
                    e = null;
                    Console.WriteLine("Formato ZIP non conforme");
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Fuori range");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType().FullName + " " + e.Message);
                }
               
            }

            stream.Dispose();
            return addresses;
        }
        public static void MakeAClone(List<Address> addresses, string path)
        {
            using StreamWriter stream = File.CreateText(path); 
            foreach (var address in addresses)
                stream.WriteLine(address.ToString());
            //stream.Dispose(); // è implicito nello using
        }
    }
}
