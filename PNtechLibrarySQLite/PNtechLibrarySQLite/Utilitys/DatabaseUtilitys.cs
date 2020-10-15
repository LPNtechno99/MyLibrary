using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PNtechLibrarySQLite.MODELS;

namespace PNtechLibrarySQLite.Utilitys
{
    public class DatabaseUtilitys
    {
        public static string QueryInsert(BaseModel model)
        {
            string tableName = model.GetType().Name.Substring(0, model.GetType().Name.Length - 5);
            string Insert = "INSERT INTO " + tableName + " (";
            PropertyInfo[] propertiesName = model.GetType().GetProperties();
            for (int i = 0; i < propertiesName.Length; i++)
            {
                object[] arrAtt = propertiesName[i].GetCustomAttributes(true);
                if (arrAtt.Length > 0)
                {
                    continue;
                }
                Insert = Insert + propertiesName[i].Name;
                Insert = Insert + ",";
            }
            Insert = Insert.Substring(0, Insert.Length - 1);
            Insert = Insert + ") VALUES (";
            for (int i = 0; i < propertiesName.Length; i++)
            {
                Insert = Insert + "@" + propertiesName[i].Name;
                Insert = Insert + ",";
            }
            Insert = Insert.Substring(0, Insert.Length - 1);
            Insert = Insert + ")";

            return Insert;
        }
    }
}
