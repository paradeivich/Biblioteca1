using System;

namespace LibrarieModele
{
    public class Carte
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';
        private const bool SUCCES = true;
       

        private const int ID = 0;
        private const int NUME = 1;
        private const int AUTOR = 2;
        //private const int NOTE = 3;

        

        //proprietati auto-implemented
        private int IdBook { get; set; }    
        private string Nume { get; set; }   
        private string Autor { get; set; }

        //constructor implicit
        public Carte()
        {
            Nume = Autor = string.Empty;
        }

        public Carte(int idBook, string nume, string autor)
        {
            this.IdBook = idBook;
            this.Nume = nume;
            this.Autor = autor;
        }

        public Carte(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            IdBook = Convert.ToInt32(dateFisier[ID]);
            Nume = dateFisier[NUME];
            Autor = dateFisier[AUTOR];
            
        }

        public string Info()
        {
            string info = string.Format("Id:{0} Nume:{1} Autor: {2}",
                IdBook.ToString(),
                (Nume ?? "NECUNOSCUT"),
                (Autor ?? "NECUNOSCUT"));
                                  
            return info;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectCartePentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                IdBook.ToString(),
                (Nume ?? " NECUNOSCUT "),
                (Autor ?? " NECUNOSCUT "));

            return obiectCartePentruFisier;
        }
       

        public int GetIdBook()
        {
            return IdBook;
        }

        public string GetNume()
        {
            return Nume;
        }

        public string GetAutor()
        {
            return Autor;
        }

        public void SetIdBook(int idBook)
        {
            this.IdBook = idBook;
        }
    }
}
