using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AppDev_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AppDev_Project.Models.ViewModels
{
    public partial class InvoiceVM
    {
        ProjectEntities db = new ProjectEntities();
        [Key]
        public string CustomerID { get; set; }
        public string CName { get; set; }
        public string Adrs { get; set; }
        public string PostAdrs { get; set; }
        public int MyProperty { get; set; }
        public string DriverNo { get; set; }
        public string DName { get; set; }
        public string DriverID { get; set; }

        public string TruckID { get; set; }
        public string JobID { get; set; }
        public string CargoID { get; set; }
        public decimal BasicCost { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Truck Truck { get; set; }
        public virtual Job Job { get; set; }        

    }
}

