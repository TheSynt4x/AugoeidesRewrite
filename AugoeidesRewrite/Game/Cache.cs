using AugoeidesRewrite.Database.Query;
using AugoeidesRewrite.Game.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Game
{
    class Cache
    {
        public static Cache Instance { get; } = new Cache();

        public Dictionary<int, Items> Items = new Dictionary<int, Items>();
        public Dictionary<int, Skills> Skills = new Dictionary<int, Skills>();
        public Dictionary<int, Maps> Maps = new Dictionary<int, Maps>();

        public void Initialize()
        {
            CacheItems();
            CacheSkills();
            CacheSettings();
            CacheMaps();
        }

        public void CacheMaps()
        {
            MySqlDataReader reader = new ReaderQuery().Execute("SELECT * FROM meh_maps");

            while (reader.Read()) {
                Maps maps = new Maps
                {
                    FileName = reader.GetString("FileName"),
                    Max = reader.GetInt32("PlayersMax"),
                    Name = reader.GetString("Name"),
                    MonFrame = reader.GetString("monsters_frame"),
                    MonTree = reader.GetString("monsters_tree"),
                    MonInfo = reader.GetString("monsters_info"),
                    Id = reader.GetInt32("id"),
                    Extra = reader.GetString("Extra"),
                    Duel = reader.GetInt32("Duel"),
                    PvP = reader.GetInt32("PvP")
                };

                Maps.Add(maps.Id, maps);
            }

            reader.Close();
            reader.Dispose();

            Console.WriteLine($"Cached {Maps.Count} maps.");
        }

        public void CacheSettings()
        {
            MySqlDataReader reader = new ReaderQuery().Execute("SELECT * FROM server_settings WHERE id = 1");

            while (reader.Read()) {
                Settings.Motd = reader.GetString("Message");
                Settings.Map = reader.GetString("Map");
                Settings.Book = reader.GetString("Book");
                Settings.Map = reader.GetString("Map");
                Settings.Assets = reader.GetString("Assets");
                Settings.Fbc = reader.GetString("Fbc");
                Settings.GameMenu = reader.GetString("GameMenu");
                Settings.Video = reader.GetString("Video");
                Settings.News = reader.GetString("News");
            }

            reader.Close();
            reader.Dispose();

            Console.WriteLine($"Server settings cached. MOTD: {Settings.Motd}");
        }

        public void CacheSkills()
        {
            MySqlDataReader reader = new ReaderQuery().Execute("SELECT * FROM meh_skills");

            while (reader.Read()) {
                Skills skill = new Skills
                {
                    id = reader.GetInt32("id"),
                    Ref = reader.GetString("Ref"),
                    anim = reader.GetString("anim"),
                    cd = reader.GetInt32("cd"),
                    desc = reader.GetString("description"),
                    fx = reader.GetString("fx"),
                    icon = reader.GetString("icon"),
                    mp = reader.GetInt32("mp"),
                    nam = reader.GetString("nam"),
                    range = reader.GetInt32("rng"),
                    tgt = reader.GetString("tgt"),
                    tgtMax = reader.GetInt32("tgtMax"),
                    typ = reader.GetString("typ"),
                    strl = reader.GetString("strl"),
                    auto = reader.GetBoolean("auto"),
                    dsrc = reader.GetString("dsrc"),
                    damage = (double)reader.GetDecimal("damage"),
                    tgtMin = reader.GetInt32("tgtMin")
                };

                Skills.Add(skill.id, skill);
            }

            reader.Close();
            reader.Dispose();

            Console.WriteLine($"Cached {Skills.Count} skills.");
        }

        public void CacheItems()
        {
            MySqlDataReader reader = new ReaderQuery().Execute("SELECT * FROM meh_items");

            while (reader.Read()) {
                Items item = new Items
                {
                    ItemId = reader.GetInt32("id"),
                    bCoins = reader.GetInt32("Coins"),
                    EnhID = reader.GetInt32("EnhID"),
                    bHouse = reader.GetInt32("House"),
                    bStaff = reader.GetInt32("Staff"),
                    bTemp = reader.GetInt32("Temp"),
                    bUpg = reader.GetInt32("Upg"),
                    iCost = reader.GetInt32("Cost"),
                    IDps = reader.GetInt32("DPS"),
                    iLvl = reader.GetInt32("Lvl"),
                    iHrs = -1,
                    iQSIndex = -1,
                    iQSValue = 0,
                    iQty = reader.GetInt32("Qty"),
                    IRng = reader.GetInt32("Rng"),
                    iRty = reader.GetInt32("Rty"),
                    SDesc = reader.GetString("Desc"),
                    iStk = reader.GetInt32("Stk"),
                    SName = reader.GetString("Name"),
                    SFile = reader.GetString("File"),
                    SLink = reader.GetString("Link"),
                    SType = reader.GetString("Type"),
                    SEs = reader.GetString("ES"),
                    sIcon = reader.GetString("Icon"),
                    SElmt = reader.GetString("Elmt"),
                    sMeta = reader.GetString("Meta"),
                    sReqQuests = reader.GetString("ReqQuests"),
                    ClassId = reader.GetInt32("ClassID")
                };

                Items.Add(item.ItemId, item);
            }

            reader.Close();
            reader.Dispose();

            Console.WriteLine($"Cached {Items.Count} items.");
        }
    }
}
