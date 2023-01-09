using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1.FolderData
{
    public partial class DBEntities : DbContext
    {
        private static DBEntities context;
        public static DBEntities GetContext()
        {
            return context ?? (context = new DBEntities());
        }
    }
}
