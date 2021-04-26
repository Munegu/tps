using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TP1_Module6.Data
{
    public class TP1_Module6Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TP1_Module6Context() : base("name=TP1_Module6Context")
        {
        }

        public System.Data.Entity.DbSet<TP1_Module6.BO.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<TP1_Module6.BO.Arme> Armes { get; set; }
    }
}
