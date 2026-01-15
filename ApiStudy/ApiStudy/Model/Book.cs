using ApiStudy.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiStudy.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("title", TypeName = "varchar(MAX)")]
        public string Title { get; set; }

        [Column("author", TypeName = "varchar(MAX)")]
        public string Author { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        [Precision(18,2)]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date", TypeName = "datetime(6)")]
        public DateTime LaunchDate { get; set; }
    }
}
