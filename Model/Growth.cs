using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Growth
    {
        [Key]
        public Guid Id { get; set; }
    }
}