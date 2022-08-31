using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class Subscription
    {

        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public double Discount { get; set; }
        public int DurationHours { get; set; }
        public virtual ICollection<ClientSubscription> ClientSubscriptions { get; set; }


    }
}
