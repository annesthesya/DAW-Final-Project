using ProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class ParkingSpace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Area { get; set; }
        public int Floor { get; set; }
        public bool Occupied { get; set; }
        public decimal PricePerHour { get; set; }
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }

    }
}
