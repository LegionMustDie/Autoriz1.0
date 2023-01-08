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
            if (string.IsNullOrEmpty(tbName.Text))
                ClassMB.ErrorMessageBox("Вы не ввели имя");
            if (string.IsNullOrEmpty(tbSurname.Text))
                ClassMB.ErrorMessageBox("Вы не ввели фамилию");
            if (string.IsNullOrEmpty(tbPatron.Text))
                ClassMB.ErrorMessageBox("Вы не ввели отчество");
            if (string.IsNullOrEmpty(tbEmail.Text))
                ClassMB.ErrorMessageBox("Вы не ввели почту");
            if (string.IsNullOrEmpty(tbPhone.Text))
                ClassMB.ErrorMessageBox("Вы не ввели номер телефона");
            else
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
                    ClassMB.ErrorMessageBox("Произошла ошибка");
                }
            }

        }
    }
}
