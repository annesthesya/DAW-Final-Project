using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class Role : IdentityRole<int>
    {
        ICollection<UserRole> UserRoles { get; set; }

    }
}
