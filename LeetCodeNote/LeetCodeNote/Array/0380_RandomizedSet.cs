using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 380. O(1) 时间插入、删除和获取随机元素
    /// https://leetcode.cn/problems/insert-delete-getrandom-o1/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_380
    {
        public void Run()
        {



        }

        // 我的题解0
        // 没想出来！不知道随机方法怎么实现。
        public class RandomizedSet_My_0
        {
            private Dictionary<int, int> dic;


            public RandomizedSet_My_0()
            {
                dic = new Dictionary<int, int>();

            }

            public bool Insert(int val)
            {
                if (!dic.ContainsKey(val))
                {
                    dic.Add(val, val);
                    return true;
                }
                return false;

            }

            public bool Remove(int val)
            {
                if (dic.ContainsKey(val))
                {
                    dic.Remove(val);
                    return true;
                }
                return false;

            }

            public int GetRandom()
            {
                // 插入、删除用数组或词典实现都可以，但不知道在O(1)复杂度下随机方法怎么实现。
                Random rand = new Random();
                rand.Next(int.MaxValue);

                return 0;

            }

        }

        // method 1 官方题解一
        // 竟然是词典和列表的结合！我的题解0只考虑了二者中的一个，没想过要写一块！
        public class RandomizedSet_1
        {
            private List<int> numList;
            private Dictionary<int, int> indexDic;
            private Random random;


            public RandomizedSet_1()
            {
                numList = new List<int>();
                indexDic = new Dictionary<int, int>();
                random = new Random();

            }

            public bool Insert(int val)
            {
                if (indexDic.ContainsKey(val))
                {
                    return false;
                }
                int index = numList.Count;
                numList.Add(val);
                indexDic.Add(val, index);
                return true;

            }

            public bool Remove(int val)
            {
                if (!indexDic.ContainsKey(val))
                {
                    return false;
                }
                // 为了保证复杂度O(1)，所以“删除”改成删除掉最后一个元素
                int index = indexDic[val];
                int lastIndex = numList.Count - 1;
                int v = numList[lastIndex];
                numList[index] = v;
                numList.RemoveAt(lastIndex);

                indexDic[v] = index;
                indexDic.Remove(val);

                return true;

            }

            public int GetRandom()
            {
                int randomIndex = random.Next(numList.Count);
                return numList[randomIndex];

            }

        }




    }




}
