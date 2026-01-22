using AppCulinaryBook.AppData;
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

namespace AppCulinaryBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AppConnect.culinary_book_entities1.Authors.Count(x => x.Login == AuthorLogin.Text) > 0)
                {
                    MessageBox.Show("Логин занят!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (String.IsNullOrEmpty(AuthorLogin.Text) || String.IsNullOrWhiteSpace(AuthorLogin.Text) ||
                    String.IsNullOrEmpty(AuthorName.Text) || String.IsNullOrWhiteSpace(AuthorName.Text) ||
                    String.IsNullOrEmpty(AuthorPassword.Password) || String.IsNullOrWhiteSpace(AuthorPassword.Password))
                {
                    MessageBox.Show("Поле не может быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                Authors userObj = new Authors()
                {
                    Login = AuthorLogin.Text,
                    AuthorName = AuthorName.Text,
                    Password = AuthorPassword.Password,
                    BirthDate = AuthorBirthdate.SelectedDate.Value,
                    Experience = Double.Parse(AuthorExp.Text),
                    MailAddress = AuthorEmail.Text,
                    PhoneNumber = AuthorPhone.Text
                };

                AppConnect.culinary_book_entities1.Authors.Add(userObj);
                AppConnect.culinary_book_entities1.SaveChanges();
                MessageBox.Show("Вы зарегестрированы!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.FrameMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AuthorPasswordRepite_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (AuthorPassword.Password != AuthorPasswordRepite.Password)
            {
                RegBtn.IsEnabled = false;
                RepPassTXT.Text = "Пароли разные :(";
                RepPassTXT.Foreground = new SolidColorBrush(Colors.PaleVioletRed);
                RepPassTXT.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
            else
            {
                RegBtn.IsEnabled = true;
                RepPassTXT.Text = "Так лучше :)";
                RepPassTXT.Foreground = new SolidColorBrush(Colors.DarkSeaGreen);
            }

        }
    }

}

