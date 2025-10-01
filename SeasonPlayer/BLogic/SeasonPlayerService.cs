using Newtonsoft.Json.Linq;
using SeasonPlayer.DataBaseLogic;
using SeasonPlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SeasonPlayer.BLogic
{
    public class SeasonPlayerService
    {
        private static readonly HttpClient client = new HttpClient();


        public bool GetSeasonplayerData(string username, string password, string seasonid)
        {

            List<PlayerModel> seasonplayerlist = new List<PlayerModel>();

           
            string apiUrl = $"https://api.thesports.com/v1/football/season/recent/shooter/stat?user={username}&secret={password}&uuid={seasonid}";

            try
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var json = JObject.Parse(responseBody);

                seasonplayerlist = json["results"]?.ToObject<List<PlayerModel>>() ?? new List<PlayerModel>();
                if (seasonplayerlist != null)
                {
                    SeasonPlayerDb db = new SeasonPlayerDb();
                    db.SeasonPlayers_Save(seasonplayerlist, seasonid);
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data for: {ex.Message}");

            }


            return false;
        }
    }
}
