using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodaj_200_radnika
{
    public partial class Form1 : Form
    {
        private Random R = new Random();
        private OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Cvijander\source\repos\Relja napredni kurs\Podaci o radnicima (.Net)\Podaci o radnicima (.Net)\bin\Debug\baza.mdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Im = new List<string>();
            List<string> Pr = new List<string>();

            Im.Add("Ana"); Im.Add("Milica"); Im.Add("Bojana");
            Im.Add("Marija"); Im.Add("Tijana"); Im.Add("Igor");
            Im.Add("Uros"); Im.Add("Bojan"); Im.Add("Milos");
            Im.Add("Marko"); Pr.Add("Popovic"); Pr.Add("Jokic");
            Pr.Add("Markov"); Pr.Add("Mitrovic"); Pr.Add("Majstorovic");
            Pr.Add("Popov"); Pr.Add("Lazetic"); Pr.Add("Lucic");
            Pr.Add("Tomic"); Pr.Add("Stanojkovic");

            try
            {
                con.Open();
                int pocetnaSifra = int.Parse(textBox1.Text);
                for (int i = 0; i < 200; i++)
                {
                    int sif = pocetnaSifra + i;
                    string ime = Im[R.Next(0, 10)];
                    string prezime = Pr[R.Next(0, 10)];
                    DateTime dat = DateTime.Now.AddDays(-1 * R.Next(10, 2000));
                    int plata = R.Next(15000, 150000);
                    int premija = R.Next(0, 30000);

                    string tekstKomande = "insert into Radnik values (" + sif + ",'" + ime + "','" + prezime + "','" + dat.ToString("dd/MM/yyyy") + "'," + plata + "," + premija + " )";
                    OleDbCommand komanda = new OleDbCommand(tekstKomande, con);
                    komanda.ExecuteNonQuery();
                }
                MessageBox.Show("Uspesno je upisano 200 radnika.");
                con.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom unosa radnika " + x.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}