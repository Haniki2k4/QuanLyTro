//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TTinPhongTro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TTinPhongTro()
        {
            this.TTinNguoiThues = new HashSet<TTinNguoiThue>();
        }
    
        public string MaPhong { get; set; }
        public string DiaChi { get; set; }
        public decimal DienTich { get; set; }
        public double GiaThue { get; set; }
        public bool TinhTrang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTinNguoiThue> TTinNguoiThues { get; set; }
    }
}
