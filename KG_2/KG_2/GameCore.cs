using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public class GameCore
    {
        public void Run() //main이 static일때 인스턴스로 만든 awake 등등 작동을 안해먹었네? -> 빼버리자
        {
            Awake();
            Start();
            while (true)
            {
                Update();
            }
        }
        public void Awake() //기본세팅(프로그램 입장)
        {

        }
        public void Start() //기본세팅(플레이어 입장)
        {

        }
        public void Update() //그냥 흐름들
        {

        }
        
    }
}
