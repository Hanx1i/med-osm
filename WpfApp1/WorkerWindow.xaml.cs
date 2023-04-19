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
using System.Windows.Shapes;
using WpfApp1.Data;
using WpfApp1.model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        private TextBox? _textBoxPostName;
        private TextBox? _textBoxPersonalNum;
        private TextBox? _textBoxFirstname;
        private TextBox? _textBoxLastname;
        private TextBox? _textBoxPatronymic;


        public WorkerWindow()
        {
            InitializeComponent();
            using var context = new AppDbContext();
            var organizations = context.Companies.Select(e => e.FullName).ToList();
            org_list.ItemsSource = organizations;
            var employers = context.Employers.ToList();
            employeers.ItemsSource = employers;

        }

        private void AddPost(object sender, RoutedEventArgs e)
        {
            var postName = _textBoxPostName?.Text;
            if(postName == null || postName.Trim().Length == 0)
            {
                MessageBox.Show("Поле не заполнено");
                return;
            }


            using var context = new AppDbContext();
            var post = context.Posts.FirstOrDefault(e => e.Name == postName);
            if(post == null)
            {
                var postBody = new Post
                {
                    Name = postName
                };
                
                context.Posts.Add(postBody);
                context.SaveChanges();
                MessageBox.Show("Успешно добавлена");
                return;
            }
            MessageBox.Show("Такая должность уже существует");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _textBoxPostName = (TextBox)sender;
        }

        private void ChangeWindowToMainWindow(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddEmployerr(object sender, RoutedEventArgs e)
        {
            var personalNum = _textBoxPersonalNum?.Text;
            var firstName = _textBoxFirstname?.Text;
            var lastName = _textBoxLastname?.Text;
            var patronymic = _textBoxPatronymic?.Text;

            var dateOfBirth = dob.SelectedDate;
            var dateOFEnd = dateOfEnd.SelectedDate;
            var organizationName = (string)org_list.SelectedItem;

            if(personalNum == null || firstName == null ||
                lastName == null || patronymic == null ||
                dateOfBirth == null || dateOFEnd == null || organizationName == null
                )
            {
                MessageBox.Show("Поле не заполнено");
                return;
            }

            using var context = new AppDbContext();
            var company = context.Companies.First(e => e.FullName == organizationName);
            var employeer = new Employer
            {
                Dob = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Company = company,
                FirstName = firstName,
                LastName = lastName,
                Patronymic = patronymic,
                PersonalNum = personalNum
            };
            context.Employers.Add(employeer);
            context.SaveChanges();
            MessageBox.Show("Успешно добавлен");
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            _textBoxPersonalNum = (TextBox)sender;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            _textBoxLastname = (TextBox)sender;
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            _textBoxFirstname = (TextBox)sender;
        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            _textBoxPatronymic = (TextBox)sender;
        }

        private void employeers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using var context = new AppDbContext();
            var employers = context.Employers.ToList();
            employeers.ItemsSource = employers;
        }
    }
}
