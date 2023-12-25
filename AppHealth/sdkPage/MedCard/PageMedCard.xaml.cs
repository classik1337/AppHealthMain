using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using AppHealth.sdkPage.Auth;
using System;

namespace AppHealth.sdkPage.MedCard
{

    /// <summary>
    /// Логика взаимодействия для PageMedCard.xaml
    /// </summary>
    public partial class PageMedCard : Page
    {
        string name_table = "";
        string surname_table = "";
        string fathername_table = "";
        string datebirthday_table = "";
        string adresslive_table = "";
        string adresspropiski_table = "";
        string companyscarry = "";
        string numberpolis_table = "";
        string phone_table = "";
        void checkMedUser()
        {
            int IdUser = 0;
            string Login = PageLogin.Login;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
            SqlCommand command2 = new SqlCommand("SELECT id_user FROM [users] WHERE (login)= @uL  ", connection);//выборка id пользователя по логину входа
            command2.Parameters.Add("@uL", SqlDbType.VarChar).Value = Login;
            command2.Connection = connection;
            connection.Open();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                while (oReader.Read())
                {
                    string StringId = oReader["id_user"].ToString();

                    IdUser = Int32.Parse(StringId);//получение id пользователя под переменной
                }
                connection.Close();
            }
            SqlCommand commandd = new SqlCommand("SELECT surname, name, father_name, date_birthday, adress_live, adress_propisk, company_scarry, number_polis,phone_number FROM [Med_card] where  (id_user)=@uIdUser", connection);//получение строки с id---IdUser
            commandd.Parameters.Add("@uIDUser", SqlDbType.VarChar).Value = IdUser;
            commandd.Connection = connection;




            connection.Open();
            using (SqlDataReader oReader1 = commandd.ExecuteReader())
            {
                while (oReader1.Read())
                {

                    surname_table = oReader1["surname"].ToString();
                    name_table = oReader1["name"].ToString();
                    fathername_table = oReader1["father_name"].ToString();
                    datebirthday_table = oReader1["date_birthday"].ToString();
                    adresslive_table = oReader1["adress_live"].ToString();
                    adresspropiski_table = oReader1["adress_propisk"].ToString();
                    companyscarry = oReader1["company_scarry"].ToString();
                    numberpolis_table = oReader1["number_polis"].ToString();
                    phone_table = oReader1["phone_number"].ToString();
                }
            }
            connection.Close();
            nameText1.Text = name_table;
            surnameText1.Text = surname_table;
            fathernameText1.Text = fathername_table;
            adressLiveText1.Text = adresslive_table;
            dateBirthdayText.Text = datebirthday_table;
            adresspropiskiText1.Text = adresspropiski_table;
            scarrycompanyText1.Text = companyscarry;
            numpolisText1.Text = numberpolis_table;
            phoneNumberText1.Text = phone_table;
        }




        public PageMedCard()
        {
            InitializeComponent();
            string Login = PageLogin.Login;
            string nameTable = Window1.nameTable;
            string surnameTable = Window1.surnameTable;
            nameText.Text = nameTable;
            surnameText.Text = surnameTable;
            checkMedUser();

        }
        private SqlConnection sqlConnection = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Name = nameText.Text; //Имя
            string Surname = surnameText.Text;//Фамилия
            string fatherName = fathernameText.Text;//Отчество
            string adressLive = adressLiveText.Text;//Адресс проживания
            string adressProp = adresspropiskiText.Text;//Адресс прописки
            string ScarryCompany = scarrycompanyText.Text;//Страховая компания
            string phoneNum = phoneNumberText.Text;//Номер телефона



            if (Name.Length > 1 & Surname.Length > 1 & fatherName.Length > 1 & adressLive.Length > 1 & adressProp.Length > 1 & ScarryCompany.Length > 1 & phoneNum.Length > 1)
            {
                string numPolisStr = numpolisText.Text;//Строка для ввод полиса, которая в будущем переведется в число
                string dayStr = DaydateBirthdayText.Text;//Строка для дня в дате рождения -> int
                string mounthStr = MounthdateBirthdayText.Text;//Строка для дня в дате рождения -> int
                string yearStr = YeardateBirthdayText.Text;//Строка для дня в дате рождения -> int
                if (dayStr.Length >= 1 & mounthStr.Length >= 1 & yearStr.Length >= 1 & numPolisStr.Length > 1)
                {


                    string Login = PageLogin.Login;
                    //date
                    int day = Int32.Parse(dayStr);
                    int mounth = Int32.Parse(mounthStr);
                    int year = Int32.Parse(yearStr);
                    int NumPolis = int.Parse(numPolisStr);
                    if ((day >= 1 && day <= 31) && (mounth >= 1 && mounth <= 12) && (year >= 1900 && year <= 2023))
                    {


                        DateTime date1 = new DateTime(year, mounth, day);
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



                            SqlCommand commandd = new SqlCommand("SELECT surname, name, father_name, date_birthday, adress_live, adress_propisk, company_scarry, number_polis,phone_number FROM [Med_card] where  (id_user)=@uIdUser", connection);//получение строки с id---IdUser
                            commandd.Parameters.Add("@uIDUser", SqlDbType.VarChar).Value = IdUser;
                            commandd.Connection = connection;
                            connection.Open();
                            using (SqlDataReader oReader1 = commandd.ExecuteReader())
                            {
                                while (oReader1.Read())
                                {

                                    surname_table = oReader1["surname"].ToString();
                                    name_table = oReader1["name"].ToString();
                                    fathername_table = oReader1["father_name"].ToString();
                                    datebirthday_table = oReader1["date_birthday"].ToString();
                                    adresslive_table = oReader1["adress_live"].ToString();
                                    adresspropiski_table = oReader1["adress_propisk"].ToString();
                                    companyscarry = oReader1["company_scarry"].ToString();
                                    numberpolis_table = oReader1["number_polis"].ToString();
                                    phone_table = oReader1["phone_number"].ToString();

                                }
                            }
                            connection.Close();
                            if (name_table.Length >= 1 || surname_table.Length >= 1 || fathername_table.Length >= 1 || datebirthday_table.Length >= 1 || adresslive_table.Length >= 1 || adresspropiski_table.Length >= 1 || companyscarry.Length >= 1 || numberpolis_table.Length >= 1 || phone_table.Length >= 1)
                            {

                                SqlCommand commandq = new SqlCommand("UPDATE [Med_card] SET name=@setName, surname=@setSurname,father_name =@setFname, date_birthday =@setDb, adress_live= @setAl,adress_propisk= @setAp,company_scarry= @setCs, number_polis= @setNp, phone_number = @setPn WHERE (id_user)=@setId ", connection);
                                commandq.Parameters.Add("@setName", SqlDbType.VarChar).Value = Surname;
                                commandq.Parameters.Add("@setSurname", SqlDbType.VarChar).Value = Name;
                                commandq.Parameters.Add("@setFname", SqlDbType.VarChar).Value = fatherName;
                                commandq.Parameters.Add("@setDb", SqlDbType.Date).Value = date1;
                                commandq.Parameters.Add("@setAl", SqlDbType.VarChar).Value = adressLive;
                                commandq.Parameters.Add("@setAp", SqlDbType.VarChar).Value = adressProp;
                                commandq.Parameters.Add("@setCs", SqlDbType.VarChar).Value = ScarryCompany;
                                commandq.Parameters.Add("@setNp", SqlDbType.Int).Value = NumPolis;
                                commandq.Parameters.Add("@setPn", SqlDbType.VarChar).Value = phoneNum;
                                commandq.Parameters.Add("@setId", SqlDbType.Int).Value = IdUser;
                                commandq.Connection = connection;
                                connection.Open();
                                commandq.ExecuteReader();
                                connection.Close();



                                nameText1.Text = Name;
                                surnameText1.Text = Surname;
                                fathernameText1.Text = fatherName;
                                adressLiveText1.Text = adressLive;



                                adresspropiskiText1.Text = adressProp;
                                scarrycompanyText1.Text = ScarryCompany;
                                numpolisText1.Text = NumPolis.ToString();
                                phoneNumberText1.Text = phoneNum;
                                MessageBox.Show("Вы обновили информацию в мед карту!");

                            }
                            else
                            {

                                SqlCommand command = new SqlCommand("INSERT INTO [Med_card] (surname , name,father_name,date_birthday,adress_live,adress_propisk,company_scarry,number_polis,phone_number,id_user) VALUES (@surname , @name,@father_name,@date_birthday,@adress_live,@adress_propisk,@company_scarry,@number_polis,@phone_number,@id_user)");
                                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = Surname;
                                command.Parameters.Add("@name", SqlDbType.VarChar).Value = Name;
                                command.Parameters.Add("@father_name", SqlDbType.VarChar).Value = fatherName;
                                command.Parameters.Add("@date_birthday", SqlDbType.Date).Value = date1;
                                command.Parameters.Add("@adress_live", SqlDbType.VarChar).Value = adressLive;
                                command.Parameters.Add("@adress_propisk", SqlDbType.VarChar).Value = adressProp;
                                command.Parameters.Add("@company_scarry", SqlDbType.VarChar).Value = ScarryCompany;
                                command.Parameters.Add("@number_polis", SqlDbType.Int).Value = NumPolis;
                                command.Parameters.Add("@phone_number", SqlDbType.VarChar).Value = phoneNum;
                                command.Parameters.Add("@id_user", SqlDbType.Int).Value = IdUser;
                                command.Connection = connection;
                                connection.Open();
                                command.ExecuteReader();
                                connection.Close();



                                nameText1.Text = Name;
                                surnameText1.Text = Surname;
                                fathernameText1.Text = fatherName;
                                adressLiveText1.Text = adressLive;
                                dateBirthdayText.Text = date1.ToString();
                                adresspropiskiText1.Text = adressProp;
                                scarrycompanyText1.Text = ScarryCompany;
                                numpolisText1.Text = NumPolis.ToString();
                                phoneNumberText1.Text = phoneNum;
                                MessageBox.Show("Вы добавили информацию в мед карту!");

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите верную дату рождения!");
                    }
                }
            }

            else
            {

                MessageBox.Show("У вас должны быть заполнены все ячейки, или проверьте правильность введенных данных!");

            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }
    }
}
