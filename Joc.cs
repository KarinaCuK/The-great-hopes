using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public partial class Joc : Form
    {
        public static int activare;
        public static Joc m;
        public Joc()
        {
            InitializeComponent();
        }
        List<string> imagini2 = new List<string>();
        List<string> orase = new List<string>();
        List<PictureBox> w = new List<PictureBox>();
        Random r = new Random();
        int i=0,j,s=41,final=0,scor=0,nivelf,timp,timpc=0;
        int[] vector= new int [42];

        private void pB_Click(object sender, EventArgs e)
        {
            PictureBox pBox = (PictureBox)sender;
            if (pBox.Name==w[vector[i]].Name)
            {
                if (j == 0)
                    w[vector[i]].Image = Image.FromFile(imagini2[1]);
                else
                    if (j == 1)
                        w[vector[i]].Image = Image.FromFile(imagini2[2]);
                i++;
                if (j == 0)
                    scor += 5;
                else
                    scor++;
                label1.Text = "Găsiți orașul: "+(orase[vector[i]]);
                j = 0;
                final++;
            }
            else
            {
                if (j == 1)
                {
                    w[vector[i]].Image = Image.FromFile(imagini2[3]);
                    i++;
                    label1.Text ="Găsiți orașul: "+(orase[vector[i]]);
                    j = 0;
                    final++;
                }
                else
                    j++;
            }
            if (final == nivelf)
            {
                final = 0;
                progressBar1.Visible = false;
                for (s = 0; s < 41; s++)
                    w[s].Visible = false;
                pictureBox1.Visible = false;
                scor *= (timp-timpc)/4;
                if (!string.IsNullOrWhiteSpace(Login.n) || (!string.IsNullOrWhiteSpace(Login.p)))
                    label1.Text = Login.n + " " + Login.p + ", vă rugăm să selectați nivelul de dificultate.";
                else
                {
                    label1.Text = "Vă rugăm să selectați nivelul de dificultate.";
                }
                timer1.Stop();
                MessageBox.Show("Felicitări, ați ajuns la sfârșitul jocului!\n"+"Scorul tau este: "+ scor+"!");

                if (!string.IsNullOrWhiteSpace(Login.n) || (!string.IsNullOrWhiteSpace(Login.p)))
                {
                    DataTable tabel = this.punctajeDataSet.punctajJoc;

                    int ok = 0;
                    foreach (DataRow linie in tabel.Rows)
                    {
                        if (linie.Field<string>(1) == Login.n && linie.Field<string>(2) == Login.p && linie.Field<int>(3) < scor)
                        {
                            linie["Scor"] = scor;
                            ok = 1;
                        }
                    }
                    if (ok == 0)
                    {
                        DataRow linieNoua=tabel.NewRow();
                        
                        linieNoua["ID"] = tabel.Rows.Count + 1;
                        linieNoua["Nume"] = Login.n;
                        linieNoua["Prenume"] = Login.p;
                        linieNoua["Scor"] = scor;
                        tabel.Rows.Add(linieNoua);
                    }
                    this.punctajJocTableAdapter.Update(this.punctajeDataSet.punctajJoc);
                    this.dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Descending);
                }
                //if (!string.IsNullOrWhiteSpace(Login.n) || (!string.IsNullOrWhiteSpace(Login.p)))
                //{
                //    DataTable tabel = this.punctajeDataSet.punctajJoc;
                   
                    //DataView dv = tabel.DefaultView;
                    //dv.Sort = "Scor desc";
                    //DataTable tabelsortat = dv.ToTable();
                    //foreach (DataRow linie in tabel.Rows)
                    //{
                    //    string j;
                    //    j = linie.Field<string>("Scor");
                    //    MessageBox.Show("scor= "+j);
                        //if (linie["Scor"] < scor)
                        //{
                        //    linie["Nume"] = Login.n;
                        //    linie["Prenume"] = Login.p;
                        //    linie["Scor"] = scor;
                        //    tabel.Rows.Add(linie);
                        //}
                    //}
                //}
                scor = 0;
            }
        }

        private void Joc_Load(object sender, EventArgs e)
        {
            this.punctajJocTableAdapter.Fill(this.punctajeDataSet.punctajJoc);
            this.dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Descending);
            m = new Joc();

            
            Joc.activare++;
            imagini2.Add("0.png");
            imagini2.Add("1.png");
            imagini2.Add("2.png");
            imagini2.Add("3.png");
            orase.Add("Târgu Mureș");
            orase.Add("Vaslui");
            orase.Add("Iași");
            orase.Add("Botoșani");
            orase.Add("Tulcea");
            orase.Add("Suceava");
            orase.Add("Brăila");
            orase.Add("Galați");
            orase.Add("Constanța");
            orase.Add("Satu Mare");
            orase.Add("Baia Mare");
            orase.Add("Buzău");
            orase.Add("București");
            orase.Add("Giurgiu");
            orase.Add("Alexandria");
            orase.Add("Drobeta Turnu-Severin");
            orase.Add("Craiova");
            orase.Add("Hunedoara");
            orase.Add("Reșita");
            orase.Add("Zalău");
            orase.Add("Arad");
            orase.Add("Oradea");
            orase.Add("Timișoara");
            orase.Add("Cluj Napoca");
            orase.Add("Piatra Neamț");
            orase.Add("Bistrița");
            orase.Add("Bacău");
            orase.Add("Brașov");
            orase.Add("Sfântul Gheorghe");
            orase.Add("Sibiu");
            orase.Add("Miercurea Ciuc");
            orase.Add("Deva");
            orase.Add("Alba Iulia");
            orase.Add("Râmnicu Vâlcea");
            orase.Add("Târgu Jiu");
            orase.Add("Pitești");
            orase.Add("Slatina");
            orase.Add("Ploiești");
            orase.Add("Târgoviște");
            orase.Add("Călărași");
            orase.Add("Slobozia");
            w.Add(pictureBox3);
            w.Add(pictureBox4);
            w.Add(pictureBox5);
            w.Add(pictureBox6);
            w.Add(pictureBox7);
            w.Add(pictureBox8);
            w.Add(pictureBox9); 
            w.Add(pictureBox10);
            w.Add(pictureBox11);
            w.Add(pictureBox12);
            w.Add(pictureBox13);
            w.Add(pictureBox14);
            w.Add(pictureBox15);
            w.Add(pictureBox16);
            w.Add(pictureBox17);
            w.Add(pictureBox18);
            w.Add(pictureBox19);
            w.Add(pictureBox20);
            w.Add(pictureBox21);
            w.Add(pictureBox22);
            w.Add(pictureBox23);
            w.Add(pictureBox24);
            w.Add(pictureBox25);
            w.Add(pictureBox26);
            w.Add(pictureBox27);
            w.Add(pictureBox28);
            w.Add(pictureBox29);
            w.Add(pictureBox30);
            w.Add(pictureBox31);
            w.Add(pictureBox32);
            w.Add(pictureBox33);
            w.Add(pictureBox34);
            w.Add(pictureBox35);
            w.Add(pictureBox36);
            w.Add(pictureBox37);
            w.Add(pictureBox38);
            w.Add(pictureBox39);
            w.Add(pictureBox40);
            w.Add(pictureBox41);
            w.Add(pictureBox42);
            w.Add(pictureBox43);
            if (!string.IsNullOrWhiteSpace(Login.n) || (!string.IsNullOrWhiteSpace(Login.p)))
                label1.Text = Login.n + " " + Login.p + ", vă rugăm să selectați nivelul de dificultate.";
            else
            {
                label1.Text ="Vă rugăm să selectați nivelul de dificultate.";
            }
        }

        void generare()
        {
            for (s = 0; s < 41;s++ )
            {
                vector[s] = s;
                w[s].Image = Image.FromFile(imagini2[0]);
            }
            s--;
         while (s > 1)
        {  
           
          int k = r.Next(s + 1);  
            int valoare = vector[k];  
            vector[k] = vector[s];  
            vector[s] = valoare;
            s--;  
        }
         i = 0;
         label1.Text = "Găsiți orașul: " + (orase[vector[i]]);
         progressBar1.Visible = true;
         for (s = 0; s < 41; s++)
             w[s].Visible = true;
         pictureBox1.Visible = true;
    
        }

        private void bRevenire_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
            Joc.activare--;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timpc++;
            progressBar1.Value--;
            if (progressBar1.Value==0)
            {
                timer1.Stop();
                progressBar1.Visible = false;
                for (s = 0; s < 41; s++)
                    w[s].Visible = false;
                pictureBox1.Visible = false;
                if (!string.IsNullOrWhiteSpace(Login.n) || (!string.IsNullOrWhiteSpace(Login.p)))
                    label1.Text = Login.n + " " + Login.p + ", vă rugăm să selectați nivelul de dificultate.";
                else
                {
                    label1.Text = "Vă rugăm să selectați nivelul de dificultate.";
                }
                MessageBox.Show("Felicitari scorul tau este: "+ scor +"!");
                
                if (!string.IsNullOrWhiteSpace(Login.n) || (!string.IsNullOrWhiteSpace(Login.p)))
                {
                    DataTable tabel = this.punctajeDataSet.punctajJoc;
                    
                    int ok=0;
                    foreach (DataRow linie in tabel.Rows)
                    {
                        if (linie.Field<string>(1) == Login.n && linie.Field<string>(2)==Login.p && linie.Field<int>(3)<scor)
                        {
                            linie["Scor"] = scor;
                            ok = 1;
                        }
                    }
                    if (ok==0)
                    {
                        DataRow linieNoua = tabel.NewRow();

                        linieNoua["ID"] = tabel.Rows.Count + 1;
                        linieNoua["Nume"] = Login.n;
                        linieNoua["Prenume"] = Login.p;
                        linieNoua["Scor"] = scor;
                        tabel.Rows.Add(linieNoua);
                    }
                    this.punctajJocTableAdapter.Update(this.punctajeDataSet.punctajJoc);
                    this.dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Descending);
                }
                final = 0;
                scor = 0;
            }
           
        }
        void Form_Close(object sender, FormClosedEventArgs e)
        {
            Joc.activare = 0;
        }
       
        private void bUsor_Click(object sender, EventArgs e)
        {
            final = 0;
            timpc = 0;
            timer1.Start();
            nivelf = 15;
            scor = 0;
            generare();
            timp=120;
            progressBar1.Maximum = timp;
            progressBar1.Value = timp;
        }

        private void bMediu_Click(object sender, EventArgs e)
        {
            final = 0;
            timpc = 0;
            timer1.Start();
            nivelf = 25;
            scor = 0;
            generare();
            timp=150;
            progressBar1.Maximum = timp;
            progressBar1.Value = timp;

        }

        private void bGreu_Click(object sender, EventArgs e)
        {

            final = 0;
            timpc = 0;
            timer1.Start();
            nivelf = 41;
            scor = 0;
            generare();
            timp = 164;
            progressBar1.Maximum = timp;
            progressBar1.Value = timp;
        }

}
}