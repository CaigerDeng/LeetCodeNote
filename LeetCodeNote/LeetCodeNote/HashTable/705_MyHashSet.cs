using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace LeetCodeNote.HashTable
{
    public class Solution_705_MyHashSet
    {
        // 单独链表法 
        public class MyHashSet_0
        {
            // 链地址法
            // BASE取质数的解释
            // https://leetcode-cn.com/problems/design-hashset/solution/she-ji-ha-xi-ji-he-by-leetcode-solution-xp4t/829819
            private const int BASE = 769;
            private LinkedList<int>[] data; 

            /** Initialize your data structure here. */
            public MyHashSet_0()
            {
                data = new LinkedList<int>[BASE];
                for (int i = 0; i < BASE; i++)
                {
                    data[i] = new LinkedList<int>();
                }

            }

            public void Add(int key)
            {
                int h = Hash(key);
                if (Contains(key))
                {
                    return;
                }               
                data[h].AddLast(key);

            }

            public void Remove(int key)
            {
                int h = Hash(key);
                if (Contains(key))
                {
                    data[h].Remove(key);
                }

            }

            /** Returns true if this set contains the specified element */
            public bool Contains(int key)
            {
                // C#的枚举器没有hasNext功能，所以要查有无重复key时就得自己写for循环
                int h = Hash(key);
                for (int i = 0; i < data[h].Count; i++)
                {
                    var item = data[h];
                    if (item.Contains(key))
                    {
                        return true;
                    }
                }
                return false;
                
            }

            private int Hash(int key)
            {
                return key % BASE;

            }

        }



    }

  

}