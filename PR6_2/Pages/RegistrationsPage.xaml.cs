using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PR6_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationsPage.xaml
    /// </summary>
    public partial class RegistrationsPage : Page
    {
        public RegistrationsPage()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registration(txtFIO.Text, txtEmail.Text, txtPassword.Password, txtConfirmPassword.Password, cmbRole.Text);
        }

        public bool Registration(string FIO, string email, string password, string confirmPassword, string role)
        {
            txtStatus.Text = "";
            txtStatus.Foreground = Brushes.Red;

            if (string.IsNullOrEmpty(FIO) ||
                string.IsNullOrEmpty(email) ||
                password.Length == 0 ||
                confirmPassword.Length == 0 ||
                string.IsNullOrEmpty(role))
            {
                txtStatus.Text = "Заполните все обязательные поля!";
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                txtStatus.Text = "Введите корректный email!";
                return false;
            }

            if (password != confirmPassword)
            {
                txtStatus.Text = "Пароли не совпадают!";
                return false;
            }

            if (password.Length < 8)
            {
                txtStatus.Text = "Пароль должен содержать минимум 8 символов!";
                return false;
            }

            var User = new Users
            {
                Login = email,
                Password = password,
                Role = role,
                FIO = FIO,
            };

            Core.DB.Users.Add(User);
            Core.DB.SaveChanges();

            txtStatus.Text = "Регистрация прошла успешно!";
            txtStatus.Foreground = Brushes.Green;

            return true;
        }
    }
}
