//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructionApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contractors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contractors()
        {
            this.Contracts = new HashSet<Contracts>();
        }
    
        public int contractor_id { get; set; }
        public string contractor_name { get; set; }
        public string contractor_inn { get; set; }
        public string contact_person_name { get; set; }
        public string contact_phone { get; set; }
        public string contact_email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
