using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Village
    {
        //Manor
        public int manorLevel = 1;
        public string manorDescription = "Main building of the village where you live.";

        //House 
        public int houseLevel = 1;
        public string houseDescription = "Everyone needs a place to sleep easily at night, right?";

        //Farm
        public int farmLevel = 1;
        public string farmDescription = "If you treat soil well soil will reward you.";

        //Well
        public int wellLevel = 1;
        public string wellDescription = "You can easily get water from well, just don't fall into it.";

        //WoodCutter
        public int woodcutterLevel = 1;
        public string woodcutterDescription = "Main source of wood, obviously.";

        //StoneMine
        public int stonemineLevel = 1;
        public string stonemineDescription = "Main source of stone, beware of monsters.";

        //Market
        public int marketLevel = 0;
        public string marketDescription = "Drink with your friend, eat with your friend; but don't trade with your friend.";
    }
}
