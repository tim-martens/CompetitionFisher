using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Entities
{
    public class Competition
    {
        public Guid Id { get; set; }
        public Guid? ChampionshipId { get; set; }
        public string Auth0UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual Championship Championship { get; set; }
        public virtual ICollection<Contestant> Contestants { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
