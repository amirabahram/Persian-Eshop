using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Models.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
