using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    class MyClass5
    {
        //属性可以只有一个访问器: set或get
        private int _data;
        public int Data
        {
            //此处仅有set访问器, 因此也无法被访问
            set {
                _data = value;
            }
        }

        public int Data2
        {
            //此处仅有get访问器, 因此仅可以被访问,但是不能被设置值
            get {
                return _data;
            }
        }


        public int Data3
        {
            //属性允许被访问修饰符修饰, 因此该访问器仅可以在类内部访问
            private set {
                _data = value;
            }

            //默认为public
            get {
                return _data;
            }
        }

        //此处系统会为Data4自动创建一个私有变量用于使用
        public int Data4
        {
            set;
            get;
        }




        public void SetValue()
        {
            Data3 = 2;
        }



    }
}
