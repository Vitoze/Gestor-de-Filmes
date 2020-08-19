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
    public partial class Adicionar : Window
    {

        SqlConnection cnn;

        public Adicionar()
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

            listBox.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            comboBox5.Items.Clear();
            comboBox2.Items.Clear();
            comboBox.Items.Clear();
            comboBox4.Items.Clear();
            comboBox3f.Items.Clear();
            comboBox3.Items.Clear(); 


            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            this.Title = "Gestor de Filmes | Adicionar " + tabItem.ToLower();
            Console.WriteLine(tabItem); 

            switch (tabItem)
            {
                case "FILME":

                    var catg = new List<string> {
                        "Ação", "Animação", "Comédia", "Corridas", "Erótico", "Aventura", "Documentário","Drama"
                        ,"Fantasia" ,"Ficção" ,"Guerra" ,"Musical" ,"Policial" ,"Religioso" ,"Romance" ,"Terror"
                    };

                    catg.Sort();
                    comboBox1.ItemsSource = catg;

                    OpenConnectionDB();

                    completeCheckedListBox("SELECT id, nome FROM gestordefilmes.udf_Atores()", listBox);

                    completeCheckedListBox("SELECT id, titulo FROM gestordefilmes.udf_Musicas()", listBox2);

                    completeCheckedListBox("SELECT id, nome FROM gestordefilmes.udf_Escritores()", listBox1);

                    completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Realizador()", comboBox5);

                    completeDropdowns("SELECT id, nome FROM gestordefilmes.udf_Directores()", comboBox2);

                    completeDropdowns("SELECT * FROM gestordefilmes.udf_Companhia()", comboBox);

                    cnn.Close();

                    break;

                case "TRAILER":

                    OpenConnectionDB();

                    completeDropdowns("SELECT * FROM gestordefilmes.udf_Filme()", comboBox3);

                    cnn.Close();

                    break;

                case "PRÉMIO":

                    OpenConnectionDB();

                    completeDropdowns("SELECT * FROM gestordefilmes.udf_Filme()", comboBox3f);

                    cnn.Close();

                    break;

                case "LANÇAMENTO":

                    OpenConnectionDB();

                    completeDropdowns("SELECT * FROM gestordefilmes.udf_Filme()", comboBox4);

                    cnn.Close();

                    break;

                default:
                    return;
            }
        }




        private void adicionarAtor(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();
            string insertActor = "gestordefilmes.sp_AddActor";

            Ator ator = new Ator();

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
                MessageBox.Show("Campo 'Biografia' é obrigatorio!");
                return;
            }
            else
                ator.biografia = textBox2.Text;

            SqlCommand insertQuery = new SqlCommand(insertActor, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;


            insertQuery.Parameters.AddWithValue("@nome", ator.nome);
            insertQuery.Parameters.AddWithValue("@urlfoto", ator.foto);
            insertQuery.Parameters.AddWithValue("@datanascimento", ator.datanascimento.ToString("u"));
            insertQuery.Parameters.AddWithValue("@biografia", ator.biografia);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERRO ao inserir Ator na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            cnn.Close();
            MessageBox.Show("Ator '" + ator.nome + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBox.Clear();
            textBox2.Clear();
            dateTimePicker1.SelectedDate = null; 
            textBox1.Clear();

        }

        private void adicionarMusica(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();
            string insertMusica = "gestordefilmes.sp_AddMusica";

            Musica musica = new Musica();


            if (textBoxm.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Titulo' é obrigatorio!");
                return;
            }
            else
                musica.titulo = textBoxm.Text;

            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Genero' é obrigatorio!");
                return;
            }
            else
                musica.genero = textBox6.Text;

            if (textBox1m.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Banda/Interprete' é obrigatorio!");
                return;
            }
            else
                musica.interprete = textBox1m.Text;

            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Campo 'URL' é obrigatorio!");
                return;
            }
            else
                musica.url = textBox5.Text;


            SqlCommand insertQuery = new SqlCommand(insertMusica, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@titulo", musica.titulo);
            insertQuery.Parameters.AddWithValue("@genero", musica.genero);
            insertQuery.Parameters.AddWithValue("@interprete", musica.interprete);
            insertQuery.Parameters.AddWithValue("@url", musica.url);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {

                MessageBox.Show("ERRO ao inserir Musica na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            cnn.Close();
            MessageBox.Show("Musica '" + musica.titulo + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBox5.Clear();
            textBox1m.Clear();
            textBox6.Clear();
            textBoxm.Clear();

        }

        private void adicionarDiretor(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();
            string insertDiretor = "gestordefilmes.sp_AddDirector";

            Diretor diretor = new Diretor();

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
                dia = Convert.ToInt32(data[2]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[0]);
                diretor.datanascimento = new DateTime(ano, mes, dia);
            }

            SqlCommand insertQuery = new SqlCommand(insertDiretor, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@nome", diretor.nome);
            insertQuery.Parameters.AddWithValue("@urlfoto", diretor.foto);
            insertQuery.Parameters.AddWithValue("@datanascimento", diretor.datanascimento.ToString("u"));

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {

                MessageBox.Show("ERRO ao inserir Diretor na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            cnn.Close();
            MessageBox.Show("Diretor  '" + diretor.nome + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBoxd.Clear();
            textBox1d.Clear();
            dpdir.SelectedDate = null; 
        }

        private void adicionarEscritor(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();
            string insertEscritor = "gestordefilmes.sp_AddEscritor";

            Escritor escritor = new Escritor();

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

            Console.WriteLine();

            DateTime? date = dpEscr.SelectedDate;

            if (date.Value.ToString("yyyy-MM-dd") != null && date.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = date.Value.ToString("yyyy-MM-dd").Split('-');
                dia = Convert.ToInt32(data[2]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[0]);
                escritor.datanascimento = new DateTime(ano, mes, dia);
            }



            if (textBox2e.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Biografia' é obrigatorio!");
                return;
            }
            else
                escritor.biografia = textBox2e.Text;

            SqlCommand insertQuery = new SqlCommand(insertEscritor, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@nome", escritor.nome);
            insertQuery.Parameters.AddWithValue("@urlfoto", escritor.foto);
            insertQuery.Parameters.AddWithValue("@datanascimento", escritor.datanascimento.ToString("u"));
            insertQuery.Parameters.AddWithValue("@biografia", escritor.biografia);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {

                MessageBox.Show("ERRO ao inserir Escritor na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            cnn.Close();
            MessageBox.Show("Escritor '" + escritor.nome + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBoxe.Clear();
            textBox2e.Clear();
            dpEscr.SelectedDate = null; 
            textBoxe.Clear();
            textBox1e.Clear();
        }

        private void adicionarRealizador(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();
            string insertRealizador = "gestordefilmes.sp_AddRealizador";

            Realizador realizador = new Realizador();

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
                dia = Convert.ToInt32(data[2]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[0]);
                realizador.datanascimento = new DateTime(ano, mes, dia);
            }


            SqlCommand insertQuery = new SqlCommand(insertRealizador, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;


            insertQuery.Parameters.AddWithValue("@nome", realizador.nome);
            insertQuery.Parameters.AddWithValue("@urlfoto", realizador.foto);
            insertQuery.Parameters.AddWithValue("@datanascimento", realizador.datanascimento.ToString("u"));

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {

                MessageBox.Show("ERRO ao inserir Realizador na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
  
            cnn.Close();
            MessageBox.Show("Realizador '" + realizador.nome + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBox22.Clear();
            textBox3.Clear();
            dpRea.SelectedDate = null; 

        }


        private void completeCheckedListBox(string query, ListBox listbox)
        {
            SqlCommand command = new SqlCommand(query, cnn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                int count = reader.FieldCount;
                while (reader.Read())
                {
                    string item = "["+reader.GetValue(0).ToString();

                    for (int i = 1; i < count; i++)
                    {
                        item += "] " + reader.GetValue(i).ToString();
                    }

                    CheckBox checkbox = new CheckBox();
                    checkbox.Content = item;

                    listbox.Items.Add(checkbox);
                }
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

        private void addFilme(object sender, RoutedEventArgs e) {

            OpenConnectionDB();

            string insertFilme = "gestordefilmes.sp_AddFilme";

            Filme f = new Filme();


            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Titulo' é obrigatorio!");
                return;
            }
            else
                f.titulo = textBox4.Text;


            if (textBox7.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Descrição' é obrigatorio!");
                return;
            }
            else
                f.descricao = textBox7.Text;



            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Campo 'Categoria' é obrigatorio!");
                return;
            }
            else
                f.categoria = comboBox1.SelectedValue.ToString();




            if (rb1.IsChecked == false && rb2.IsChecked == false && rb3.IsChecked == false && rb4.IsChecked == false && rb5.IsChecked == false)
            {
                MessageBox.Show("Campo 'Classificação' é obrigatorio!");
                return;
            }
            else if (rb1.IsChecked == true)
            {
                f.classificacao = 1; 
            }
            else if (rb2.IsChecked == true)
            {
                f.classificacao = 2; 
            }
            else if (rb3.IsChecked == true)
            {
                f.classificacao = 3; 
            }
            else if (rb4.IsChecked == true)
            {
                f.classificacao = 4; 
            }
            else if (rb5.IsChecked == true)
            {
                f.classificacao = 5;
            }


            if (NumberTextBox.Text == "")
            {
                MessageBox.Show("Campo 'Duração' é obrigatorio!");
                return;
            }
            else
                f.duracao = Convert.ToInt32(NumberTextBox.Text);


            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show("Campo 'Companhia' é obrigatorio!");
                return;
            }
            f.companhia_id = Convert.ToInt32(comboBox.Text.Split('[', ']')[1]);


            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Campo 'Diretor' é obrigatorio!");
                return;
            }
            f.diretor_id = Convert.ToInt32(comboBox2.Text.Split('[', ']')[1]);


            if (comboBox5.SelectedItem == null)
            {
                MessageBox.Show("Campo 'Realizador' é obrigatorio!");
                return;
            }
            f.realizador_id = Convert.ToInt32(comboBox5.Text.Split('[', ']')[1]);



            SqlCommand insertQuery = new SqlCommand(insertFilme, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            DataTable actors = new DataTable();
            actors.Clear();
            actors.Columns.Add("id");
            foreach (CheckBox s in listBox.Items){
                if (s.IsChecked.HasValue && s.IsChecked.Value){
                    DataRow row = actors.NewRow();
                    row["id"] = s.Content.ToString().Split('[', ']')[1];
                    actors.Rows.Add(row);
                }
            }


            DataTable escritores = new DataTable();
            escritores.Clear();
            escritores.Columns.Add("id");
            foreach (CheckBox s in listBox1.Items)
            {
                if (s.IsChecked.HasValue && s.IsChecked.Value)
                {
                    DataRow row = escritores.NewRow();
                    row["id"] = s.Content.ToString().Split('[', ']')[1];
                    escritores.Rows.Add(row);
                }
            }


            //
            DataTable bandaSonora = new DataTable();
            bandaSonora.Clear();
            bandaSonora.Columns.Add("id");
            foreach (CheckBox s in listBox2.Items)
            {
                if (s.IsChecked.HasValue && s.IsChecked.Value)
                {
                    DataRow row = bandaSonora.NewRow();
                    row["id"] = s.Content.ToString().Split('[', ']')[1];
                    bandaSonora.Rows.Add(row);
                }
            }


            insertQuery.Parameters.AddWithValue("@titulo", f.titulo);
            insertQuery.Parameters.AddWithValue("@descricao", f.descricao);
            insertQuery.Parameters.AddWithValue("@categoria", f.categoria);
            insertQuery.Parameters.AddWithValue("@classificacao", f.classificacao);
            insertQuery.Parameters.AddWithValue("@duracao", f.duracao);
            insertQuery.Parameters.AddWithValue("@idcompanhia", f.companhia_id);
            insertQuery.Parameters.AddWithValue("@iddiretor", f.diretor_id);
            insertQuery.Parameters.AddWithValue("@idrealizador", f.realizador_id);
            

            SqlParameter param_genre = insertQuery.Parameters.AddWithValue("@Escritor", escritores);
            param_genre.SqlDbType = SqlDbType.Structured;
            param_genre.TypeName = "gestordefilmes.listaEscritor";

            SqlParameter param_actors = insertQuery.Parameters.AddWithValue("@Elenco", actors);
            param_actors.SqlDbType = SqlDbType.Structured;
            param_actors.TypeName = "gestordefilmes.listaElenco";
            
            SqlParameter param_writers = insertQuery.Parameters.AddWithValue("@Banda", bandaSonora);
            param_writers.SqlDbType = SqlDbType.Structured;
            param_writers.TypeName = "gestordefilmes.listaBanda";

            
            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir Filme na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message); 
                return;
            }            
            
            MessageBox.Show("Filme '" + f.titulo + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBox8.Clear();
            textBox4.Clear();
            textBox7.Clear();
            NumberTextBox.Clear(); 

            comboBox1.SelectedValue = false;
            comboBox.SelectedValue = false; 
            comboBox2.SelectedValue = false;
            comboBox5.SelectedValue = false;

            listBox.Items.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            completeCheckedListBox("SELECT id, nome FROM gestordefilmes.udf_Atores()", listBox);

            completeCheckedListBox("SELECT id, titulo FROM gestordefilmes.udf_Musicas()", listBox2);

            completeCheckedListBox("SELECT id, nome FROM gestordefilmes.udf_Escritores()", listBox1);

            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
            rb5.IsChecked = false;

            cnn.Close();
        }

        private void addnewCompanhia(object sender, RoutedEventArgs e)
        {

            if (textBox8.Text == "")
            {
                MessageBox.Show("Insira uma nova companhia para adicionar!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                OpenConnectionDB();
                string insertEscritor = "gestordefilmes.sp_AddCompanhia";

                SqlCommand insertQuery = new SqlCommand(insertEscritor, cnn);
                insertQuery.CommandType = CommandType.StoredProcedure;

                insertQuery.Parameters.AddWithValue("@nome", textBox8.Text);

                try
                {
                    insertQuery.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("ERRO ao inserir Companhia na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Companhia '" + textBox8.Text + "' adicionada com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

                comboBox.Items.Clear();
                completeDropdowns("SELECT * FROM gestordefilmes.udf_Companhia()", comboBox);
                cnn.Close();

                textBox8.Clear(); 

            }
        }

        private void addTrailerAoFilme(object sender, RoutedEventArgs e)
        {


            OpenConnectionDB();

            string insertFilme = "gestordefilmes.sp_AddTrailer";

            Trailer t = new Trailer();

            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Campo 'Filme' é obrigatorio!");
                return;
            }
            t.filme_id = Convert.ToInt32(comboBox3.Text.Split('[', ']')[1]);




            if (textBox11.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Titulo' é obrigatorio!");
                return;
            }
            else
                t.titulo = textBox11.Text;


            if (textBox10.Text.Length == 0)
            {
                MessageBox.Show("Campo 'URL' é obrigatorio!");
                return;
            }
            else
                t.url = textBox10.Text;


            if (textBox9.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Duracao' é obrigatorio!");
                return;
            }
            else
                t.duracao = Convert.ToInt32(textBox9.Text);


            DateTime? date = trailDat.SelectedDate;

            if (date.Value.ToString("yyyy-MM-dd") != null && date.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = date.Value.ToString("yyyy-MM-dd").Split('-');
                dia = Convert.ToInt32(data[2]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[0]);
                t.data = new DateTime(ano, mes, dia);
            }


            if (textBox12.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Idioma' é obrigatorio!");
                return;
            }
            else
                t.idioma = textBox12.Text; 




            SqlCommand insertQuery = new SqlCommand(insertFilme, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;


            insertQuery.Parameters.AddWithValue("@titulo", t.titulo);
            insertQuery.Parameters.AddWithValue("@duracao", t.duracao);
            insertQuery.Parameters.AddWithValue("@data", t.data.ToString("u"));
            insertQuery.Parameters.AddWithValue("@url", t.url);
            insertQuery.Parameters.AddWithValue("@idioma", t.idioma);
            insertQuery.Parameters.AddWithValue("@idfilme", t.filme_id);


            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir Trailer na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                return;
            }

            cnn.Close();

            MessageBox.Show("Trailer '" + t.titulo + "' foi adicionao ao filme '"+ comboBox3.Text.Split('[', ']')[1] + "' com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);



            textBox12.Clear();
            trailDat.SelectedDate = null; 
            textBox10.Clear();
            textBox9.Clear();
            textBox11.Clear();
            textBox13.Clear();

        }

        private void addPremioAoFilme(object sender, RoutedEventArgs e)
        {

            OpenConnectionDB();

            Premio p = new Premio();

            if (comboBox3f.SelectedItem == null)
            {
                MessageBox.Show("Campo 'Filme' é obrigatorio!");
                return;
            }
            p.filme_id = Convert.ToInt32(comboBox3f.Text.Split('[', ']')[1]);


            if (textBox11f.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Ano' é obrigatorio!");
                return;
            }else if (!textBox11f.Text.All(char.IsDigit))
            {
                MessageBox.Show("Campo 'Ano' apenas pode possuir digitos!");
                return;
            }
            else
                p.ano = Convert.ToInt32(textBox11f.Text);


            if (textBox10f.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Tipo' é obrigatorio!");
                return;
            }
            else
                p.tipo = textBox10f.Text;


            if (textBox9f.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Descrição' é obrigatorio!");
                return;
            }
            else
                p.descricao = textBox9f.Text; 


            string queryInsertSQLDML = "INSERT INTO gestordefilmes.premio(idfilme, ano, tipo, descricao) VALUES(@idfilme, @ano, @tipo, @descricao)";

            SqlCommand insertQuery = new SqlCommand(queryInsertSQLDML, cnn);
            insertQuery.Parameters.AddWithValue("@idfilme", p.filme_id);
            insertQuery.Parameters.AddWithValue("@ano", p.ano);
            insertQuery.Parameters.AddWithValue("@tipo", p.tipo);
            insertQuery.Parameters.AddWithValue("@descricao", p.descricao);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir Prémio na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                return;
            }

            cnn.Close();
            MessageBox.Show("Prémio '" + p.tipo + "' foi adicionao ao filme '" + comboBox3f.Text.Split('[', ']')[1] + "' com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBox9f.Clear();
            textBox10f.Clear();
            textBox11f.Clear();
            
        }

        private void addLancamwentoaumfilme(object sender, RoutedEventArgs e)
        {
            OpenConnectionDB();
            string insertLancamento = "gestordefilmes.sp_Addlancamento";


            Lancamento l = new Lancamento();

            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Campo 'Filme' é obrigatorio!");
                return;
            }
            l.filme_id = Convert.ToInt32(comboBox4.Text.Split('[', ']')[1]);


            if (textBox13.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Titulo' é obrigatorio!");
                return;
            }
            else
                l.titulo = textBox13.Text;


            DateTime? date = dplanc.SelectedDate;

            if (date.Value.ToString("yyyy-MM-dd") != null && date.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = date.Value.ToString("yyyy-MM-dd").Split('-');
                dia = Convert.ToInt32(data[2]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[0]);
                l.data = new DateTime(ano, mes, dia);
            }

            if (textBox14.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Pais' é obrigatorio!");
                return;
            }
            else
                l.pais = textBox14.Text;

            SqlCommand insertQuery = new SqlCommand(insertLancamento, cnn);
            insertQuery.CommandType = CommandType.StoredProcedure;

            insertQuery.Parameters.AddWithValue("@titulo", l.titulo);
            insertQuery.Parameters.AddWithValue("@data", l.data.ToString("u"));
            insertQuery.Parameters.AddWithValue("@pais", l.pais);
            insertQuery.Parameters.AddWithValue("@idfilme", l.filme_id);


            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir Lançamento na Base de Dados", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                return;
            }

            cnn.Close();

            MessageBox.Show("Lançamento '" + l.titulo + "' foi adicionao ao filme '" + comboBox4.Text.Split('[', ']')[1] + "' com sucesso!", "Gestor de Filmes", MessageBoxButton.OK, MessageBoxImage.Information);

            textBox14.Clear(); 
            dplanc.SelectedDate = null;
            textBox13.Clear(); 

        }
    }
}
