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
    
    public partial class Spelvak
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string type { get; set; }
        public string kleur { get; set; }
        public Nullable<int> spelerId { get; set; }
        public Nullable<int> prijsMet1Huis { get; set; }
        public Nullable<int> prijsMet2Huizen { get; set; }
        public Nullable<int> prijsMet3Huizen { get; set; }
        public Nullable<int> prijsMet4Huizen { get; set; }
        public Nullable<int> prijsMet1Hotel { get; set; }
        public Nullable<int> aantalHuizen { get; set; }
        public Nullable<int> aantalHotels { get; set; }
        public Nullable<int> prijsPerHotel { get; set; }
        public Nullable<int> prijsPerHuis { get; set; }
        public int aankoopwaarde { get; set; }
        public int hypotheekwaarde { get; set; }
        public Nullable<int> aantalOgen { get; set; }
    
        public virtual Speler Speler { get; set; }
    }
}