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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestorDeFilmesWPF.Domains;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;

namespace GestorDeFilmesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection cnn;

        public MainWindow()
        {

            InitializeComponent();
            b1.Visibility = Visibility.Hidden;
            b2.Visibility = Visibility.Hidden;
            b3.Visibility = Visibility.Hidden;
            b4.Visibility = Visibility.Hidden;

            image2.Visibility = Visibility.Hidden;
            userAdd.Visibility = Visibility.Hidden;
            passAdd.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden; 

        }


        private void OpenConnectionDB()
        {
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


        private void addNewUser(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            SqlCommand insertQuery = new SqlCommand("gestordefilmes.sp_AddNewUser", cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;


            if (userAdd.Text == "" || passAdd.Password == "")
            {
                MessageBox.Show("Erro ao inserir username e/ou password.", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            insertQuery.Parameters.AddWithValue("@username", userAdd.Text);
            insertQuery.Parameters.AddWithValue("@pass", passAdd.Password);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir novo user na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                return;
            }

            cnn.Close();

            MessageBox.Show("User '"+ userAdd.Text + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            image2.Visibility = Visibility.Hidden;
            image1.Visibility = Visibility.Visible;
            userAdd.Visibility = Visibility.Hidden;
            passAdd.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;

            user.Visibility = Visibility.Visible;
            pass.Visibility = Visibility.Visible;

            button.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;

        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
           Adicionar add = new Adicionar();
           add.Show(); 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           Editar editar = new Editar();
           editar.Show();

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
           Pesquisar psq = new Pesquisar();
           psq.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
           Info inf = new Info();
           inf.Show();
        }


        private void login(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            if (user.Text == "" || pass.Password == "")
            {
                MessageBox.Show("Erro ao inserir username e/ou password.", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            SqlCommand command = new SqlCommand("SELECT * FROM gestordefilmes.udf_VerifyLogin('"+user.Text+"','"+pass.Password+"')", cnn);

            SqlDataAdapter da = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Utilizador '"+ user.Text + "' logado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

                b1.Visibility = Visibility.Visible;
                b2.Visibility = Visibility.Visible;
                b3.Visibility = Visibility.Visible;
                b4.Visibility = Visibility.Visible;

                image1.Visibility = Visibility.Hidden;
                user.Visibility = Visibility.Hidden;
                pass.Visibility = Visibility.Hidden;
                button.Visibility = Visibility.Hidden;
                button1.Visibility = Visibility.Hidden;

                label.Visibility = Visibility.Hidden;

                labe2.Visibility = Visibility.Hidden;

                this.Title = "Gestor de Filmes | Bem-Vindo "+user.Text+"!"; 

            }
            else
            {
                MessageBox.Show("Login inválido! Verifique o seu username e password", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                user.Text = "";
                pass.Clear(); 
            }

            cnn.Close();

        }

        private void register(object sender, RoutedEventArgs e)
        {
            image2.Visibility = Visibility.Visible;
            image1.Visibility = Visibility.Hidden;

            userAdd.Visibility = Visibility.Visible;
            passAdd.Visibility = Visibility.Visible;

            user.Visibility = Visibility.Hidden;
            pass.Visibility = Visibility.Hidden;

            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;

            button2.Visibility = Visibility.Visible;

        }
    }
}
