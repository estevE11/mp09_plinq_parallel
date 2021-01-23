using System;

namespace mp09_plinq_parallel
{
    public class Persona
    {
        public string dni { get; set; }
        public string Name { get; set; }
        public string email { get; set; }

        private String[] nif_validate_data = new String[]{"T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };

    public bool comprova_dni()
        {
            int n = Int32.Parse(this.dni.Substring(0, this.dni.Length - 1));
            String l = this.dni.Substring(this.dni.Length - 1, 1);
            int rest = n % 23;
            if(rest > 22 || !this.nif_validate_data[rest].Equals(l)) return false;
            return true;
        }
        public bool comprova_mail()
        {
            if (this.email.EndsWith("@") || this.email.StartsWith("@")) return false;
            bool res = false;
            foreach(char it in this.email)
            {
                if (it == '@')
                {
                    if (res) return false;
                    else
                    {
                        res = true;
                    }
                }
            }
            return res;
        }
        public bool comprova_nom()
        {
            return this.Name.Length > 0;
        }
        private char calcula_lletra(string Str)
        {
            int n = Int32.Parse(Str.Substring(0, Str.Length - 1));
            String l = Str.Substring(Str.Length - 1, 1);
            int rest = n % 23;
            return char.Parse(this.nif_validate_data[rest]);
        }
    }
}
