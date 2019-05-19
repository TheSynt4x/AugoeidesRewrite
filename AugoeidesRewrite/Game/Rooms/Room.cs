using AugoeidesRewrite.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Game.Rooms
{
    class Room
    {
        public void FirstJoin(string mapName)
        {
            var roomId = Cache.Instance.Maps.Where(x => x.Value.Name == mapName).First().Value.Id;
            Cache.Instance.Maps.TryGetValue(roomId, out Maps map);

            
        }
    }
}
