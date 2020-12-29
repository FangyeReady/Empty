using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第六课_面向对象三大特性作业
{
    abstract class Character
    {
        protected string _name;
        protected int _atk;
        protected int _def;
        protected int _hp;

        public string Name { get { return _name; } }
        public int ATK { get { return _atk; } }
        public int Def { get { return _def; } }
        public int HP { get { return _hp; } }


        public Character(string name, int atk, int def, int hp)
        {
            _name = name;
            _atk = atk;
            _def = def;
            _hp = hp;
        }

        public abstract void OnHurt(int damage);

        public abstract void Attack(Character ch);

        protected abstract void Death();

    }


    class Hero : Character
    {

        public Hero(string name, int atk, int def, int hp) : base(name, atk, def, hp)
        { 
        
        }

        public override void Attack(Character ch)
        {
            ch.OnHurt(ATK);

        }

        protected override void Death()
        {
            GameManager.GameEnd = true;
        }

        public override void OnHurt(int damage)
        {
            int result = damage - _def; 
            if (result < 0)
            {
                result = 0;
            }

            _hp -= result;
            if (_hp <= 0)
            {
                _hp = 0;
                Death();
            }
        }
    }

    class Monster : Character
    {

        public Monster(string name, int atk, int def, int hp) : base(name, atk, def, hp)
        {

        }

        public override void Attack(Character ch)
        {
            ch.OnHurt(ATK);
        }

        protected override void Death()
        {
            GameManager.GameEnd = true;
        }

        public override void OnHurt(int damage)
        {
            int result = damage - _def;
            if (result < 0)
            {
                result = 0;
            }

            _hp -= result;
            if (_hp < 0)
            {
                _hp = 0;
                Death();
            }
        }
    }

    class Solider : Character
    {
        public Solider(string name, int atk, int def, int hp) : base(name, atk, def, hp)
        {

        }

        public override void Attack(Character ch)
        {
            ch.OnHurt(ATK);
        }

        protected override void Death()
        {
            GameManager.GameEnd = true;
        }

        public override void OnHurt(int damage)
        {
            int result = damage - _def;
            if (result < 0)
            {
                result = 0;
            }

            _hp -= result;
            if (_hp < 0)
            {
                _hp = 0;
                Death();
            }
        }
    }


}
