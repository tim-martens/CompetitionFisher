using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionFisher.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Auth0UserId { get; set; }
    }
}
