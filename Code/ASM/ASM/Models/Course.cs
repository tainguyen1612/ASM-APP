//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Topics = new HashSet<Topic>();
        }
    
        public string CourseID { get; set; }
        public string Course_Name { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
        public string UserID { get; set; }
    
        public virtual Category_Course Category_Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual User_Account User_Account { get; set; }
        [NotMapped]
        public List<Category_Course> cateCollection { get; set; }
        [NotMapped]
        public List<User_Account> IdCollection2 { get; set; }
    }
}