using MedicineLab.Model;
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

namespace MedicineLab.Pages
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public User user { get; set; }
        public WelcomePage(User GetUser)
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TxbHello.Text = $"Добро пожаловать {user.FirstName} {user.LastEnter}! Ваша роль в системе: {user.Role.Title}";
            if (user.RoleID == 1)
            {
                ImgBox.Source = new BitmapImage(new Uri("pack:"));
            }
        }

        private void BtnToNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
