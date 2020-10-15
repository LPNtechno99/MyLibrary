using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;

namespace PN_SQLiteLibrary
{
    public class PNBaseCRUD<T> : PNAbstractClassCRUD<T>
    {
        private SQLiteConnection _sqliteCon;
        public PNBaseCRUD(string conStr)
        {
            if (_sqliteCon == null)
                _sqliteCon = new SQLiteConnection(conStr);
        }
        public override void Insert(T item)
        {
            string tableName = item.GetType().Name;
            string Insert = "INSERT INTO " + tableName + " (";
            PropertyInfo[] propertiesName = item.GetType().GetProperties();
            for(int i=0;i<propertiesName.Length;i++)
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
            object value;
            _sqliteCon.Open();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(Insert, _sqliteCon))
                {
                    for (int i = 0; i < propertiesName.Length; i++)
                    {
                        value = propertiesName[i].GetValue(item, null);
                        cmd.Parameters.AddWithValue(propertiesName[i].Name.ToString(), value);
                    }
                    cmd.ExecuteNonQuery();
                };
                _sqliteCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override void Update(T item)
        {

        }
        public override void Delete()
        {

        }
        public override void Delete(string ID)
        {
            
        }
        public override object Select()
        {
            return null;
        }
    }
}
