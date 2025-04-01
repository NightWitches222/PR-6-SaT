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

namespace PR6_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Auth(txtUsername.Text, txtPassword.Password);
        }

        public bool Auth(string Login, string Pass)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Pass))
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }

            var user = Core.DB.Users.FirstOrDefault(p => Login == p.Login && Pass == p.Password);

            if (user == null)
            {
                MessageBox.Show("Пользователь с таким логином и паролем не найден!");
                return false;
            }
            MessageBox.Show("Успешный вход.");
            txtUsername.Clear();
            txtPassword.Clear();
            return true;
        }
    }
}
