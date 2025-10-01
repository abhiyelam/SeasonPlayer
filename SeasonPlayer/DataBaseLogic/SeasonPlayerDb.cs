using SeasonPlayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonPlayer.DataBaseLogic
{
    public class SeasonPlayerDb
    {
      
        
            public List<PlayerModel> SeasonPlayers_GetAllSeasonId()
            {
                List<PlayerModel> list = new List<PlayerModel>();

                try
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CONSTR"]))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SeasonPlayers_GetSaesonId", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    PlayerModel obj = new PlayerModel();
<<<<<<< Updated upstream
                                    //obj.seasonid = reader["season_id"].ToString();
=======
                                    obj.seasonid = reader["season_id"].ToString();
>>>>>>> Stashed changes

                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return list;
            }
        public bool SeasonPlayers_Save(List<PlayerModel> playerList,string seasonid)
        {
            bool flag = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CONSTR"]))
                {
                    conn.Open();

                    foreach (var player in playerList)
                    {
                        using (SqlCommand cmd = new SqlCommand("SoccerPlayer_SaveOrUpdate", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            string totitle=CommonFunction.ToTitle(player.player.name);
                            cmd.Parameters.Clear();

                         
                            cmd.Parameters.AddWithValue("@player_rank", player.position);
                            cmd.Parameters.AddWithValue("@goals", player.goals);
                            cmd.Parameters.AddWithValue("@penalty", player.penalty);
                            cmd.Parameters.AddWithValue("@assists", player.assists);
                            cmd.Parameters.AddWithValue("@minutes_played", player.minutes_played);
                            //cmd.Parameters.AddWithValue("@updated_at", player.updated_at);
                            cmd.Parameters.AddWithValue("@seasonid", seasonid ?? string.Empty);

                          
                            cmd.Parameters.AddWithValue("@player_id", player.player?.id ?? string.Empty);
                            cmd.Parameters.AddWithValue("@player_name", player.player?.name ?? string.Empty);
                            cmd.Parameters.AddWithValue("@player_logo", player.player?.logo ?? string.Empty);
                            cmd.Parameters.AddWithValue("@player_position", player.player?.position ?? string.Empty);
                            cmd.Parameters.AddWithValue("@country_id", player.player?.country_id ?? string.Empty);
                            cmd.Parameters.AddWithValue("@nationality", player.player?.nationality ?? string.Empty);
                            cmd.Parameters.AddWithValue("@totile", totitle ?? string.Empty);

                           cmd.Parameters.AddWithValue("@team_id", player.team?.id ?? string.Empty);
                            //cmd.Parameters.AddWithValue("@team_name", player.team?.name ?? string.Empty);
                           // cmd.Parameters.AddWithValue("@team_logo", player.team?.logo ?? string.Empty);

                            cmd.ExecuteNonQuery();
                            flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving players: " + ex.Message);
            }

            return flag;
        }


    }
}

