using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class ClientSubscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ParkingSpaceId { get; set; }
        public int SubscriptionId { get; set; }
        public string CarLicensePlate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }
        public virtual Client Client { get; set; }
        public virtual Subscription Subscription { get; set; } 

    }
}
