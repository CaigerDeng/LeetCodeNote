using System;

namespace LeetCodeNote.Heap
{
    /// <summary>
    /// 剑指 Offer 40. 最小的k个数
    /// https://leetcode-cn.com/problems/zui-xiao-de-kge-shu-lcof/
    /// </summary>


    public class Solution_Offer40_GetLeastNumbers
    {
        // method 0
        public int[] GetLeastNumbers_0(int[] arr, int k)
        {
            System.Array.Sort(arr);
            int[] res = new int[k];
            System.Array.Copy(arr, 0, res, 0, k);
            return res;

        }

        // method 1
        public int[] GetLeastNumbers_1(int[] arr, int k)
        {
            int[] res = new int[k];
            if (k == 0)
            {
                return res;
            }
            MaxHeap h = new MaxHeap(k);
            for (int i = 0; i < arr.Length; i++)
            {
                h.Push(arr[i]);
            }
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = h.Pop();
            }
            return res;

        }

        // method 2
        public int[] GetLeastNumbers_2(int[] arr, int k)
        {
            QuickSortDetail(arr, 0, arr.Length - 1, k);
            int[] res = new int[k];
            System.Array.Copy(arr, res, k);
            return res;

        }

        private void QuickSortDetail(int[] arr, int left, int right, int k)
        {
            if (left >= right)
            {
                return;
            }
            int pos = Partition(arr, left, right);
            int count = pos - left + 1;
            // 以pos对应值A为分界点，小于A的数放前面，如果A和这些数够k个，则完成计算
            if (count == k)
            {
                return;
            }
            // A和这些数太多，则缩小范围
            else if (count > k)
            {
                QuickSortDetail(arr, left, pos - 1, k);
            }
            // A和这些数太少，则扩大范围
            else
            {
                QuickSortDetail(arr, pos + 1, right, k - count);
            }

        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    if (i != j)
                    {
                        Swap(arr, i, j);
                    }
                    i++;
                }
            }
            Swap(arr, i, right);
            return i;

        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

        }















        /// <summary>
        /// 大顶堆
        /// </summary>
        public class MaxHeap
        {
            private int[] data;
            public int capacity;
            public int count;

            public MaxHeap(int capacity)
            {
                this.capacity = capacity;
                // 索引0不放数据，从索引1开始放，这样方便堆化时算其他索引，比如：求索引2和3的父索引，直接整除2得到1
                data = new int[capacity + 1];
                count = 0;

            }

            public void Push(int val)
            {
                if (count < capacity)
                {
                    count++;
                    data[count] = val;
                    Up(count);
                }
                else if (val < data[1])
                {
                    data[1] = val;
                    Down(1);
                }

            }

            public int Pop()
            {
                if (count == 0)
                {
                    throw new IndexOutOfRangeException("IndexOutOfRangeException");
                }
                int top = GetTop();
                data[1] = data[count];
                count--;
                Down(1);
                return top;

            }


            /// <summary>
            /// 上浮
            /// </summary>
            /// <param name="index"></param>
            public void Up(int index)
            {
                // 因为索引0不放数据，所以其他索引直接整除2即可（如果索引0放数据，求索引2的父索引还要减法这些）
                while (index / 2 > 0 && data[index] > data[index / 2])
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
                int maxPos = index;
                int leftChildIndex = 2 * index;
                int rightChildIndex = 2 * index + 1;
                if (leftChildIndex <= count && data[maxPos] < data[leftChildIndex])
                {
                    maxPos = leftChildIndex;
                }
                if (rightChildIndex <= count && data[maxPos] < data[rightChildIndex])
                {
                    maxPos = rightChildIndex;
                }
                if (maxPos != index)
                {
                    Swap(index, maxPos);
                    Down(maxPos);
                }

            }

            public int GetTop()
            {
                return data[1];

            }

        }



    }
}