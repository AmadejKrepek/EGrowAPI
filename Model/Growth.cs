using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Growth
    {
        [Key]
        public Guid Id { get; set; }
    }
}