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
    /// Логика взаимодействия для SalesAdd.xaml
    /// </summary>
    public partial class SalesAdd : Window
    {
        public SalesAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (CheckInputs(tbName, tbSurname, tbPhone, tbEmail))
            {
                try
                {
                    SalesPerson salesPerson = new SalesPerson()
                    {
                        Name = tbName.Text,
                        Surname = tbSurname.Text,
                        Patronymic = tbPatron.Text,
                        Email = tbEmail.Text,
                        Phone = tbPhone.Text,
                    };
                    DBEntities.GetContext().SalesPerson.Add(salesPerson);
                    DBEntities.GetContext().SaveChanges();
                    ClassMB.InfoMessageBox("Добавление успешно");
                }
                catch
                {
                    ClassMB.ErrorMessageBox("Не все поля заполнены");
                }
            }
            else
            {
                ClassMB.ErrorMessageBox("Не все поля заполнены");
            }

        }
        private bool CheckInputs(params TextBox[] inputs)
        {
            foreach (TextBox textBox in inputs)
            {
                if(string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Focus();
                    return false;
                }
            }
            return true;
        }
    }
}
