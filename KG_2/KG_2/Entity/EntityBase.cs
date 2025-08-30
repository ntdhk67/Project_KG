using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public abstract class EntityBase:KGBehaviour
    {
        protected int HP { get; set; }
        public int HP_Check => HP;
        protected int AP { get; }
        public string Name {get;}
        protected Random random => _dungeon._rng;
        protected EntityBase(int hp,int ap,String name)
        {
            HP = hp;
            AP = ap;
            Name = name;
        }
        //라이프 사이클
        protected override void Awake_KGB()
        {

        }
        protected override void Start_KGB()
        {

        }
        protected override void Update_KGB()
        {
            AttackDamage();
        }
        //기타 처리
        protected override void Death_KGB()
        {
            _dungeon.Death_Dungeon(this);
            //불변수
        }
        protected override void Disable_KGB()
        {
            _dungeon.Disable_Dungeon(this);
        }
        protected override void Enable_KGB() 
        {
            _dungeon.Enable_Dungeon(this);
        }
        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if(HP<=0)
            {
                Death_KGB();
                //불변수
            }
        }
        public abstract void AttackDamage();
    }
}
