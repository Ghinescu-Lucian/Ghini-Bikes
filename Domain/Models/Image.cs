using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required,MaxLength(200)]
        public string Path { get; set; }
        public int position { get; set; }
        public int ProductId { get; set; }
    }
}
