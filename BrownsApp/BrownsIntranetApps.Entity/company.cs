//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrownsIntranetApps.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class company
    {
        public company()
        {
            this.parts = new HashSet<part>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    
        public virtual ICollection<part> parts { get; set; }
    }
}
