using System;

namespace FightSim
{
    public class Fighter
    {
        public string name;
        private bool isAlive = true;
        public int hp = 100;
        public string equipped;

        public Weapon w = new Weapon();


        public void Attack(Fighter target)
        {
            w.Damage(target);
        }

        public void FighterWeaponDamage(Fighter f)
        {
            w.DetermineDamage(f);
        }

        public bool GetAlive()
        {
            isAlive = !(hp <= 0);

            return isAlive;
        }
    }
}