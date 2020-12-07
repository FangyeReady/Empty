using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第七课_结构体和枚举的作业
{
    enum RoleType
    {
        Monster,
        Solider,
    }


    enum Fruits
    {
        Apple,
        Orange,
        Banana
    }

    struct Equipment
    {
        public string Name;
        public int ID;
        public int Hp;
        public int Atk;
        public int Def;
    }

    struct RoleData
    {
        public RoleType roleType;

        public string Name;
        public int Hp;
        public int Atk;
        public int Def;
    }





    

}
