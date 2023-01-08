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
using zadanie1.FolderClass;
using zadanie1.FolderData;

namespace zadanie1.FolderWindow.FolderAdmin
{
    /// <summary>
    /// Логика взаимодействия для SalesEdit.xaml
    /// </summary>
    public partial class SalesEdit : Window
    {
        public SalesEdit(SalesPerson salesPerson)
        {
            InitializeComponent();
            DataContext = salesPerson;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().SaveChanges();
            ClassMB.InfoMessageBox("Изменения сохранены");
        }
    }
}
