using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Domain.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual List<Game> Games { get; set; }
        public virtual List<Game> WishList { get; set; }
        public virtual List<Game> Cart { get;}
    }
}
