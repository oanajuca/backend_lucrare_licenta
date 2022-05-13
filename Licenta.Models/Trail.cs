//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Licenta.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trail()
        {
            this.Descriptions = new HashSet<Description>();
            this.Reviews = new HashSet<Review>();
            this.TrailTouristGuides = new HashSet<TrailTouristGuide>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Distance { get; set; }
        public string Time { get; set; }
        public string Mark { get; set; }
        public string Map { get; set; }
        public string Difficulty { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Description> Descriptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrailTouristGuide> TrailTouristGuides { get; set; }
    }
}
