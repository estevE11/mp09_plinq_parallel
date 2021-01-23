using System.Threading.Tasks;
using System.Diagnostics;
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
            List<Persona> persones = this.loadPersones();
            
            Stopwatch timer = new Stopwatch();
            // Serial
            timer.Start();
            CalcSerial(persones);
            timer.Stop();
            Console.WriteLine("");
            Console.WriteLine("Serial time: " + timer.ElapsedMilliseconds);
            Console.WriteLine("");

            timer = new Stopwatch();
            // Parallel
            timer.Start();
            CalcParallel(persones);
            timer.Stop();
            Console.WriteLine("");
            Console.WriteLine("Parallel time: " + timer.ElapsedMilliseconds);
        }

        private void CalcSerial(List<Persona> persones)
        {            
            int nomsCorrectes = 0;
            int nomsIncorrectes = 0;
            int dniCorrectes = 0;
            int dniIncorrectes = 0;
            int emailCorrectes = 0;
            int emailIncorrectes = 0;
            foreach (Persona p in persones)
            {
                if (p.comprova_nom()) nomsCorrectes++;
                else nomsIncorrectes++;
                if (p.comprova_dni()) dniCorrectes++;
                else dniIncorrectes++;
                if (p.comprova_mail()) emailCorrectes++;
                else emailIncorrectes++;
            }
            Console.WriteLine("noms: " + nomsCorrectes + "/" + (nomsIncorrectes + nomsCorrectes));
            Console.WriteLine("dni: " + dniCorrectes + "/" + (dniIncorrectes + dniCorrectes));
            Console.WriteLine("emails: " + emailCorrectes + "/" + (emailIncorrectes + emailCorrectes));
        }
        private void CalcParallel(List<Persona> persones)
        {
            int nomsCorrectes = 0;
            int nomsIncorrectes = 0;
            int dniCorrectes = 0;
            int dniIncorrectes = 0;
            int emailCorrectes = 0;
            int emailIncorrectes = 0;

            Parallel.Invoke(
                () =>
                {
                    foreach (Persona p in persones)
                    {
                        if (p.comprova_nom()) nomsCorrectes++;
                        else nomsIncorrectes++;
                    }
                },
                () =>
                {
                    foreach (Persona p in persones)
                    {
                        if (p.comprova_dni()) dniCorrectes++;
                        else dniIncorrectes++;
                    }
                },
                () =>
                {
                    foreach (Persona p in persones)
                    {
                        if (p.comprova_mail()) emailCorrectes++;
                        else emailIncorrectes++;
                    }
                }
            );

            Console.WriteLine("noms: " + nomsCorrectes + "/" + (nomsIncorrectes + nomsCorrectes));
            Console.WriteLine("dni: " + dniCorrectes + "/" + (dniIncorrectes + dniCorrectes));
            Console.WriteLine("emails: " + emailCorrectes + "/" + (emailIncorrectes + emailCorrectes));
        }

        private List<Persona> loadPersones()
        {
            string json = File.ReadAllText("people.json");
            List<Persona> persones = JsonConvert.DeserializeObject<List<Persona>>(json);
            return persones;
        }
    }
}
