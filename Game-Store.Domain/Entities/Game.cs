using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public float Price { get; set; }
        public string Trailer { get; set; }
        public List<string> Photos { get; set; }
        public string Description { get; set; }
        public List<string> Genres { get; set; }
        public string RatingsGuide { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Platform { get; set; }
        public long SoldCount { get; set; }
        public Guid SysReqId { get; set; }
        public virtual SystemRequirement SysReq { get; set; }
        public virtual ICollection<GameEdition> GameEditions { get; set; }
    }

    public class GameEdition
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public string EditionName { get; set; }
    }
}
