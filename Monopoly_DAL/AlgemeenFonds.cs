//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Monopoly_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlgemeenFonds
    {
        public int id { get; set; }
        public string type { get; set; }
        public string omschrijving { get; set; }
        public Nullable<int> bedrag { get; set; }
        public Nullable<int> aantalPosities { get; set; }
        public bool houbij { get; set; }
    }
}