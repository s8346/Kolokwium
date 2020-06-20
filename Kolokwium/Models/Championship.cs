using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Championship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdChampionship { get; set; }

        [MaxLength(100)]
        [Required]
        public string OfficialName { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Championship_Team> ChampionshipTeam { get; set; }

    }
}
