using MedicineLab.Model;
using System;
using System.Windows;
using System.Linq;
using System.Windows.Controls;


namespace MedicineLab.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        #region Methods 

        /// <summary>
        /// Метод, позволяющий создавать новую капчу
        /// </summary>
        /// <returns></returns>
        string CreateCapthca()
        {
            string password = "",
                   Alphabet = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            Random rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                password += Alphabet[rand.Next(Alphabet.Length)];
            }

            return password;  
        }

        #endregion

        // Создание новой капчи
        private void BtnRecaptcha_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TblockCaptcha.Text = CreateCapthca();
        }

        // Смена масок пароля
        private void BtnShowPassword_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Pbox.Visibility == Visibility.Visible)
            {
                TxbPassword.Text = Pbox.Password;
                Pbox.Visibility = Visibility.Collapsed;
                TxbPassword.Visibility = Visibility.Visible;
            } else
            {
                Pbox.Visibility = Visibility.Visible;
                TxbPassword.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            Visit Guest;
            if (TxbCaptcha.Text == TblockCaptcha.Text)
            {
                var CurrentUser = AppData.db.User.FirstOrDefault(x => x.Login == TxbLogin.Text);
                if (CurrentUser != null)
                {
                    if (TxbLogin.Text == CurrentUser.Login && Pbox.Password == CurrentUser.Password)
                    {
                        Guest = new Visit
                        {
                            Success = true,
                            TimeVisited = DateTime.Now,
                            UserID = CurrentUser.ID,
                        };
                        AppData.db.Visit.Add(Guest);
                        AppData.db.SaveChanges();
                        //NavigationService.Navigate(new );
                    } else
                    {
                        Guest = new Visit
                        {
                            Success = false,
                            TimeVisited = DateTime.Now,
                            UserID = CurrentUser.ID,
                        };
                        AppData.db.Visit.Add(Guest);
                        AppData.db.SaveChanges();
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else
                {
                    MessageBox.Show("Пользователя с такими данными нет в базе!", "404", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            } else
            {
                MessageBox.Show("Неверно введена капча!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
