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
    public partial class Info : Window
    {

        SqlConnection cnn;

        public Info()
        {
            InitializeComponent();
            this.Title = "Gestor de Filmes | Informações ";
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


        
        
    


    }
}
