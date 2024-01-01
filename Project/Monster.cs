using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Monster
    {
        public string name;
        public int level = 1;
        public int health;
        public int maxHealth;
        public int attack;
        public int defence;
        public int index;

        //Forest Monsters
        public void Slime(int level)      //Chance: 4/10
        {
            this.level = level;
            name = "Slime";
            health = 10 + level * 8;
            maxHealth = health;
            attack = 2 + level * 4;
            defence = 3 + level * 3;
            index = 1;
        }
        public void Goblin(int level)     //Chance: 3/10
        {
            this.level = level;
            name = "Goblin";
            health = 30 + level * 6;
            maxHealth = health;
            attack = 10 + level * 6;
            defence = 8 +  level * 5;
            index = 2;
        }
        public void Wolf(int level)       //Chance: 2/10
        {
            this.level = level;
            name = "Wolf";
            health = 50 +level * 7;
            maxHealth = health;
            attack = 15 + level * 6;
            defence = 12 + level * 6;
            index = 3;
        }
        public void AlphaWolf(int level)  //Chance: 1/10
        {
            this.level = level;
            name = "Alpha Wolf";
            health = 100 + level * 10;
            maxHealth = health;
            attack = 20 + level * 10;
            defence = 20 + level * 10;
            index = 4;
        }
    }
}
