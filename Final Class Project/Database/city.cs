//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Class_Project.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class city
    {
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    
        public virtual country country1 { get; set; }
        public virtual state state1 { get; set; }
    }
}