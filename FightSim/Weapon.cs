using System;

namespace FightSim
{
    public class Weapon
    {
        public string name;
        public int weaponDmg;
        public int weaponDurability;

        public void Damage(Fighter target)
        {
            Random generator = new Random();
            int r = generator.Next(weaponDmg - 5, weaponDmg);
            target.hp -= r;
        }

        public void DetermineDamage(Fighter f)
        {
            if (f.equipped == "bow")
            {
                weaponDmg = 15;
            }
            else if (f.equipped == "sword")
            {
                weaponDmg = 20;
            }
        }
    }
}