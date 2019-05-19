using AugoeidesRewrite.Database.Query;
using AugoeidesRewrite.Game.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Networking.Handlers.Xml
{
    class HandlerLoginRequest : IXmlMessageHandler
    {
        public string[] HandledCommands { get; } = { "login" };

        public void Handle(XmlMessage message)
        {
            var username = message.Body.SelectSingleNode("//msg/body/login/nick").InnerText.Split(Convert.ToChar("~"))[1].ToLower();
            var password = message.Body.SelectSingleNode("/msg/body/login/pword").InnerText;

            MySqlDataReader reader = new ReaderQuery().Execute(
                "SELECT * FROM meh_users WHERE Username=@user AND Password=@pass", 
                new Dictionary<string, object>() {
                    { "user", username },
                    { "pass", password }
                }
            );

            if (reader.Read()) {
                PlayerInfo player = new PlayerInfo
                {
                    UserID = reader.GetInt32("id"),
                    CharID = reader.GetInt32("id"),
                    HairID = reader.GetInt32("HairID"),
                    bPermaMute = false,
                    dCreated = reader.GetString("DateCreated"),
                    dUpgExp = reader.GetString("UpgradeExpire"),
                    iAge = reader.GetInt32("Age"),
                    iBagSlots = reader.GetInt32("BagSlots"),
                    iBankSlots = reader.GetInt32("BankSlots"),
                    iCP = 0,
                    iDailyAds = 0,
                    iFounder = 0,
                    iHouseSlots = reader.GetInt32("HouseSlots"),
                    iUpg = 0,
                    iUpgDays = reader.GetInt32("UpgradeDays"),
                    intAccessLevel = reader.GetInt32("Access"),
                    intActivationFlag = reader.GetInt32("ActivationFlag"),
                    intCoins = reader.GetInt32("Coins"),
                    intGold = reader.GetInt32("Gold"),
                    intColorAccessory = reader.GetInt32("ColorAccessory"),
                    intColorBase = reader.GetInt32("ColorBase"),
                    intColorEye = reader.GetInt32("ColorEye"),
                    intColorHair = reader.GetInt32("ColorHair"),
                    intColorSkin = reader.GetInt32("ColorSkin"),
                    intColorTrim = reader.GetInt32("ColorTrim"),
                    intExp = reader.GetInt32("Exp"),
                    intExpToLevel = 50000,
                    intHP = 1000,
                    intHPMax = 1000,
                    intMP = 100,
                    intMPMax = 100,
                    intHits = 1,
                    intLevel = reader.GetInt32("Level"),
                    strEmail = reader.GetString("Email"),
                    sHouseInfo = new JArray(),
                    strGender = reader.GetString("Gender"),
                    strHairFilename = reader.GetString("HairFile"),
                    strHairName = reader.GetString("HairName"),
                    strUsername = reader.GetString("Username").ToLower(),
                    iBoostCP = 0,
                    iBoostG = 0,
                    iBoostRep = 0,
                    iBoostXP = 0,
                    iDBCP = 0,
                    intDBExp = reader.GetInt32("Exp"),
                    intDBGold = reader.GetInt32("Gold"),
                    sCountry = "xx",
                    strMapName = "battleon",
                    strQuests = "00000000000000000000000000000000000000000000000000000000000000000000000000000000A0000000000000000000",
                    strQuests2 = "00000000000000000000000000000000000000000000000000000000000000000000000000000000A0000000000000000000",
                    strQuests3 = "00000000000000000000000000000000000000000000000000000000000000000000000000000000A0000000000000000000",
                    bitSuccess = 1,
                    lastArea = "battleon-2"
                };

                var d = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                message.Write("%xt%server%-1%Accepting party invites.%");
                message.Write("%xt%server%-1%Accepting goto requests.%");
                message.Write("%xt%server%-1%Accepting Friend requests.%");
                message.Write("%xt%server%-1%Accepting PMs.%");
                message.Write("%xt%server%-1%Ability ToolTips will always show on mouseover.%");
                message.Write("%xt%server%-1%Accepting duel invites.%");
                message.Write("%xt%server%-1%Accepting guild invites.%");
                message.Write($"%xt%loginResponse%-1%true%{player.CharID}%{player.strUsername}%{Settings.Motd}%{d}%sNews={Settings.News},sMap={Settings.Map},sBook={Settings.Book},sFBC={Settings.Fbc},sAssets={Settings.Assets},sWTSandbox=false,gMenu={Settings.GameMenu},sVideo=MoviePlayer/MoviePlayer1.swf1r118222%");
            }

            reader.Close();
            reader.Dispose();
        }
    }
}
