using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QRScan.Models
{
    public class QRDatabaseContext : DbContext
    {
        public QRDatabaseContext() : base("name=QRdatabase") { }

        public DbSet<QRPath> QRPaths { get; set; }
    }
}