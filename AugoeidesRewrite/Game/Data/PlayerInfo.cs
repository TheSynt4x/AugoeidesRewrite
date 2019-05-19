using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Game.Data
{
    class PlayerInfo : IDisposable
    {
        public int intColorAccessory { get; set; }
        public int iCP { get; set; }
        public int intLevel { get; set; }
        public int iBagSlots { get; set; }
        public int iBoostRep { get; set; }
        public int intColorBase { get; set; }
        public int iUpgDays { get; set; }
        public int intDays { get; set; }
        public string sCountry { get; set; }
        public string strQuests2 { get; set; }
        public int ip0 { get; set; }
        public int iq0 { get; set; }
        public string strQuests3 { get; set; }
        public int iAge { get; set; }
        public int intExpToLevel { get; set; }
        public int ip2 { get; set; }
        public int ip1 { get; set; }
        public double intMP { get; set; }
        public int intGold { get; set; }
        public JArray sHouseInfo { get; set; }
        public int ip4 { get; set; }
        public int id2 { get; set; }
        public int iBankSlots { get; set; }
        public int id1 { get; set; }
        public int ip3 { get; set; }
        public int id0 { get; set; }
        public int ip6 { get; set; }
        public int iHouseSlots { get; set; }
        public int ip5 { get; set; }
        public int intColorSkin { get; set; }
        public int id3 { get; set; }
        public double intMPMax { get; set; }
        public double intHPMax { get; set; }
        public string dUpgExp { get; set; }
        public int iBoostXP { get; set; }
        public int iUpg { get; set; }
        public int ip7 { get; set; }
        public int ip8 { get; set; }
        public int CharID { get; set; }
        public int ip9 { get; set; }
        public string strEmail { get; set; }
        public int intColorTrim { get; set; }
        public string lastArea { get; set; }
        public int im0 { get; set; }
        public int iFounder { get; set; }
        public int intDBExp { get; set; }
        public int intExp { get; set; }
        public int UserID { get; set; }
        public int intHits { get; set; }
        public int ia1 { get; set; }
        public int ia0 { get; set; }
        public double intHP { get; set; }
        public string dCreated { get; set; }
        public string strQuests { get; set; }
        public int iBoostG { get; set; }
        public int bitSuccess { get; set; }
        public bool bPermaMute { get; set; }
        public int intColorEye { get; set; }
        public string strHairName { get; set; }
        public int iDailyAds { get; set; }
        public int iDBCP { get; set; }
        public int intDBGold { get; set; }
        public int iBoostCP { get; set; }
        public int intActivationFlag { get; set; }
        public int intAccessLevel { get; set; }
        public string strHairFilename { get; set; }
        public int intColorHair { get; set; }
        public int HairID { get; set; }
        public string strGender { get; set; }
        public string strUsername { get; set; }
        public int iDailyAdCap { get; set; }
        public int intCoins { get; set; }
        public string strMapName { get; set; }

        public string strClassName { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
