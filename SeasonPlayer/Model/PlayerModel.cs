using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonPlayer.Model
{
    public class PlayerModel
    {
        public int position { get; set; }
       
        public Player player { get; set; }
        public Team team { get; set; }
        public int goals { get; set; }
        public int penalty { get; set; }
        public int assists { get; set; }
        public int minutes_played { get; set; }
        public int updated_at { get; set; }
        public string seasonid { get; set; }
    }
  
     public class Player
     {
         public string id { get; set; }
         public string name { get; set; }
         public string logo { get; set; }
         public string position { get; set; }
         public string country_id { get; set; }
         public string nationality { get; set; }
     }

     public class Team
     {
         public string id { get; set; }
         public string name { get; set; }
         public string logo { get; set; }
     }
}

