using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class FileFunctions
    {
        public void ReadFile(string path)
        {
            StreamReader file = File.OpenText(path);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                Console.WriteLine(line);
            }
            file.Close();
        }
    }
}
