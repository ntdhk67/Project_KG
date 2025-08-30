using KG_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public abstract class KGBehaviour
    {
        public bool Enabled, Started = false;
        protected Dungeon _dungeon=GameManager._dungeon;


        public void Bind(Dungeon dungeon)
        {
            _dungeon = dungeon;
        }

        //실제 사이클

        protected virtual void Awake_KGB()
        {

        }
        protected virtual void Start_KGB()
        {

        }
        protected virtual void Update_KGB()
        {

        }
        protected abstract void Death_KGB();
        protected abstract void Enable_KGB();
        protected abstract void Disable_KGB();



        //받기
        public void Awake()
        {
            Awake_KGB();
        }
        public void Start()
        {
            if(Started==true)
            {
                return;
            }
            Start_KGB();
            Started = true;
        }
        public void Update()
        {
            Update_KGB();
        }
        public void Enable()
        {
            Enable_KGB();
        }
        public void Disable()
        {
            Disable_KGB();
        }
        public void Death()
        {
            Death_KGB();
        }
    }
}
