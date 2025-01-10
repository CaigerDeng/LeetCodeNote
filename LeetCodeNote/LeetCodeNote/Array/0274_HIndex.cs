using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 274. H 指数
    /// https://leetcode.cn/problems/h-index/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_274
    {
        public void Run()
        {
            int[] citations = { 3, 0, 6, 1, 5 };
            int hIndex = HIndex_1(citations);
            Console.WriteLine("hIndex:{0}", hIndex);




        }


        // 我的题解0，没有特别算法，按题意直写
        public int HIndex_My_0(int[] citations)
        {
            int hIndex = 0;
            int n = citations.Length;
            // 为了后面遍历好算总共有几篇论文超过i，先把数组排序好
            System.Array.Sort(citations);
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (citations[j] >= i)
                    {
                        int times = n - j;
                        if (times >= i)
                        {
                            hIndex = Math.Max(hIndex, i);
                            break;
                        }
                    }
                }
            }
            return hIndex;

        }

        // method 1 官方题解一
        // 比我的题解0好，省了一层循环。
        public int HIndex_1(int[] citations)
        {
            System.Array.Sort(citations);
            int h = 0;
            int i = citations.Length - 1;
            // 虽然是从小到大的排序，但是从后往前遍历的
            while (i >= 0 && citations[i] > h)
            {
                i--;
                h++;
            }
            return h;

        }

        // method 2 官方题解二
        // 计数排序，就是把每篇论文的引用数都记下来，然后从后往前遍历，只要有超过当前索引的就完成！
        public int HIndex_2(int[] citations)
        {
            int n = citations.Length;
            int total = 0;
            int[] counter = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                int index = citations[i];
                if (index >= n)
                {
                    counter[n]++;
                }
                else
                {
                    counter[index]++;
                }
            }
            for (int i = n; i >= 0; i--) // 因为是求尽可能大的H指数，所以要从后往前遍历。
            {
                total += counter[i];
                if (total >= i)
                {
                    return i;
                }
            }
            return 0;

        }

        // method 3 官方题解三
        // 二分搜索，即用二分法来找合适的H指数。
        public int HIndex_3(int[] citations)
        {
            int left = 0;
            int right = citations.Length;
            int mid = 0;
            while (left < right)
            {
                // 再加1是防止死循环，比如citations=[1]这种情况
                // 先取中值
                mid = (left + right + 1) / 2;
                int times = 0;
                for (int i = 0; i < citations.Length; i++)
                {
                    if (citations[i] >= mid)
                    {
                        times++;
                    }
                }
                if (times >= mid) // 如果总次数都比中值，显然中值还可以更大
                {
                    // 因为要返回结果是left，即结束循环时，left的值要正确，所以left要走的慢一点。
                    // 不然按照二分法习惯来写，left应该等于mid+1才是。
                    // 同样，因为left被赋值为mid，为了防止死循环（比如：citations=[1]这种情况），算mid公式有要加1。
                    left = mid; 
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;

        }

    }


}
