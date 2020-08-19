using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeFilmesWFA
{
    public partial class Form : System.Windows.Forms.Form
    {
        SqlConnection cnn;
        Dictionary<int, string> atores = new Dictionary<int, string>();
        Dictionary<int, string> escritores = new Dictionary<int, string>();
        Dictionary<int, string> musicas = new Dictionary<int, string>();
        Dictionary<int, string> diretores = new Dictionary<int, string>();
        Dictionary<int, string> realizadores = new Dictionary<int, string>();
        Dictionary<int, string> companhia = new Dictionary<int, string>();

        public Form()
        {
            InitializeComponent();

        }


        private void OpenConnectionDB()
        {

            cnn = Connection.getConnection();
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                return;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            panel10.Show();
        }

        // Adicionar Filme
        private void button10_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Titulo Field is required");
                return;
            }
            else
                filme.titulo = textBox1.Text;


            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Titulo Field is required");
                return;
            }
            else
                filme.descricao = richTextBox1.Text;

            try
            {
                filme.duracao = Convert.ToInt32(numericUpDown1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Argument Duracao takes integers only");
                return;
            }

            try
            {
                filme.classificacao = Convert.ToInt32(numericUpDown2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Argument Classificação takes integers only");
                return;
            }
            
            if (comboBox1.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Diretor Field is required");
                return;
            }
            else
                filme.diretor_id =  diretores.Keys.ToArray()[diretores.Values.ToList().IndexOf(comboBox1.SelectedItem.ToString())];

            if (comboBox2.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Realizador Field is required");
                return;
            }
            else
                filme.realizador_id = realizadores.Keys.ToArray()[realizadores.Values.ToList().IndexOf(comboBox2.SelectedItem.ToString())];

            if (comboBox3.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Companhia Field is required");
                return;
            }
            else
                filme.companhia_id = companhia.Keys.ToArray()[companhia.Values.ToList().IndexOf(comboBox3.SelectedItem.ToString())];

            string insert = "INSERT INTO gestordefilmes.filme(titulo, descricao, classificacao, duracao, idcompanhia, iddiretor, idrealizador) VALUES(@titulo, @descricao, @classificacao, @duracao, @idcompanhia, @iddiretor, @idrealizador)";
            SqlCommand insertQuery = new SqlCommand(insert, cnn);
            insertQuery.Parameters.AddWithValue("@titulo", filme.titulo);
            insertQuery.Parameters.AddWithValue("@descricao", filme.descricao);
            insertQuery.Parameters.AddWithValue("@classificacao", filme.classificacao);
            insertQuery.Parameters.AddWithValue("@duracao", filme.duracao);
            insertQuery.Parameters.AddWithValue("@idcompanhia", filme.companhia_id);
            insertQuery.Parameters.AddWithValue("@iddiretor", filme.diretor_id);
            insertQuery.Parameters.AddWithValue("@idrealizador", filme.realizador_id);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error on inserting Filme to database");
                return;
            }

            List<string> listacheck = checkedListBox1.CheckedItems.OfType<string>().ToList();
            insert = "INSERT INTO gestordefilmes.representadopor(idfilme, idator) VALUES(@idfilme, @idator)";
            insertQuery = new SqlCommand(insert, cnn);
            for (int i = 0; i < listacheck.Count; i++)
            {
                insertQuery.Parameters.AddWithValue("@idfilme", obterFilmeID(filme.titulo));
                insertQuery.Parameters.AddWithValue("@idator", atores.Keys.ToArray()[atores.Values.ToList().IndexOf(listacheck[i])]);
            }

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error on inserting Atores do Filme to database");
                return;
            }

            listacheck = checkedListBox2.CheckedItems.OfType<string>().ToList();
            insert = "INSERT INTO gestordefilmes.escritopor(idfilme, idescritor) VALUES(@idfilme, @idescritor)";
            insertQuery = new SqlCommand(insert, cnn);
            for (int i = 0; i < listacheck.Count; i++)
            {
                insertQuery.Parameters.AddWithValue("@idfilme", obterFilmeID(filme.titulo));
                insertQuery.Parameters.AddWithValue("@idescritor", escritores.Keys.ToArray()[escritores.Values.ToList().IndexOf(listacheck[i])]);
            }

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error on inserting Escritores do Filme to database");
                return;
            }

            listacheck = checkedListBox3.CheckedItems.OfType<string>().ToList();
            insert = "INSERT INTO gestordefilmes.musicasdofilme(idfilme, idmusica) VALUES(@idfilme, @idmusica)";
            insertQuery = new SqlCommand(insert, cnn);
            for (int i = 0; i < listacheck.Count; i++)
            {
                insertQuery.Parameters.AddWithValue("@idfilme", obterFilmeID(filme.titulo));
                insertQuery.Parameters.AddWithValue("@idmusica", musicas.Keys.ToArray()[musicas.Values.ToList().IndexOf(listacheck[i])]);
            }

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error on inserting Musicas do Filme to database");
                return;
            }

            cnn.Close();
            MessageBox.Show("Adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Filme
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
        }

        // Adicionar Ator
        private void button12_Click(object sender, EventArgs e)
        {
            OpenConnectionDB(); 
            string insertActor = "gestordefilmes.sp_AddActor";

            Ator ator = new Ator();

            if (textBox8.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Nome' é obrigatorio!");
                return;
            }
            else
                ator.nome = textBox8.Text;

            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Foto(url)' é obrigatorio!");
                return;
            }
            else
                ator.foto = textBox6.Text;

            if (textBox5 != null && textBox5.Text != "" && textBox5.Text.Length == 10)
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = textBox5.Text.Split('-');
                dia = Convert.ToInt32(data[0]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[2]);
                ator.datanascimento = new DateTime(ano, mes, dia);
            }

            if (richTextBox2.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Biografia' é obrigatorio!");
                return;
            }
            else
                ator.biografia = richTextBox2.Text;

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
                MessageBox.Show("ERRO ao inserir Ator na Base de Dados");
                return;
            }

            cnn.Close();
            MessageBox.Show("Ator '"+ ator.nome + "' adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Ator
        private void button13_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox6.Text = "";
            textBox5.Text = "DD-MM-AAAA";
            richTextBox2.Text = "";
        }
        
        // Adicionar Diretor
        private void button14_Click(object sender, EventArgs e)
        {

            OpenConnectionDB();
            string insertDiretor = "gestordefilmes.sp_AddDirector";

            Diretor diretor = new Diretor();

            if (textBox10.Text.Length == 0)
            {
                MessageBox.Show("Nome Field is required");
                return;
            }
            else
                diretor.nome = textBox10.Text;

            if (textBox9.Text.Length == 0)
            {
                MessageBox.Show("Foto(Url) Field is required");
                return;
            }
            else
                diretor.foto = textBox9.Text;

            if (dateTimePicker3.Value.ToString("yyyy-MM-dd") != null && dateTimePicker3.Value.ToString("yyyy-MM-dd") != "" )
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = dateTimePicker3.Value.ToString("yyyy-MM-dd").Split('-');
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

                MessageBox.Show("ERRO ao inserir Diretor na Base de Dados");

                return;
            }

            cnn.Close();
            MessageBox.Show("Adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Diretor
        private void button15_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox9.Text = "";
        }

        // Adicionar Realizador
        private void button16_Click(object sender, EventArgs e)
        {

            OpenConnectionDB();
            string insertRealizador = "gestordefilmes.sp_AddRealizador";

            Realizador realizador = new Realizador();

            if (textBox13.Text.Length == 0)
            {
                MessageBox.Show("Nome Field is required");
                return;
            }
            else
                realizador.nome = textBox13.Text;

            if (textBox12.Text.Length == 0)
            {
                MessageBox.Show("Foto(Url) Field is required");
                return;
            }
            else
                realizador.foto = textBox12.Text;

            if (dateTimePicker3.Value.ToString("yyyy-MM-dd") != null && dateTimePicker3.Value.ToString("yyyy-MM-dd") != "" )
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = dateTimePicker3.Value.ToString("yyyy-MM-dd").Split('-');
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

                MessageBox.Show("ERRO ao inserir Realizador na Base de Dados",  "Gestor de Filmes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            cnn.Close();
            MessageBox.Show("Realizador '"+ realizador.nome + "' adicionado com sucesso!", "Gestor de Filmes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Realizador
        private void button17_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox12.Text = "";
        }

        // Adicionar Escritor
        private void button18_Click(object sender, EventArgs e)
        {

            OpenConnectionDB();
            string insertEscritor = "gestordefilmes.sp_AddEscritor";

            Escritor escritor = new Escritor();

            if (textBox16.Text.Length == 0)
            {
                MessageBox.Show("Nome Field is required");
                return;
            }
            else
                escritor.nome = textBox16.Text;

            if (textBox15.Text.Length == 0)
            {
                MessageBox.Show("Foto(Url) Field is required");
                return;
            }
            else
                escritor.foto = textBox15.Text;

            Console.WriteLine();

            
            if (dateTimePicker2.Value.ToString("yyyy-MM-dd") != null && dateTimePicker2.Value.ToString("yyyy-MM-dd") != "")
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = dateTimePicker2.Value.ToString("yyyy-MM-dd").Split('-');
                dia = Convert.ToInt32(data[2]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[0]);
                escritor.datanascimento = new DateTime(ano, mes, dia);
            }
            


            if (richTextBox3.Text.Length == 0)
            {
                MessageBox.Show("Biografia Field is required");
                return;
            }
            else
                escritor.biografia = richTextBox3.Text;

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
                MessageBox.Show("ERRO ao inserir Escritor na Base de Dados");

                return;
            }

            cnn.Close();
            MessageBox.Show("Escritor '"+ escritor.nome + "' adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Escritor
        private void button19_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
            textBox15.Text = "";
            richTextBox3.Text = "";
        }

        // Adicionar Musica
        private void button20_Click(object sender, EventArgs e)
        {
            OpenConnectionDB();
            string insertMusica = "gestordefilmes.sp_AddMusica";

            Musica musica = new Musica();


            if (textBox19.Text.Length == 0)
            {
                MessageBox.Show("Titulo Field is required");
                return;
            }
            else
                musica.titulo = textBox19.Text;

            if (textBox18.Text.Length == 0)
            {
                MessageBox.Show("Genero Field is required");
                return;
            }
            else
                musica.genero = textBox18.Text;

            if (textBox17.Text.Length == 0)
            {
                MessageBox.Show("Interprete Field is required");
                return;
            }
            else
                musica.interprete = textBox17.Text;
            
            if (textBox20.Text.Length == 0)
            {
                MessageBox.Show("Url Field is required");
                return;
            }
            else
                musica.url = textBox20.Text;


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

                MessageBox.Show("ERRO ao inserir Musica na Base de Dados");

                return;
            }

            cnn.Close();
            MessageBox.Show("'" + musica.titulo + "' adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Musica
        private void button21_Click(object sender, EventArgs e)
        {
            textBox19.Text = "";
            textBox18.Text = "";
            textBox17.Text = "DD-MM-AAAA";
            textBox20.Text = "";
        }

        // Adicionar Trailer
        private void button22_Click(object sender, EventArgs e)
        {
            Trailer trailer = new Trailer();

            if (textBox24.Text.Length == 0)
            {
                MessageBox.Show("Titulo Field is required");
                return;
            }
            else
                trailer.titulo = textBox24.Text;

            try
            {
                trailer.duracao = Convert.ToInt32(numericUpDown3.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Argument Duracao takes integers only");
                return;
            }

            if (textBox22 != null && textBox22.Text != "" && textBox22.Text.Length == 10)
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = textBox22.Text.Split('-');
                dia = Convert.ToInt32(data[0]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[2]);
                trailer.data = new DateTime(ano, mes, dia);
            }

            if (textBox23.Text.Length == 0)
            {
                MessageBox.Show("Idioma Field is required");
                return;
            }
            else
                trailer.idioma = textBox23.Text;

            if (textBox21.Text.Length == 0)
            {
                MessageBox.Show("Foto(Url) Field is required");
                return;
            }
            else
                trailer.foto = textBox21.Text;

            string insert = "INSERT INTO gestordefilmes.trailer(titulo, duracao, data, url, idioma) VALUES(@titulo, @duracao, @data, @url, @idioma)";
            SqlCommand insertQuery = new SqlCommand(insert, cnn);
            insertQuery.Parameters.AddWithValue("@titulo", trailer.titulo);
            insertQuery.Parameters.AddWithValue("@duracao", trailer.duracao);
            insertQuery.Parameters.AddWithValue("@data", trailer.data);
            insertQuery.Parameters.AddWithValue("@url", trailer.foto);
            insertQuery.Parameters.AddWithValue("@idioma", trailer.idioma);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error on inserting Trailer to database");
                return;
            }

            cnn.Close();
            MessageBox.Show("Adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Trailer
        private void button23_Click(object sender, EventArgs e)
        {
            textBox24.Text = "";
            numericUpDown3.Text = "0";
            textBox22.Text = "DD-MM-AAAA";
            textBox23.Text = "";
            textBox21.Text = "";
        }

        // Adicionar Premio
        private void button24_Click(object sender, EventArgs e)
        {
            Premio premio = new Premio();

            if (textBox28.Text.Length == 0)
            {
                MessageBox.Show("Tipo Field is required");
                return;
            }
            else
                premio.tipo = textBox28.Text;

            try
            {
                premio.ano = Convert.ToInt32(numericUpDown4.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Argument Ano takes integers only");
                return;
            }

            if (richTextBox4.Text.Length == 0)
            {
                MessageBox.Show("Descrição Field is required");
                return;
            }
            else
                premio.descricao = richTextBox4.Text;

            string insert = "INSERT INTO gestordefilmes.premio(tipo, ano, descricao) VALUES(@tipo, @ano, @descricao)";
            SqlCommand insertQuery = new SqlCommand(insert, cnn);
            insertQuery.Parameters.AddWithValue("@titulo", premio.tipo);
            insertQuery.Parameters.AddWithValue("@duracao", premio.ano);
            insertQuery.Parameters.AddWithValue("@data", premio.descricao);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error on inserting Premio to database");
                return;
            }

            cnn.Close();
            MessageBox.Show("Adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Premio
        private void button25_Click(object sender, EventArgs e)
        {
            textBox28.Text = "";
            numericUpDown4.Text = "0";
            richTextBox4.Text = "";
        }

        // Adicionar Lançamento
        private void button26_Click(object sender, EventArgs e)
        {
            Lancamento lancamento = new Lancamento();

            if (textBox26.Text.Length == 0)
            {
                MessageBox.Show("Titulo Field is required");
                return;
            }
            else
                lancamento.titulo = textBox26.Text;

            if (textBox25 != null && textBox25.Text != "" && textBox25.Text.Length == 10)
            {
                int dia, mes, ano;
                string[] data = new string[3];
                data = textBox25.Text.Split('-');
                dia = Convert.ToInt32(data[0]);
                mes = Convert.ToInt32(data[1]);
                ano = Convert.ToInt32(data[2]);
                lancamento.data = new DateTime(ano, mes, dia);
            }


            if (textBox29.Text.Length == 0)
            {
                MessageBox.Show("Descrição Field is required");
                return;
            }
            else
                lancamento.pais = textBox29.Text;

            string insert = "INSERT INTO gestordefilmes.lancamento(titulo, data, pais) VALUES(@titulo, @data, @pais)";
            SqlCommand insertQuery = new SqlCommand(insert, cnn);
            insertQuery.Parameters.AddWithValue("@titulo", lancamento.titulo);
            insertQuery.Parameters.AddWithValue("@duracao", lancamento.data);
            insertQuery.Parameters.AddWithValue("@data", lancamento.pais);

            try
            {
                insertQuery.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error on inserting Lancamento to database");
                return;
            }

            cnn.Close();
            MessageBox.Show("Adicionado com sucesso!");
            panel10.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Cancelar Lancamento
        private void button27_Click(object sender, EventArgs e)
        {
            textBox26.Text = "";
            textBox25.Text = "DD-MM-AAAA";
            textBox29.Text = "";
        }

        // Panel Adicionar Filme
        private void button1_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            /*
            atores.Clear();
            escritores.Clear();
            musicas.Clear();
            diretores.Clear();
            realizadores.Clear();
            companhia.Clear();
            atores = printCheckedListBox("ator", "id", "nome", checkedListBox1);
            escritores = printCheckedListBox("escritor", "id", "nome", checkedListBox2);
            musicas = printCheckedListBox("musicas", "id", "titulo", checkedListBox3);
            diretores = printComboBox("diretor", "id", "nome", comboBox1);
            realizadores = printComboBox("realizador", "id", "nome", comboBox2);
            companhia = printComboBox("companhia", "id", "nome", comboBox3);
        */

            OpenConnectionDB();
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();


            string getActorsQuery = "SELECT id, nome FROM gestordefilmes.udf_Atores()";
            completeCheckedListBox(getActorsQuery, checkedListBox1);
           // checkedListBox1.Sorted = true;

            string getMusicasQuery = "SELECT id, titulo FROM gestordefilmes.udf_Musicas()";
            completeCheckedListBox(getMusicasQuery, checkedListBox3);

            string getEscritorQuery = "SELECT id, nome FROM gestordefilmes.udf_Escritores()";
            completeCheckedListBox(getEscritorQuery, checkedListBox2);

            string getRealizadorQuery = "SELECT id, nome FROM gestordefilmes.udf_Realizador()";
            completeDropdowns(getRealizadorQuery, comboBox2);

            string getDiretorQuery = "SELECT id, nome FROM gestordefilmes.udf_Directores()";
            completeDropdowns(getDiretorQuery, comboBox1);

        }

        // Panel Adicionar Ator
        private void button3_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;

            textBox8.Text = "";
            textBox6.Text = "";
            textBox5.Text = "DD-MM-AAAA";
            richTextBox2.Text = "";
        }

        // Panel Adicionar Diretor
        private void button4_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Panel Adicionar Realizador
        private void button5_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Panel Adicionar Escritor
        private void button6_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Panel Adicionar Banda Sonora
        private void button7_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Panel Adicionar Trailer
        private void button8_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        // Panel Adicionar Premio
        private void button2_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            panel9.Visible = false;
        }

        // Panel Adicionar Data de Lançamento
        private void button9_Click(object sender, EventArgs e)
        {
            panel10.Show();
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            panel9.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }      

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }




        // preencher checkedListBox ao adicionar filme (atores , musicas , )
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

                    listbox.Items.Add(item);
                }
            }

        }


        // preencher dropdwons ao adicionar filme (directores, escritores)
        private void completeDropdowns(string query, ComboBox combobox)
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

                    combobox.Items.Add(item);
                }
            }
        }


        private int obterFilmeID(string nome)
        {
            string cmd = "SELECT id FROM gestordefilmes.filme WHERE nome = \"" + nome + "\"";
            SqlCommand insertQuery = new SqlCommand(cmd, cnn);
            SqlDataReader reader = insertQuery.ExecuteReader();
            return Convert.ToInt32(reader.GetValue(0));
        }
    }
}
