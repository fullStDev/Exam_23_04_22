using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Exam_23_04_22.classess
{
    internal class CheckLogPassClass
    {
        public void CheckLogPass(MainWindow mainWindow)
        {
            if (mainWindow.passwordTextBox.Text.Length > 0)
            {
                mainWindow.passwordPasswordBox.Password = mainWindow.passwordTextBox.Text;
            }

            FirstConnectClass firstConnect = new classess.FirstConnectClass();
            DataTable dt_StroyCompany = firstConnect.Select("SELECT * FROM [dbo].[Table_users] WHERE [login] = '" + mainWindow.loginTextBox.Text + "' AND [password] = '" + mainWindow.passwordPasswordBox.Password + "'");
            if (mainWindow.loginTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Вы не ввели логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (mainWindow.passwordPasswordBox.Password.Length <= 0)
            {
                MessageBox.Show("Вы не ввели пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                mainWindow.loginTextBox.Clear();
            }
            else if (dt_StroyCompany.Rows.Count > 0)
            {
                PrimaryWindow onePrimaryWindow = new PrimaryWindow();
                onePrimaryWindow.Owner = mainWindow;
                classess.CompetitionTableServices oneCompetitionTableServices = new classess.CompetitionTableServices();
                oneCompetitionTableServices.MethodCompetitionTableServices(onePrimaryWindow);

                //onePrimaryWindow.LabelPrimaryNameAcc.Content = dt_StroyCompany.Rows[0][3].ToString();
                onePrimaryWindow.Show();
                mainWindow.Hide();
            }
            else
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                mainWindow.passwordTextBox.Clear();
                mainWindow.loginTextBox.Clear();
                mainWindow.passwordPasswordBox.Clear();
            }
        }
    }
}
