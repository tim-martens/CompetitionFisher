using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class Championship
    {
        public Guid Id { get; set; }
        public string Auth0UserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
        //public virtual ICollection<ApplicationUser> Admins { get; set; }
    }


}
