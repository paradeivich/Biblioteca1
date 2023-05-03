using LibrarieModele;

using NivelStocareDate;

using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms { 
    public partial class Form1 : Form
    {
        AdministrareCarti_FisierText adminCarti;

        private Label lblNume;
        private Label lblAutor;
        

        private Label[] lblsNume;
        private Label[] lblsAutor;
       

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        public Form1()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminCarti = new AdministrareCarti_FisierText(caleCompletaFisier);

            InitializeComponent();

            //setare proprietati
            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Informatii Carti";

            //adaugare control de tip Label pentru 'Nume';
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNume);

            //adaugare control de tip Label pentru 'Autor';
            lblAutor = new Label();
            lblAutor.Width = LATIME_CONTROL;
            lblAutor.Text = "Autor";
            lblAutor.Left = 2 * DIMENSIUNE_PAS_X;
            lblAutor.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAutor);

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaCarti();
        }

        private void AfiseazaCarti()
        {
            Carte[] carti = adminCarti.GetCarte(out int nrBook);

            lblsNume = new Label[nrBook];
            lblsAutor = new Label[nrBook];
            

            int i = 0;
            foreach (Carte student in carti)
            {
                //adaugare control de tip Label pentru numele cartilor;
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
            lblsNume[i].Text = "Nume";
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru autorul cartilor
                lblsAutor[i] = new Label();
                lblsAutor[i].Width = LATIME_CONTROL;
            lblsAutor[i].Text = "Autor";
                lblsAutor[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsAutor[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsAutor[i]);

               
            }
        }
    }
}
