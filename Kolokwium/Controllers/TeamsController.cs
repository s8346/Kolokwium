using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Kolokwium.Controllers
{
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly KolokwiumDbContext db;

        public TeamsController(KolokwiumDbContext context)
        {
            db = context;
        }

        public class TemaS
        {
            public TemaS(string n, float s)
            {
                name = n;
                score = s;
            }
            public string name { get; set; }
            public float score { get; set; }
        }

        [HttpGet]
        [Route("/api/championships/{teamx:int}/teams")]
        public string TeamT(int teamx)
        {
            var champ = db.Championship.Where(v => v.IdChampionship == teamx).FirstOrDefault();
            if (champ == null) return "Brak mistrzowstw";
            return JsonConvert.SerializeObject(db.Champinship_Team.Where(v => v.IdChampionship == teamx).OrderByDescending(v => v.Score).Select(v => new TemaS(v.Team.TeamName,v.Score)).ToList());
        }

            [HttpPost]
        [Route("api/teams/{teamx:int}/players")]
        public async Task<IActionResult> PlayerT(local_player player, int teamx)
        {
            if (player == null) return BadRequest("Brak danych playera w zapytaniu");
            var team = db.Team.Where(v => v.IdTeam == teamx).FirstOrDefault();
            if (team == null) return BadRequest("Brak druzyny");
            var hasPlayer = db.Player.Where(v => v.FirstName == player.firstName && v.LastName == player.lastName).FirstOrDefault();
            if (hasPlayer == null) return BadRequest("Brak playera w bazie danych");

            DateTime age = new DateTime();
            if (!DateTime.TryParse(player.birthdate, out age)) return BadRequest();
            if (team.MaxAge != 0)
            {
                var ageLimit = DateTime.Now.AddYears(-team.MaxAge);
                if (age < ageLimit) return BadRequest("Przekroczony wiek");
            }
            var isInTeam = db.Player_Team.Where(v => v.IdTeam == teamx && v.IdPlayer == hasPlayer.IdPlayer).FirstOrDefault();
            if (isInTeam != null) return BadRequest("Player jest już w tej drużynie");
            else
            {
                Player_Team PT = new Player_Team()
                {
                    IdPlayer = hasPlayer.IdPlayer,
                    IdTeam = teamx,
                    NumOnShirt = player.numOnShirt,
                    Comment = player.comment
                };
                db.Player_Team.Add(PT);
                await db.SaveChangesAsync();

                return Ok();
            }

        }
    }
    
}
