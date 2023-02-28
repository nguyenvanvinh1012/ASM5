namespace ASM5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Tựa sách không được để trống !")]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(150, ErrorMessage ="Tên tác giả có tối đa 150 kí tự")]
        public string Author { get; set; }
        [Range(1, 999, ErrorMessage = "Giá sách từ 1-999")]
        public decimal? Price { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        //public HttpPostedFileBase ImageFife { get; set; }
    }
}
