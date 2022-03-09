using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Growth
    {
        [Key]
        public string GrowthGuid { get; set; }
    }
}