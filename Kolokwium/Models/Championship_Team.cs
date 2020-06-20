using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Championship_Team
    {
        public int IdTeam { get; set; }
        
        [ForeignKey("IdTeam")]
        public virtual Team Team { get; set; }

        public int IdChampionship { get; set; }

        [ForeignKey("IdChampionship")]
        public virtual Championship Championship { get; set; }

        public float Score { get; set; }

    }
}
