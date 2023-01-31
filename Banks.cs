using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirdStore.Models.Models
{
    [Table("Banks")]
    public class Banks : BaseModel
    {

        [MaxLength(20), Required]
        public string Code { get; set; }
        [Required]
        [MaxLength(350)]
        public string NameArabic { get; set; }
        [Required]
        [MaxLength(350)]
        public string NameEnglish { get; set; }
        public bool IsActive { get; set; } = true;
    }
}