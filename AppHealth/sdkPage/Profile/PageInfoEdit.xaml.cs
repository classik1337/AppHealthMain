using Microsoft.Data.SqlClient;

using System;

using System.Windows;
using System.Windows.Controls;

using System.Configuration;
using System.Data;


namespace AppHealth.sdkPage
{
    /// <summary>
    /// Логика взаимодействия для PageInfoEdit.xaml
    /// </summary>
    public partial class PageInfoEdit : Page
    {
        string Login = Window1.Login;
        public PageInfoEdit()
        {
            InitializeComponent();
            loginText.Text = Login;
        }
        private SqlConnection sqlConnection = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameText.Text;
            string surname = surnameText.Text;
            string age = ageText.Text;
            string description = descriptionText.Text;
            string city = cityText.Text;
            string dateBirhday = dateText.Text;
            if (name.Length >= 1 || surname.Length >= 1 || age.Length >= 1)
            {



                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);

                SqlCommand command2 = new SqlCommand("SELECT id_user FROM [users] WHERE (login)= @uL  ", connection);//выборка id пользователя по логину входа
                command2.Parameters.Add("@uL", SqlDbType.VarChar).Value = Login;

                command2.Connection = connection;
                connection.Open();


                using (SqlDataReader oReader = command2.ExecuteReader())
                {
                    int IdUser = 0;
                    while (oReader.Read())
                    {
                        string StringId = oReader["id_user"].ToString();

                        IdUser = Int32.Parse(StringId);//получение id пользователя под переменной
                    }

                    connection.Close();



                    SqlCommand command = new SqlCommand("UPDATE [full_users] SET name=@setName, surname=@setSurname,age =@setAge, description =@setDesc, date_birthday= @setDate,city= @setCity WHERE (id_user)=@setId ", connection);
                    command.Parameters.Add("@setName", SqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@setSurname", SqlDbType.VarChar).Value = surname;
                    command.Parameters.Add("@setAge", SqlDbType.VarChar).Value = age;
                    command.Parameters.Add("@setId", SqlDbType.VarChar).Value = IdUser;
                    command.Parameters.Add("@setDesc", SqlDbType.VarChar).Value = description;
                    command.Parameters.Add("@setDate", SqlDbType.VarChar).Value = dateBirhday;
                    command.Parameters.Add("@setCity", SqlDbType.VarChar).Value = city;

                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                    MessageBox.Show("Перезайдите в аккаунт чтоб увидеть изменения!");
                    string InfoStatic = "sdkPage/Profile/PageInfoStatic.xaml";
                    this.NavigationService.Navigate(new Uri(InfoStatic, UriKind.Relative));
                }
            }
            else
            {
                MessageBox.Show("Запоните все поля!");
            }
        }
    }
}
