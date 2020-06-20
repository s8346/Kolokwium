using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Player_Team
    {
        public int IdPlayer { get; set; }

        [ForeignKey("IdPlayer")]
        public virtual Player Player { get; set; }

        public int IdTeam { get; set; }

        [ForeignKey("IdTeam")]
        public virtual Team Team { get; set; }

        public int NumOnShirt { get; set; }

        [MaxLength(300)]
        public string Comment { get; set; }
    }
}
