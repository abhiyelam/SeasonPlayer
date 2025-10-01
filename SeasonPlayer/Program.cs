using SeasonPlayer.BLogic;
using SeasonPlayer.DataBaseLogic;
using SeasonPlayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonPlayer
{
    class Program
    {
        public static string ApiUser = "";
        public static string SecretKey = "";
        static void Main(string[] args)
        {
            ApiUser = ConfigurationManager.AppSettings["APIUSER"].ToString();
            SecretKey = ConfigurationManager.AppSettings["SECRETKEY"].ToString();
            SeasonPlayerService service = new SeasonPlayerService();
            SeasonPlayerDb db = new SeasonPlayerDb();
            Console.WriteLine("The football Api Start at " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));
            List<PlayerModel> seasonids = db.SeasonPlayers_GetAllSeasonId();
            foreach (var s in seasonids) 
            {
                service.GetSeasonplayerData(ApiUser, SecretKey, s.seasonid);
            }
            Console.WriteLine("The football Api End at " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));
            Console.ReadLine();
            //Environment.Exit(0);
        }
    }
}
