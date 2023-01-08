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
using zadanie1.FolderData;
using zadanie1.FolderClass;
namespace zadanie1.FolderWindow.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            dgList.ItemsSource = DBEntities.GetContext().SalesPerson.ToList();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            SalesPerson salesPerson = dgList.SelectedItem as SalesPerson;
            if (salesPerson != null)
            {
                if (ClassMB.QuestionMessageBox("Вы уверены, что хотите это удалить?"))
                {
                    DBEntities.GetContext().SalesPerson.Remove(salesPerson);
                    DBEntities.GetContext().SaveChanges();
                    ClassMB.InfoMessageBox("Удаление выполнено");
                    dgList.ItemsSource = DBEntities.GetContext().SalesPerson.ToList() ;
                }
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            new FolderAdmin.SalesAdd().Show();
        }

        private void dgList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SalesPerson salesPerson = dgList.SelectedItem as SalesPerson;
            if (salesPerson != null)
            {
                new FolderAdmin.SalesEdit(salesPerson).Show();
            }
        }
    }
}
