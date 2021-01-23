namespace mp09_plinq_parallel
{
    public class Persona
    {
        public string dni { get; set; }
        public string nom { get; set; }
        public string mail { get; set; }

        public bool comprova_dni()
        {
            return true;
        }
        public bool comprova_mail()
        {
            return true;
        }
        public bool comprova_nom()
        {
            return true;
        }
        private char calcula_lletra(string Str)
        {
            return 'A';
        }
    }
}
