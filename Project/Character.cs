using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Character
    {
        public string? name;
        public int level = 1;
        public double experience = 0;
        public int maxExperience;
        public int health;
        public int maxHealth;
        public int attack;
        public int defence;

        public Character()
        {
            maxExperience = 100 * level;
            health = 100 + level * 10;
            maxHealth = health;
            attack = 20 + level * 5;
            defence = 10 + level * 5;
        }
    }
}
