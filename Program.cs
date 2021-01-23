using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mp09_plinq_parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Program main = new Program();
            main.start();
        }

        private void start()
        {
            this.loadPersones();
        }

        private void loadPersones()
        {
            string json = File.ReadAllText("people.json");
            List<Persona> persones = JsonConvert.DeserializeObject<List<Persona>>(json);
            foreach (Persona p in persones)
            {
                bool valid = p.comprova_dni() && p.comprova_mail() && p.comprova_nom();
                Console.WriteLine(p.Name + ", " + p.email + ", " + p.dni + "(" + valid + ")");
            }
        }
    }
}
