using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static gsbFatou.ConnexionSQL;

namespace gsbFatou
{
    public partial class Form1 : Form
    {
        private MySqlCommand myCom;
        private ConnexionSql myConnexion;
        private DataTable dt;
        GestionDate date = new GestionDate();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myConnexion = ConnexionSql.getInstance("localhost", "gsb_frais", "root", "");
            myConnexion.openConnection();
            myCom = myConnexion.reqExec("select * from fichefrais where mois = " +date.moisPrecedent());

            dt = new DataTable();

            MySqlDataReader reader = myCom.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }

            while (reader.Read())
            {
                DataRow dtr = dt.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dtr[i] = reader.GetValue(i);
                }
                dt.Rows.Add(dtr);
            }
            dataGridView1.DataSource = dt;
            reader.Close();

            textBox1.Text = date.moisPrecedent();
            textBox2.Text = date.dateJour();
            textBox3.Text = date.moisSuivant();
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer timer = new Timer();
            // timer.Start();
            myConnexion = ConnexionSql.getInstance("localhost", "gsb_frais", "root", "");
            myConnexion.openConnection();
            myCom = myConnexion.reqExec("update fichefrais set idEtat = 'CL' where mois = " + date.moisPrecedent() + "and idEtat = 'CR'");

        }
    }
}
