using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNtechLibrarySQLite.DAL;
using PNtechLibrarySQLite.MODELS;

namespace PNtechLibrarySQLite.BLL
{
    public class BaseBLL
    {
        public BaseDAL baseDAL = null;
        public BaseBLL()
        {
        }
        public virtual int Insert(BaseModel model)
        {
            try
            {
                return baseDAL.Insert(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
