//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppDev_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver
    {
        public Driver()
        {
            this.Jobs = new HashSet<Job>();
        }
    
        public string DriverNo { get; set; }
        public string DName { get; set; }
        public string DriverID { get; set; }
        public string Licen { get; set; }
        public System.DateTime DOE { get; set; }
        public string Adrs { get; set; }
        public string ConNum { get; set; }
        public string nokCNum { get; set; }
    
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
