using KG_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public enum Cases
    {
        Start,
        InDungeon,
        End
    }
    public class GameManager
    {
        public static Dungeon _dungeon=new();

        public static Cases cases=Cases.Start;
        public int num = 0;//돈 횟수
        //List (몬스터,플레이어 예정)

        public void KGMain()
        {
            Console.Write(num);
            while (true)
            {
                switch (cases)
                {
                    case Cases.Start:
                        _dungeon.Awake_Dungeon();
                        break;
                    case Cases.InDungeon:
                        _dungeon.Update_Dungeon();
                        break;
                    case Cases.End:
                        num++;
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(num);
                        Console.SetCursorPosition(Console.CursorLeft,Console.BufferHeight - 1);
                        cases = Cases.Start;
                        break;
                }
            }

        }
        //main이 static일때 인스턴스로 만든 awake 등등 작동을 안해먹었네? -> 빼버리자


    }
}
