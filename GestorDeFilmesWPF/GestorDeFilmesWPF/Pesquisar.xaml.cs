using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GestorDeFilmesWPF.Domains;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;



namespace GestorDeFilmesWPF
{
    /// <summary>
    /// Interaction logic for Adicionar.xaml
    /// </summary>
    public partial class Pesquisar : Window
    {

        SqlConnection cnn;

        public Pesquisar()
        {
            InitializeComponent();

        }

        private void OpenConnectionDB(){

            cnn = ConectarBD.getConnection();
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message); 
                return;
            }
        }



        protected void tabItem1_Clicked(object sender, MouseButtonEventArgs e)
        {


           
        }


        private void MyComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }


        protected void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            this.Title = "Gestor de Filmes | Pesquisar " + tabItem.ToLower();
            Console.WriteLine(tabItem);

            
            switch (tabItem)
            {
                case "ATOR":
                    OpenConnectionDB();

                    SqlCommand command = new SqlCommand("SELECT * from gestordefilmes.udf_AtoresSemURL()", cnn);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Actors");
                    sda.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    cnn.Close();

                    break;

           
                case "REALIZADOR":

                    OpenConnectionDB();

                    SqlCommand command2 = new SqlCommand("SELECT * from gestordefilmes.udf_Realizador()", cnn);
                    SqlDataAdapter sda2 = new SqlDataAdapter(command2);
                    DataTable dt2 = new DataTable("Realizador");
                    sda2.Fill(dt2);
                    dataGrid1_Copy.ItemsSource = dt2.DefaultView;

                    cnn.Close();

                    break;

                case "ESCRITOR":

                    OpenConnectionDB();

                    SqlCommand command4 = new SqlCommand("SELECT * from gestordefilmes.udf_Escritores()", cnn);
                    SqlDataAdapter sda4 = new SqlDataAdapter(command4);
                    DataTable dt4 = new DataTable("Escritor");
                    sda4.Fill(dt4);
                    dataGrid2.ItemsSource = dt4.DefaultView;

                    cnn.Close();


                    break;
                case "DIRECTOR":

                    OpenConnectionDB();

                    SqlCommand command3 = new SqlCommand("SELECT * from gestordefilmes.udf_Directores()", cnn);
                    SqlDataAdapter sda3 = new SqlDataAdapter(command3);
                    DataTable dt3 = new DataTable("Diretor");
                    sda3.Fill(dt3);
                    dataGrid3.ItemsSource = dt3.DefaultView;

                    cnn.Close();

                    break;
                case "MÚSICA":

                    OpenConnectionDB();

                    SqlCommand command1 = new SqlCommand("SELECT * from gestordefilmes.udf_Musicas()", cnn);
                    SqlDataAdapter sda1 = new SqlDataAdapter(command1);
                    DataTable dt1 = new DataTable("Musicas");
                    sda1.Fill(dt1);
                    dataGrid4.ItemsSource = dt1.DefaultView;

                    cnn.Close();

                    break;

                case "FILME":

                    OpenConnectionDB();

                    SqlCommand command11 = new SqlCommand("SELECT * from gestordefilmes.udf_FilmeAll()", cnn);
                    SqlDataAdapter sda11 = new SqlDataAdapter(command11);
                    DataTable dt11 = new DataTable("Filmes");
                    sda11.Fill(dt11);
                    dataGrid.ItemsSource = dt11.DefaultView;

                    cnn.Close();

                    break;


                case "PRÉMIO":

                    OpenConnectionDB();

                    SqlCommand command112 = new SqlCommand("SELECT * from gestordefilmes.udf_GetPremios()", cnn);
                    SqlDataAdapter sda112 = new SqlDataAdapter(command112);
                    DataTable dt112 = new DataTable("Premios");
                    sda112.Fill(dt112);
                    dataGrid6.ItemsSource = dt112.DefaultView;

                    cnn.Close();

                    break;

                default:
                    return;
            }


            

        }


        private void LoadData(string query)
        {

        }

        //Atores
        private void button_Click(object sender, RoutedEventArgs e)
        {


            OpenConnectionDB(); 

            SqlCommand cmd = new SqlCommand("gestordefilmes.sp_PesquisarAtor", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", textBox.Text);
            cmd.Parameters.AddWithValue("@biografia", textBox1.Text);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Actors");
                sda.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("Error on searching Actors in the database");
                return;
            }
            cnn.Close(); 

        }


        //Musicas
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            OpenConnectionDB();

            SqlCommand cmd = new SqlCommand("gestordefilmes.sp_PesquisarMusicas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@titulo", textBoxm.Text);
            cmd.Parameters.AddWithValue("@genero", textBox6.Text);
            cmd.Parameters.AddWithValue("@interprete", textBox1m.Text);


            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Musicas");
                sda.Fill(dt);
                dataGrid4.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("Error on searching Musics in the database");
                return;
            }
            cnn.Close();


        }

        //Realizador
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            SqlCommand cmd = new SqlCommand("gestordefilmes.sp_PesquisarRealizador", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nome", textBox22.Text);



            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Realizador");
                sda.Fill(dt);
                dataGrid1_Copy.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("Error on searching Realizador in the database");
                return;
            }
            cnn.Close();

        }


        //Escritor
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            SqlCommand cmd = new SqlCommand("gestordefilmes.sp_PesquisarEscritor", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", textBoxe.Text);
            cmd.Parameters.AddWithValue("@biografia", textBox2.Text);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Escritor");
                sda.Fill(dt);
                dataGrid2.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("Error on searching Escritor in the database");
                return;
            }
            cnn.Close();
        }

        //Diretor
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            SqlCommand cmd = new SqlCommand("gestordefilmes.sp_PesquisarDiretor", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nome", textBoxd.Text);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Diretor");
                sda.Fill(dt);
                dataGrid3.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("Error on searching Diretor in the database");
                return;
            }
            cnn.Close();
        }

        //Filme
        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
