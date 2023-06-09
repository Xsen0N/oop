using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab04
{
    public class ShopLoggers : ViewModelBase
    {
        public ICommand LanguageChangedCommand { get; set; } // команда для смены языка
        public ICommand StyleChangedCommand { get; set; }// команда для смены стиля
        public ShopLoggers() // присвоение значений командам
        {
            LanguageChangedCommand = new Commands.ActionCommand<ContentControl>(LanguageChangedLogger);
            StyleChangedCommand = new Commands.ActionCommand<ContentControl>(StyleChangedLogger);
        }
        #region Логирование изменений настроек в файлы
        private void LanguageChangedLogger(ContentControl selectedItem)
        {
            // Запись лога в файл
            string logFilePath = "LangLog.txt";
            string message = $"[{DateTime.Now}]: Язык изменен на  '{selectedItem.Content}'\n";
            File.AppendAllText(logFilePath, message);
        }

        private void StyleChangedLogger(ContentControl selectedItem)
        {
            // Запись лога в файл
            string logFilePath = "StyleLog.txt";
            string message = $"[{DateTime.Now}]: Стиль изменен на '{selectedItem.Content}'\n";
            File.AppendAllText(logFilePath, message);
        }
        #endregion
    }
}
