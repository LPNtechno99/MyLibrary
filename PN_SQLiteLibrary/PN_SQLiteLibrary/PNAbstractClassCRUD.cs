using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PN_SQLiteLibrary
{
    public abstract class PNAbstractClassCRUD<T>
    {
        public virtual void Insert(T item) { }
        public virtual void Update(T item) { }
        public virtual void Delete() { }
        public virtual void Delete(string ID) { }
        public virtual object Select() { return null; }
    }
}
