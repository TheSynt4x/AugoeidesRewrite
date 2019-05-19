using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Game.Data
{
    class Skills
    {
        public int id { get; set; }
        public string nam { get; set; }
        public string icon { get; set; }
        public string desc { get; set; }
        public int mp { get; set; }
        public string anim { get; set; }
        public string Ref { get; set; }
        public string tgt { get; set; }
        public int tgtMax { get; set; }
        public string typ { get; set; }
        public int range { get; set; }
        public string fx { get; set; }
        public int cd { get; set; }
        public List<JObject> auras { get; set; }
        public string strl { get; set; }
        public bool auto { get; set; }
        public string dsrc { get; set; }
        public double damage { get; set; }
        public int tgtMin { get; set; }

        public Skills()
        {
            auras = new List<JObject>();
        }
    }
}
