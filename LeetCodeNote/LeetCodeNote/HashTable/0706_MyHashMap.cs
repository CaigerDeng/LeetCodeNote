using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 706. 设计哈希映射
    /// https://leetcode-cn.com/problems/design-hashmap/
    /// </summary>


    public class Solution_706_MyHashMap
    {

        public class MyHashMap
        {
            private class Pair
            {
                public int key { get; private set; }
                public int value;

                public Pair(int key, int value)
                {
                    this.key = key;
                    this.value = value;

                }

            }

            private const int BASE = 769;
            private LinkedList<Pair>[] data;


            /** Initialize your data structure here. */
            public MyHashMap()
            {
                data = new LinkedList<Pair>[BASE];
                for (int i = 0; i < BASE; i++)
                {
                    data[i] = new LinkedList<Pair>();
                }

            }

            /** value will always be non-negative. */
            public void Put(int key, int value)
            {
                int h = Hash(key);
                Pair pair = ContainsKey(key);
                if (pair != null)
                {
                    pair.value = value;
                }
                else
                {
                    pair = new Pair(key, value);
                    data[h].AddLast(pair);
                }

            }

            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key)
            {
                int h = Hash(key);
                Pair pair = ContainsKey(key);
                if (pair != null)
                {
                    return pair.value;
                }
                return -1;

            }

            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key)
            {
                int h = Hash(key);
                Pair pair = ContainsKey(key);
                if (pair != null)
                {
                    data[h].Remove(pair);
                }

            }

            private int Hash(int key)
            {
                return key % BASE;

            }

            // 比705难写的点是不知道LinkedList用在Pair上的Contains函数怎么写
            private Pair ContainsKey(int key)
            {
                int h = Hash(key);              
                Pair pair = data[h].FirstOrDefault(item => item.key == key);                
                return pair;

            }


        }


    }


}