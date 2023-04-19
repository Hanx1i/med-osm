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
using WpfApp1.Data;
using WpfApp1.model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox _textBoxCode;
        private TextBox _textBoxFullname;
        private TextBox _textBoxShortname;
        private TextBox _textBoxAddress;

        public MainWindow()
        {
            InitializeComponent();

            using var context = new AppDbContext();
            var companies = context.Companies.ToList();
            companies_grid.ItemsSource = companies;
        }

        private void AddCompany(object sender, RoutedEventArgs e)
        {
            string? code = _textBoxCode?.Text;
            string? fullname = _textBoxFullname?.Text;
            string? shortName = _textBoxShortname?.Text;
            string? address = _textBoxAddress?.Text;

            if(code != null && fullname != null && shortName != null && address != null)
            {
                using (var context = new AppDbContext())
                {
                    var company = context.Companies.FirstOrDefault(e => e.Code == code);
                    if (company == null)
                    {
                        var companyBody = new Company
                        {
                            Code = code,
                            FullName = fullname,
                            ShortName = shortName,
                            LegalAddress = address
                        };

                        context.Companies.Add(companyBody);
                        context.SaveChanges();
                        MessageBox.Show("Успешно добавлено");
                        return;
                    }
                    MessageBox.Show("Компания с таким кодом уже существует");
                    return;
                }
            }
            MessageBox.Show("Какое-то поле не заполнено");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _textBoxCode = (TextBox)sender;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            _textBoxFullname = (TextBox)sender;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            _textBoxShortname = (TextBox)sender;
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            _textBoxAddress = (TextBox)sender;
        }

        private void ChangeWindowToAddEmployeer(object sender, RoutedEventArgs e)
        {
            var workerWindow = new WorkerWindow();
            Close();
            workerWindow.Show();
        }

        private void companies_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using var context = new AppDbContext();
            var companies = context.Companies;
            companies_grid.ItemsSource = companies.ToList();
        }
    }
}
