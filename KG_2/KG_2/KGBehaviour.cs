using KG_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public abstract class KGBehaviour : IAwake, IStart, IUpdate
    {
        public bool Enabled, Started = false;
        
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
        //인터페이스 받기(Awake로 실행받을거임)
        void IAwake.Awake() => Awake_KGB();
        void IStart.Start() => Start_KGB();
        void IUpdate.Update() => Update_KGB();
    }
}
