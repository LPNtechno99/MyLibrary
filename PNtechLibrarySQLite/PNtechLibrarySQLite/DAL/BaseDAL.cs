using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNtechLibrarySQLite.MODELS;
using PNtechLibrarySQLite.Utilitys;
using System.Data.SQLite;
using System.Reflection;

namespace PNtechLibrarySQLite.DAL
{
    public class BaseDAL
    {
        public BaseModel baseModel = new BaseModel();
        private string _className;
        private string _tableName;

        public BaseDAL()
        {

        }
        public BaseDAL(BaseModel baseModel)
        {
            this.baseModel = baseModel;
            _className = this.GetType().Name;
            _className = _className + "Model";
            _tableName = _className.Substring(0, _className.Length - 5);
        }
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
        public virtual int Insert(BaseModel model)
        {
            PropertyInfo[] propertiesName = model.GetType().GetProperties();

            string TableName = model.GetType().Name.Substring(0, model.GetType().Name.Length - 5);
            object value;
            SQLiteConnection conn = new SQLiteConnection(Global.ConnectionString);
            string query = DatabaseUtilitys.QueryInsert(model);
            using (SQLiteCommand cmd = new SQLiteCommand(query,conn))
            {
                for (int i = 0; i < propertiesName.Length; i++)
                {
                    value = propertiesName[i].GetValue(model, null);
                    cmd.Parameters.AddWithValue(propertiesName[i].Name.ToString(), value);
                }
                try
                {
                    conn.Open();
                    int id = cmd.ExecuteNonQuery();
                    //cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return id;
            }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Clone();
                    conn.Dispose();
                }
            };
        }
    }
}
