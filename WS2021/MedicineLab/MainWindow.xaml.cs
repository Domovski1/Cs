using MedicineLab.Pages;
using System.Windows;


namespace MedicineLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new SignIn());
        }
    }
}
