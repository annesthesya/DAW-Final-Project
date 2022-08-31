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
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public virtual ICollection <Car> Cars { get; set; }
        public virtual ICollection<ClientSubscription> ClientSubscriptions { get; set; }  

    }
}
