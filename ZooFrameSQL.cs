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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace zoooframe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            // connection string um auf die datenbank zuzugreifen und die ganzen tabellen einzulesen
            string connectionString = ConfigurationManager.ConnectionStrings["zoooframe.Properties.Settings.wbConnectionString"].ConnectionString;

            // damit der manager weiß zu welcher datenbank er zugreifen soll 
            sqlConnection = new SqlConnection(connectionString);
            ShowZoos();
            ShowAllAnimals();
        }
        // methode damit wir zugang zu den ganzen zoos erhalten
        public void ShowZoos()
        {
            try
            {
                // zugang zu zoo
                string query = " select * from Zoos";
                // adapter ist da damit wir objecte daraus machen können mit dennen wir in c# arbeiten können
                // new adapter nutzt query auf die connection und den nutzen wir 
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    // wir erstellen einen datentabelle und füllen den mit dem adapter
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);
                    //WElche Infos sollen in der Listbox angezeigt werden
                    // list box in der main windowdatei bennen und hier darauf zugreifen
                    listZoos.DisplayMemberPath = "Location";
                    // Welcher wert soll gegeben werden wenn ein item in der listbox ausgewählt wird
                    listZoos.SelectedValuePath = "Id";

                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }
        public void ShowAnimals()
        {
            // Wenn zoo gelöscht wird, versucht er noch auf die tiere zuzugreifen also if ,,,, return aus der show methode
            if (listZoos.SelectedValue == null)
            {
                return;
            }
            try
            {
                // zugang zu zoo
                string query = " select * from Animal a inner join ZooAnimal za on a.Id = za.AnimalId where za.ZoosId = @ZoosId";
                // adapter ist da damit wir objecte daraus machen können mit dennen wir in c# arbeiten können
                // new adapter nutzt query auf die connection und den nutzen wir 
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZoosId", listZoos.SelectedValue);
                    // wir erstellen einen datentabelle und füllen den mit dem adapter
                    DataTable AnimalTable = new DataTable();
                    sqlDataAdapter.Fill(AnimalTable);


                    //WElche Infos sollen in der Listbox angezeigt werden
                    // list box in der main windowdatei bennen und hier darauf zugreifen
                    Animals.DisplayMemberPath = "Name";
                    // Welcher wert soll gegeben werden wenn ein item in der listbox ausgewählt wird
                    Animals.SelectedValuePath = "Id";

                    Animals.ItemsSource = AnimalTable.DefaultView;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }
        // Fehler gemacht. bei zoolist in mainwindow die selectet change machen nicht in animals

        private void Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAnimals();
        }

        public void ShowAllAnimals()
        {
            try
            {
                // zugang zu zoo
                string query = " select * from Animal";
                // adapter ist da damit wir objecte daraus machen können mit dennen wir in c# arbeiten können
                // new adapter nutzt query auf die connection und den nutzen wir 
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    // wir erstellen einen datentabelle und füllen den mit dem adapter
                    DataTable AllAnimalTable = new DataTable();
                    sqlDataAdapter.Fill(AllAnimalTable);


                    //WElche Infos sollen in der Listbox angezeigt werden
                    // list box in der main windowdatei bennen und hier darauf zugreifen
                    AllAnimal.DisplayMemberPath = "Name";
                    // Welcher wert soll gegeben werden wenn ein item in der listbox ausgewählt wird
                    AllAnimal.SelectedValuePath = "Id";

                    AllAnimal.ItemsSource = AllAnimalTable.DefaultView;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Zoos where Id = @ZoosId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // connection öffnen aber !!! wieder schließen in finally
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZoosId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }


        }

        public void AddZoo_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string query = "insert into Zoos values (@Location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", MyTextBox.Text);
                // damit es angezeigt wird in der tabelle sonst bringt das hinzufügen nix
                sqlCommand.ExecuteScalar();
            }
            catch (Exception)
            {

                MessageBox.Show("Fehler beim hinzufügen");
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }
        public void AddAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {


            if (listZoos.SelectedValue == null || AllAnimal.SelectedValue == null)
            {

                return;
            }


            try
            {
                string query = "insert into ZooAnimal values (@ZoosId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZoosId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", AllAnimal.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception hz)
            {

                MessageBox.Show(hz.ToString());

            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals();
            }
        }
        public void AddAnimal_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("jap");
            try
            {
                string query = "insert into Animal values (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", MyTextBox.Text);
                // damit es angezeigt wird in der tabelle sonst bringt das hinzufügen nix
                sqlCommand.ExecuteScalar();
            }
            catch (Exception)
            {

                MessageBox.Show("Fehler beim hinzufügen");
            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }

        }
        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Animal where Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // connection öffnen aber !!! wieder schließen in finally
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", AllAnimal.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals();
                ShowAllAnimals(); 
            }


        }







    }
}
