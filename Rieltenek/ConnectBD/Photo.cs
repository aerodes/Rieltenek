//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rieltenek.ConnectBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Photo()
        {
            this.Property = new HashSet<Property>();
        }
    
        public int id_photo { get; set; }
        public string photo_1 { get; set; }
        public string photo_2 { get; set; }
        public string photo_3 { get; set; }
        public string photo_4 { get; set; }
        public string photo_5 { get; set; }
        public string photo_6 { get; set; }
        public string photo_7 { get; set; }
        public string photo_8 { get; set; }
        public string photo_9 { get; set; }
        public string photo_10 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Property> Property { get; set; }
    }
}