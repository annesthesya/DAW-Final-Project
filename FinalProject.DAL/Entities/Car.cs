using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string LicensePlateNumber { get; set; } //ar putea fi id(unica) dar exista posibilitatea de a se schimba
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }

    }
}
