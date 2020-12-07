using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class StudyDcitionary
    {
        public void Study()
        {
            //Dictionary<T,T> 字典
            //初始化一个字典
            Dictionary<string, int> dic = new Dictionary<string, int>();
            //向字典添加元素
            dic.Add("Fangye", 100);
            //如果dic中有"9cheng"的键值的话,此处是修改这个键对应的值;
            //如果没有,则是添加
            dic["9cheng"] = 99;
            Console.WriteLine("值: " + dic["9cheng"]);
            //根据key值,取得value值
            int val = dic["Fangye"];
            Console.WriteLine("值: " + val);
            //修改值
            dic["Fangye"] = 88;
            Console.WriteLine("值: " + dic["Fangye"]);

            //判断dic中是否有键
            if (dic.ContainsKey("9cheng"))
            {
                Console.WriteLine("访问key为:9cheng的元素: " + dic["9cheng"]);
            }
            //判断dic中是否有对应的值
            if (dic.ContainsValue(9999))
            {
                dic["9cheng2"] = 9999;
                Console.WriteLine("字典中有值9999");
            }

            //移除dic中的键值对: KeyValuePair
            bool isRemove = dic.Remove("9cheng2");
            if (isRemove)
            {
                Console.WriteLine("移除成功!");
            }

            //尝试取得key所关联的值
            int val2;
            bool isGet = dic.TryGetValue("9cheng2", out val2);
            if (isGet)
            {
                Console.WriteLine("尝试取得数据成功,  值为:" + val2);
            }
            else
            {
                Console.WriteLine("尝试取得数据失败");
            }

            //字典中的元素个数
            //dic.Count;
            //清空字典
            //dic.Clear();



            //被var关键字修饰的变量,必须在声明时即赋值,它会通过等号右侧的表达式推算出变量的类型
            var val3 = new List<int>();
            //collection:集合
            //foreach中的item即集合中的元素, 此处是KeyValuePair的结构体
            foreach (var item in dic)
            {
                //此处报错, 因为foreach中不能直接修改item
                //item.Value = 100;

                //可以通过item修改字典的内容
                dic[item.Key] = 100;


                //遍历取得内容
                Console.WriteLine("键:" + item.Key + "  值:" + item.Value);
            }

            List<int> list2 = new List<int>(new int[] { 1, 2, 3 });
            //foreach中的item即集合中的元素, 此处是int类型的元素
            foreach (var item in list2)
            {
                Console.WriteLine(item);

            }
        }


    }
}
