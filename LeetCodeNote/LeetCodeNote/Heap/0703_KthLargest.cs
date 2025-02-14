using System;
using System.Collections.Generic;

namespace LeetCodeNote.Heap
{
    /// <summary>
    /// 703. 数据流中的第 K 大元素
    /// https://leetcode-cn.com/problems/kth-largest-element-in-a-stream/
    /// </summary>

    public class Solution_703_KthLargest
    {
        // method 0
        // 用列表排序实现，但会超出时限，也和堆无关
        public class KthLargest_0
        {
            private int k;
            private int kData;
            private List<int> dataList;

            public KthLargest_0(int k, int[] nums)
            {
                this.k = k;
                dataList = new List<int>(nums);
                dataList.Sort();
                int num = dataList.Count - k;
                for (int i = 0; i < Math.Abs(num); i++)
                {
                    if (num > 0)
                    {
                        dataList.RemoveAt(0);
                    }
                    else
                    {
                        dataList.Insert(0, int.MinValue);
                    }
                }
                kData = dataList[0];

            }

            public int Add(int val)
            {
                if (val <= kData)
                {
                    return kData;
                }
                dataList.Add(val);
                dataList.Sort();
                int num = dataList.Count - k;
                for (int i = 0; i < num; i++)
                {
                    dataList.RemoveAt(0);
                }
                kData = dataList[0];
                return kData;

            }

        }

        // method 1
        public class KthLargest_1
        {
            public MinHeap h;

            public KthLargest_1(int k, int[] nums)
            {
                h = new MinHeap(k);
                foreach (int num in nums)
                {
                    h.Add(num);
                }

            }

            public int Add(int val)
            {
                h.Add(val);
                return h.GetTop();

            }


        }



        /// <summary>
        /// 小顶堆
        /// </summary>
        public class MinHeap
        {
            private int[] data;
            public int capacity;
            public int count;

            public MinHeap(int capacity)
            {
                this.capacity = capacity;
                // 索引0不放数据，从索引1开始放，这样方便堆化时算其他索引，比如：求索引2和3的父索引，直接整除2得到1
                data = new int[capacity + 1];
                count = 0;

            }

            public void Add(int val)
            {
                if (count < capacity)
                {
                    count++;
                    data[count] = val;
                    Up(count);
                }
                // val比top大才会加入
                else if (val > data[1])
                {
                    data[1] = val;
                    Down(1);
                }

            }

            /// <summary>
            /// 上浮
            /// </summary>
            /// <param name="index"></param>
            public void Up(int index)
            {
                // 因为索引0不放数据，所以其他索引直接整除2即可（如果索引0放数据，求索引2的父索引还要减法这些）
                while (index / 2 > 0 && data[index] < data[index / 2])
                {
                    Swap(index, index / 2);
                    index = index / 2;
                }

            }

            /// <summary>
            /// 交换索引为aIndex，bIndex的值
            /// </summary>
            /// <param name="aIndex"></param>
            /// <param name="bIndex"></param>
            private void Swap(int aIndex, int bIndex)
            {
                int temp = data[aIndex];
                data[aIndex] = data[bIndex];
                data[bIndex] = temp;

            }

            /// <summary>
            /// 下沉
            /// </summary>
            /// <param name="index"></param>
            private void Down(int index)
            {
                int minPos = index;
                int leftChildIndex = 2 * index;
                int rightChildIndex = 2 * index + 1;
                if (leftChildIndex <= count && data[minPos] > data[leftChildIndex])
                {
                    minPos = leftChildIndex;
                }
                if (rightChildIndex <= count && data[minPos] > data[rightChildIndex])
                {
                    minPos = rightChildIndex;
                }
                if (minPos != index)
                {
                    Swap(index, minPos);
                    Down(minPos);
                }

            }

            public int GetTop()
            {
                return data[1];

            }

        }


    }
}