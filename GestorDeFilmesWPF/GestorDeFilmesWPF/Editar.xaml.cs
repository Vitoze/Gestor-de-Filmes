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
    public partial class Editar : Window
    {

        SqlConnection cnn;
        private int ator_id;
        private int realizador_id;
        private int escritor_id;
        private int diretor_id;
        private int musica_id;

        public Editar()
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

        protected void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            this.Title = "Gestor de Filmes | Editar " + tabItem.ToLower();
            Console.WriteLine(tabItem);

            
            switch (tabItem)
            {
                case "ATOR":
                    ator_id = -1;
                    textBox.Clear();
                    textBox2.Clear();
                    dateTimePicker1.SelectedDate = null;
                    textBox1.Clear();
                    comboBox.Items.Clear();
                    OpenConnectionDB();                    
                    completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Atores()", comboBox);
                    cnn.Close();
                    break;
           
                case "REALIZADOR":
                    OpenConnectionDB();
                    realizador_id = -1;
                    textBox22.Clear();
                    textBox3.Clear();
                    dpRea.SelectedDate = null;
                    comboBox1.Items.Clear();
                    completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Realizador()", comboBox1);
                    cnn.Close();
                    break;

                case "ESCRITOR":
                    OpenConnectionDB();
                    escritor_id = -1;
                    textBoxe.Clear();
                    textBox1e.Clear();
                    dpEscr.SelectedDate = null;
                    textBox2e.Clear();
                    comboBox2.Items.Clear();
                    completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Escritores()", comboBox2);
                    cnn.Close();
                    break;
                case "DIRECTOR":
                    OpenConnectionDB();                    
                    diretor_id = -1;
                    textBoxd.Clear();
                    textBox1d.Clear();
                    dpdir.SelectedDate = null;
                    comboBox3.Items.Clear();
                    completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Directores()", comboBox3);
                    cnn.Close();
                    break;
                case "MÚSICA":
                    OpenConnectionDB();
                    musica_id = -1;
                    textBoxm.Clear();
                    textBox1m.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    comboBox4.Items.Clear();
                    completeDropdowns("SELECT id, titulo FROM gestordefilmes.udf_Musicas()", comboBox4);
                    cnn.Close();
                    break;

                default:
                    return;
            }
        }

        private void completeDropdowns(string query, ComboBox combobox)
        {
            SqlCommand command = new SqlCommand(query, cnn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                int count = reader.FieldCount;
                while (reader.Read())
                {
                    string item = "[" + reader.GetValue(0).ToString();

                    for (int i = 1; i < count; i++)
                    {
                        item += "] " + reader.GetValue(i).ToString();
                    }

                    combobox.Items.Add(item);
                }
            }
        }

        private void MyComboBoxAtor_OnSelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
            if (comboBox != null && comboBox.SelectedItem !=  null)
            { 
                OpenConnectionDB();
                string completeAtor = "SELECT * FROM gestordefilmes.udf_GetAtor('" + comboBox.SelectedValue.ToString().Split('[', ']')[2].Substring(1) + "')";
                SqlCommand command = new SqlCommand(completeAtor, cnn);
                SqlDataAdapter reader = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                reader.Fill(dt);
                if(dt.Rows.Count == 1)
                {
                    ator_id = Convert.ToInt32(dt.Rows[0][0]);
                    textBox.Text = dt.Rows[0][1].ToString();
                    dateTimePicker1.Text = dt.Rows[0][2].ToString().Split(' ')[0];
                    textBox1.Text = dt.Rows[0][3].ToString();
                    textBox2.Text = dt.Rows[0][4].ToString();
                }
                cnn.Close();               
            }
        }

        private void MyComboBoxEscritor_OnSelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
            if (comboBox2 != null && comboBox2.SelectedItem != null)
            {
                OpenConnectionDB();
                string completeEscritor = "SELECT * FROM gestordefilmes.udf_GetEscritor('" + comboBox2.SelectedValue.ToString().Split('[', ']')[2].Substring(1) + "')";
                SqlCommand command = new SqlCommand(completeEscritor, cnn);
                SqlDataAdapter reader = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                reader.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    escritor_id = Convert.ToInt32(dt.Rows[0][0]);
                    textBoxe.Text = dt.Rows[0][1].ToString();
                    dpEscr.Text = dt.Rows[0][2].ToString().Split(' ')[0];
                    textBox1e.Text = dt.Rows[0][3].ToString();
                    textBox2e.Text = dt.Rows[0][4].ToString();
                }
                cnn.Close();
            }
        }

        private void MyComboBoxRealizador_OnSelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
            if (comboBox1 != null && comboBox1.SelectedItem != null)
            {
                OpenConnectionDB();
                string completeRealizador = "SELECT * FROM gestordefilmes.udf_GetRealizador('" + comboBox1.SelectedValue.ToString().Split('[', ']')[2].Substring(1) + "')";
                SqlCommand command = new SqlCommand(completeRealizador, cnn);
                SqlDataAdapter reader = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                reader.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    realizador_id = Convert.ToInt32(dt.Rows[0][0]);
                    textBox22.Text = dt.Rows[0][1].ToString();
                    dpRea.Text = dt.Rows[0][2].ToString().Split(' ')[0];
                    textBox3.Text = dt.Rows[0][3].ToString();
                }
                cnn.Close();
            }
        }

        private void MyComboBoxDiretor_OnSelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
            if (comboBox3 != null && comboBox3.SelectedItem != null)
            {                
                OpenConnectionDB();
                MessageBox.Show(comboBox3.SelectedValue.ToString().Split('[', ']')[2].Substring(1));
                string completeDiretor = "SELECT * FROM gestordefilmes.udf_GetDiretor('" + comboBox3.SelectedValue.ToString().Split('[', ']')[2].Substring(1) + "')";
                SqlCommand command = new SqlCommand(completeDiretor, cnn);
                SqlDataAdapter reader = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                reader.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    diretor_id = Convert.ToInt32(dt.Rows[0][0]);
                    textBoxd.Text = dt.Rows[0][1].ToString();
                    dpdir.Text = dt.Rows[0][2].ToString().Split(' ')[0];
                    textBox1d.Text = dt.Rows[0][3].ToString();
                }
                cnn.Close();
            }
        }

        private void MyComboBoxMusica_OnSelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
            if (comboBox4 != null && comboBox4.SelectedItem != null)
            {
                OpenConnectionDB();
                string completeMusica = "SELECT * FROM gestordefilmes.udf_GetMusica('" + comboBox4.SelectedValue.ToString().Split('[', ']')[2].Substring(1) + "')";
                SqlCommand command = new SqlCommand(completeMusica, cnn);
                SqlDataAdapter reader = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                reader.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    musica_id = Convert.ToInt32(dt.Rows[0][0]);
                    textBoxm.Text = dt.Rows[0][1].ToString();
                    textBox6.Text = dt.Rows[0][2].ToString();
                    textBox1m.Text = dt.Rows[0][3].ToString();
                    textBox5.Text = dt.Rows[0][4].ToString();
                }
                cnn.Close();
            }
        }

        private void editAtor(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            Ator ator = new Ator();

            if (comboBox.SelectedValue == null || comboBox.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Campo 'Ator' é obrigatório!");
                return;
            }
            
            
            if (textBox.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Nome' é obrigatorio!");
                return;
            }
            else
                ator.nome = textBox.Text;

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Foto(url)' é obrigatorio!");
                return;
            }
            else
                ator.foto = textBox1.Text;


            DateTime? date = dateTimePicker1.SelectedDate;

            if (date.Value.ToString("yyyy-MM-dd") != null && date.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = date.Value.ToString("yyyy-MM-dd").Split('-');
                ano = Convert.ToInt32(data[0]);
                mes = Convert.ToInt32(data[1]);
                dia = Convert.ToInt32(data[2]);
                ator.datanascimento = new DateTime(ano, mes, dia);
            }

            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Descrição' é obrigatorio!");
                return;
            }
            else
                ator.biografia = textBox2.Text;

            string editAtor = "gestordefilmes.sp_EditAtor";
            SqlCommand insertQuery = new SqlCommand(editAtor, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@ator_id", ator_id);
            insertQuery.Parameters.AddWithValue("@nome", ator.nome);
            insertQuery.Parameters.AddWithValue("@url", ator.foto);
            insertQuery.Parameters.AddWithValue("@data", ator.datanascimento.ToString("u"));
            insertQuery.Parameters.AddWithValue("@bio", ator.biografia);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERRO ao editar Ator na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Ator '" + ator.nome + "' editado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            ator_id = -1;
            comboBox.Items.Clear();
            textBox.Clear();
            textBox2.Clear();
            dateTimePicker1.SelectedDate = null;
            textBox1.Clear();
            completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Atores()", comboBox);

            cnn.Close();           
        }

        private void editRealizador(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            Realizador realizador = new Realizador();

            if (comboBox1.SelectedValue == null || comboBox1.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Campo 'Realizador' é obrigatório!");
                return;
            }


            if (textBox22.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Nome' é obrigatorio!");
                return;
            }
            else
                realizador.nome = textBox22.Text;

            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Foto(url)' é obrigatorio!");
                return;
            }
            else
                realizador.foto = textBox3.Text;


            DateTime? date = dpRea.SelectedDate;

            if (date.Value.ToString("yyyy-MM-dd") != null && date.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = date.Value.ToString("yyyy-MM-dd").Split('-');
                ano = Convert.ToInt32(data[0]);
                mes = Convert.ToInt32(data[1]);
                dia = Convert.ToInt32(data[2]);
                realizador.datanascimento = new DateTime(ano, mes, dia);
            }

            string editRealizador = "gestordefilmes.sp_EditRealizador";
            SqlCommand insertQuery = new SqlCommand(editRealizador, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@realizador_id", realizador_id);
            insertQuery.Parameters.AddWithValue("@nome", realizador.nome);
            insertQuery.Parameters.AddWithValue("@url", realizador.foto);
            insertQuery.Parameters.AddWithValue("@data", realizador.datanascimento.ToString("u"));

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERRO ao editar Realizador na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            MessageBox.Show("Realizador '" + realizador.nome + "' editado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            realizador_id = -1;
            comboBox1.Items.Clear();
            textBox22.Clear();
            textBox3.Clear();
            dpRea.SelectedDate = null;
            completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Realizador()", comboBox1);

            cnn.Close();
        }

        private void editEscritor(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            Escritor escritor = new Escritor();

            if (comboBox2.SelectedValue == null || comboBox2.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Campo 'Escritor' é obrigatório!");
                return;
            }


            if (textBoxe.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Nome' é obrigatorio!");
                return;
            }
            else
                escritor.nome = textBoxe.Text;

            if (textBox1e.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Foto(url)' é obrigatorio!");
                return;
            }
            else
                escritor.foto = textBox1e.Text;


            DateTime? date = dpEscr.SelectedDate;

            if (date.Value.ToString("yyyy-MM-dd") != null && date.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = date.Value.ToString("yyyy-MM-dd").Split('-');
                ano = Convert.ToInt32(data[0]);
                mes = Convert.ToInt32(data[1]);
                dia = Convert.ToInt32(data[2]);
                escritor.datanascimento = new DateTime(ano, mes, dia);
            }

            if (textBox2e.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Descrição' é obrigatorio!");
                return;
            }
            else
                escritor.biografia = textBox2e.Text;

            string editEscritor = "gestordefilmes.EditEscritor";
            SqlCommand insertQuery = new SqlCommand(editEscritor, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@escritor_id", escritor_id);
            insertQuery.Parameters.AddWithValue("@nome", escritor.nome);
            insertQuery.Parameters.AddWithValue("@url", escritor.foto);
            insertQuery.Parameters.AddWithValue("@data", escritor.datanascimento.ToString("u"));
            insertQuery.Parameters.AddWithValue("@bio", escritor.biografia);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERRO ao editar Escritor na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("AtEscritoror '" + escritor.nome + "' editado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            escritor_id = -1;
            comboBox2.Items.Clear();
            textBoxe.Clear();
            textBox1e.Clear();
            dpEscr.SelectedDate = null;
            textBox2e.Clear();
            completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Escritores()", comboBox2);

            cnn.Close();
        }

        private void editDiretor(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            Diretor diretor = new Diretor();

            if (comboBox3.SelectedValue == null || comboBox3.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Campo 'Diretor' é obrigatório!");
                return;
            }


            if (textBoxd.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Nome' é obrigatorio!");
                return;
            }
            else
                diretor.nome = textBoxd.Text;

            if (textBox1d.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Foto(url)' é obrigatorio!");
                return;
            }
            else
                diretor.foto = textBox1d.Text;


            DateTime? date = dpdir.SelectedDate;

            if (date.Value.ToString("yyyy-MM-dd") != null && date.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = date.Value.ToString("yyyy-MM-dd").Split('-');
                ano = Convert.ToInt32(data[0]);
                mes = Convert.ToInt32(data[1]);
                dia = Convert.ToInt32(data[2]);
                diretor.datanascimento = new DateTime(ano, mes, dia);
            }

            string editDiretor = "gestordefilmes.sp_EditDiretor";
            SqlCommand insertQuery = new SqlCommand(editDiretor, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@diretor_id", diretor_id);
            insertQuery.Parameters.AddWithValue("@nome", diretor.nome);
            insertQuery.Parameters.AddWithValue("@url", diretor.foto);
            insertQuery.Parameters.AddWithValue("@data", diretor.datanascimento.ToString("u"));

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERRO ao editar Diretor na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Diretor '" + diretor.nome + "' editado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            diretor_id = -1;
            comboBox3.Items.Clear();
            textBoxd.Clear();
            textBox1d.Clear();
            dpdir.SelectedDate = null;
            completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Directores()", comboBox3);

            cnn.Close();
        }

        private void editMusica(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();

            Musica musica = new Musica();

            if (comboBox4.SelectedValue == null || comboBox4.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Campo 'Musica' é obrigatório!");
                return;
            }


            if (textBoxm.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Titulo' é obrigatorio!");
                return;
            }
            else
                musica.titulo = textBoxm.Text;

            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Campo 'URL(Youtube)' é obrigatorio!");
                return;
            }
            else
                musica.url = textBox5.Text;

            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Genero' é obrigatorio!");
                return;
            }
            else
                musica.genero = textBox6.Text;

            if (textBox1m.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Interprete' é obrigatorio!");
                return;
            }
            else
                musica.interprete = textBox1m.Text;

            string editMusica = "gestordefilmes.sp_EditMusica";
            SqlCommand insertQuery = new SqlCommand(editMusica, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@musica_id", musica_id);
            insertQuery.Parameters.AddWithValue("@titulo", musica.titulo);
            insertQuery.Parameters.AddWithValue("@url", musica.url);
            insertQuery.Parameters.AddWithValue("@genero", musica.genero);
            insertQuery.Parameters.AddWithValue("@interprete", musica.interprete);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERRO ao editar Musica na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Musica '" + musica.titulo + "' editado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            musica_id = -1;
            comboBox4.Items.Clear();
            textBoxm.Clear();
            textBox1m.Clear();
            textBox5.Clear();
            textBox6.Clear();
            completeDropdowns("SELECT id, titulo FROM gestordefilmes.udf_Musicas()", comboBox4);

            cnn.Close();
        }
    }
}
