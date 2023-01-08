using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace zadanie1.FolderClass
{
    internal class ClassMB
    {
        public static void InfoMessageBox (string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public static void ErrorMessageBox( Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void ErrorMessageBox (string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static bool QuestionMessageBox (string text)
        {
            return MessageBoxResult.Yes == MessageBox.Show(text, "Вопрос",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static void ExitMessageBox()
        {
            bool ResultMB = QuestionMessageBox("Вы действительно хотите" +
                "выйти?");
            if (ResultMB == true)
                App.Current.Shutdown();
        }
    }
}
