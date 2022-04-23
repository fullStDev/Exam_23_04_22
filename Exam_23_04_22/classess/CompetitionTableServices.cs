using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows;

namespace Exam_23_04_22.classess
{
    internal class CompetitionTableServices
    {
        internal class Rents
        {
            public string id_service { get; set; }
            public string nameService { get; set; }
            public string costService { get; set; }
            public string equipmentInstallation { get; set; }

        }
        public void MethodCompetitionTableServices(PrimaryWindow onePrimaryWindow)
        {
            onePrimaryWindow.ListPrimaryServices.Items.Clear();
            classess.FirstConnectClass firstConnect = new classess.FirstConnectClass();
            DataTable dt_TelecommunicationsCompany = firstConnect.Select("SELECT * FROM [dbo].[Table_services]"); // данные из БД
            for (int i = 0; i < dt_TelecommunicationsCompany.Rows.Count; i++) // перебираем данные
            {
                Rents Lol = new Rents() // создаём экземпляр класса
                {
                    id_service = dt_TelecommunicationsCompany.Rows[i][0].ToString(),
                    nameService = dt_TelecommunicationsCompany.Rows[i][1].ToString(), // указываем изображение из таблицы
                    costService = dt_TelecommunicationsCompany.Rows[i][2].ToString(),
                    equipmentInstallation = dt_TelecommunicationsCompany.Rows[i][3].ToString(),// указываем название товара
                };
                onePrimaryWindow.ListPrimaryServices.Items.Add(Lol); // выводим строку в список
            }
        }
    }
}
