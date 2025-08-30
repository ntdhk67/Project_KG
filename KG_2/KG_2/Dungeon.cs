using KG_2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public sealed class Dungeon
    {
        public readonly Random _rng = new Random();

        protected List<EntityBase> _changeEnable = new List<EntityBase>();
        protected List<EntityBase> _changeDisable = new List<EntityBase>();
        protected List<EntityBase> _enable = new List<EntityBase>();

        public List<EntityBase> _Monsters = new List<EntityBase>();
        public List<EntityBase> _Humans = new List<EntityBase>();

        private bool _changer = false,_a=false;

        public void Death_Dungeon(EntityBase KGB)
        {
            _changeDisable.Remove(KGB);
            _changeEnable.Remove(KGB);
            _enable.Remove(KGB);
            _Monsters.Remove(KGB);
            _Humans.Remove(KGB);
        }
        public void Disable_Dungeon(EntityBase KGB)
        {
            if(KGB.Enabled==false)
            {
                return;
            }
            _changeDisable.Add(KGB);
            _changer = true;
        }
        public void Enable_Dungeon(EntityBase KGB)
        {
            if (KGB.Enabled == true)
            {
                return;
            }
            _changeEnable.Add(KGB);
            _changer = true;
        }
        private void ChangeEnableAndDisable()
        {
            if(_changer==false)
            {
                return;
            }

            foreach(EntityBase changeDisable in _changeDisable)
            {
                if(changeDisable.Enabled==false)
                {
                    continue;
                }
                changeDisable.Enabled = false;
                _enable.Remove(changeDisable);
            }
            _changeDisable.Clear();
            foreach (EntityBase changeEnable in _changeEnable)
            {
                if(changeEnable.Enabled==true)
                {
                    continue;
                }
                if(changeEnable.Started==false)
                {
                    changeEnable.Start();
                }
                changeEnable.Enabled = true;
                _enable.Add(changeEnable);
            }
            _changeEnable.Clear();
            _changer = false;
        }
        private void Input()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Spacebar)
            {
                GameManager.cases = Cases.InDungeon;
            }
            else if (key.Key == ConsoleKey.A)
            {
                GameManager.cases = Cases.InDungeon;
                _a = true;
            }


        }
        public void Awake_Dungeon()
        {

            if (_a == false)
            {
                Console.WriteLine("스페이스바나 A");
                Input();
            }
            else
            {
                GameManager.cases = Cases.InDungeon;
            }
            _Humans.Clear();
            _Monsters.Clear();
            _enable.Clear();
            _changeEnable.Clear();
            _changeDisable.Clear();
            _changer = false;
            MonsterSet();
            HumanSet();
        }
        private void MonsterSet()
        {

            for (int i = 0; i < _rng.Next(1, 11); i++)
            {
                switch (_rng.Next(0, 3))
                {
                    case 0:
                        _Monsters.Add(new Skeleton());
                        break;

                    case 1:
                        _Monsters.Add(new Slime());
                        break;
                    case 2:
                        _Monsters.Add(new Orc());
                        break;

                }
            }
        }
        private void HumanSet()
        {

            for (int i = 0; i < _rng.Next(1, 11); i++)
            {
                switch (_rng.Next(0, 3))
                {
                    case 0:
                        _Humans.Add(new Knight());
                        break;

                    case 1:
                        _Humans.Add(new Archer());
                        break;
                    case 2:
                        _Humans.Add(new Mage());
                        break;

                }
            }
        }
        public void Start_Dungeon()
        {

        }
        
        public void Update_Dungeon()
        {

            if(End()==false)
            {
                foreach (EntityBase monster in _Monsters)
                {
                    monster.Update();
                }
                //ChangeEnableAndDisable();
                foreach (EntityBase human in _Humans)
                {
                    human.Update();
                }
                //ChangeEnableAndDisable();
            }
        }
        private bool End()
        {
            if (_Monsters.Count==0||_Humans.Count==0)
            {
                GameManager.cases = Cases.End;
                return true;
            }
            return false;
        }
    }
}