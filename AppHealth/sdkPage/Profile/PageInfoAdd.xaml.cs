

using System;

using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace AppHealth.sdkPage
{
    /// <summary>
    /// Логика взаимодействия для PageInfoAdd.xaml
    /// </summary>
    public partial class PageInfoAdd : Page
    {
        string Login = Window1.Login;
        public PageInfoAdd()
        {
            InitializeComponent();
            loginText.Text = Login;

        }
        //Проверить есть ли информация про user!
        private SqlConnection sqlConnection = null;

        // MySqlConnection connection1 = new MySqlConnection("server=localhost;database=users;username=root; ");
        //MySqlCommand command2 = new MySqlCommand("SELECT * FROM full_users WHERE `name`= @uL `surname`=@uS `age`=@uA ", connection1);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameText.Text;
            string surname = surnameText.Text;
            string age = ageText.Text;
            string description = descriptionText.Text;
            string city = cityText.Text;
            string dateBirhday = dateText.Text;
            DataTable table = new DataTable();




            SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
            SqlCommand command1 = new SqlCommand("SELECT (id_user) FROM [users] WHERE (login)= @uL  ", connection1);
            command1.Parameters.Add("@uL", SqlDbType.VarChar).Value = Login;

            command1.Connection = connection1;
            connection1.Open();


            using (SqlDataReader oReader = command1.ExecuteReader())
            {
                int IdUser = 0;
                while (oReader.Read())
                {
                    string StringId = oReader["id_user"].ToString();

                    IdUser = Int32.Parse(StringId);
                }

                connection1.Close();


                SqlCommand command = new SqlCommand("INSERT INTO [full_users] (name , surname,age,id_user) VALUES (@name, @surname, @age,@id_user)");

                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = surname;
                command.Parameters.Add("@age", SqlDbType.VarChar).Value = age;
                command.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                command.Parameters.Add("@date_birthday", SqlDbType.VarChar).Value = dateBirhday;
                command.Parameters.Add("@city", SqlDbType.VarChar).Value = city;
                command.Parameters.Add("@id_user", SqlDbType.Int).Value = IdUser;
                command.Connection = connection1;

                connection1.Open();
                if (name.Length >= 1 || surname.Length >= 1 || age.Length >= 1)
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Вы добавили информацию о себе!");
                    string InfoStatic = "sdkPage/Profile/PageInfoStatic.xaml";
                    this.NavigationService.Navigate(new Uri(InfoStatic, UriKind.Relative));
                }

                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
                connection1.Close();



            }
        }
    }
}


