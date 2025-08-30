using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public class HumanBase:EntityBase
    {
        public HumanBase(int hp, int ap, string name) : base(hp, ap, name) { }
        public override void AttackDamage()
        {
            if (_dungeon._Monsters.Count != 0)
            {
                EntityBase KGB = _dungeon._Monsters[_dungeon._rng.Next(_dungeon._Monsters.Count)];
                int dmg = _dungeon._rng.Next(AP, AP + 3);
                KGB.TakeDamage(dmg);
                Console.WriteLine($"{this.Name}->{KGB.Name} (데미지:{dmg},HP:{KGB.HP_Check})");
            }
        }
    }
}
