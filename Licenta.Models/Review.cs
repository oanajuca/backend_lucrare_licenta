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
    
    public partial class Review
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Review()
        {
            this.TrailReviews = new HashSet<TrailReview>();
        }
    
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Stars { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrailReview> TrailReviews { get; set; }
    }
}