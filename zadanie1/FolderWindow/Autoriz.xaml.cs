using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using zadanie1.FolderWindow.FolderAdmin;
using zadanie1.FolderWindow.FolderUser;

namespace zadanie1.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Window
    {
        private int WrongCounts = 0;
        private int sum = 15000;
        private int ExtraTime = 20000;
        public Autoriz()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tb.Text))
            {
                ClassMB.ErrorMessageBox("Вы ввели неверный логин или пароль. " +
                    "Пожалуйста проверьте ещё раз введенные данные");
                tb.Focus();
            }
            if(string.IsNullOrEmpty(pb.Password))
            {
                ClassMB.ErrorMessageBox("Вы ввели неверный логин или пароль. " +
                    "Пожалуйста проверьте ещё раз введенные данные");
                pb.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext().User
                     .FirstOrDefault(u => u.LoginUser == tb.Text && u.PasswordUser == pb.Password);

                    if (WrongCounts > 3)
                    {
                        sum += ExtraTime;
                        BlockSystem();
                        return;
                    }

                    if (WrongCounts == 3)
                    {
                        WrongCounts++;
                        BlockSystem();
                        return;
                    }

                    if (user == null)
                    {
                        ClassMB.ErrorMessageBox("Вы ввели неверный логин или пароль. " +
                            "Пожалуйста проверьте ещё раз введенные данные");
                        WrongCounts++;
                        tb.Focus();
                        return;
                    }
                    else
                    {
                        SetActiveDate(user);
                    }
                    


                    if (user.PasswordUser != pb.Password)
                    {
                        ClassMB.ErrorMessageBox("Вы ввели неверный логин или пароль. " +
                            "Пожалуйста проверьте ещё раз введенные данные");
                        pb.Focus();
                        return;
                    }

                   
                   
                    switch (user.IdRole)
                    {
                        case 1:
                            new WindowUser().Show();
                            Close();
                            break;
                        case 2:
                            new AdminWindow().Show();
                            Close();
                            break;
                    }
                    user.ActiveDate = DateTime.Now;
                    DBEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    ClassMB.ErrorMessageBox(ex);
                }
            }
        }
        private void SetActiveDate(User user)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = Convert.ToDateTime(user.ActiveDate);
            TimeSpan d = d1 - d2;
            if (Convert.ToInt32(d.ToString("dd")) > 30)
            {
                user.Active = 0;
                DBEntities.GetContext().SaveChanges();
            }

            if (user.Active == 0)
            {
                ClassMB.ErrorMessageBox("Ваша учетная запись отключена за неактивность.");
                return;
            }
        }

        private void BlockSystem()
        {
            ClassMB.ErrorMessageBox($"Система заблокирована на {sum/1000} секунд!") ;
            Thread.Sleep(sum);
            ClassMB.InfoMessageBox("Система разрблокирована, но в случае новой ошибки будет вновь заблокирована!");
        }
    }
}
