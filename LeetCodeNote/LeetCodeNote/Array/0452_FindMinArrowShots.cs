using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 452. 用最少数量的箭引爆气球
    /// https://leetcode.cn/problems/minimum-number-of-arrows-to-burst-balloons/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>
    public class Solution_0452
    {
        public void Run()
        {
            //int[][] points = new int[][]
            //{
            //    new int[]{10, 16},
            //    new int[]{2, 8},
            //    new int[]{1, 6},
            //    new int[]{7, 12},
            //};

            int[][] points = new int[][]
            {
                new int[]{3,9},
                new int[]{7,12},
                new int[]{3,8},
                new int[]{6,8},
                new int[]{9,10},
                new int[]{2,9},
                new int[]{0,9},
                new int[]{3,9},
                new int[]{0,6},
                new int[]{2,8},

            };


            int res = FindMinArrowShots_1(points);
            Console.WriteLine(res);


        }

        // (2025/5/8) method My 0-我的题解0
        // 错误写法！它没有求出最少的射箭数目。参考官方题解，我猜问题应该是出在没有排序因此漏掉了一些判断
        public int FindMinArrowShots_My_0(int[][] points)
        {
            // dic的值是允许射箭的最窄区间
            Dictionary<(int, int), (int, int)> dic = new Dictionary<(int, int), (int, int)>();
            for (int i = 0; i < points.Length; i++)
            {
                CheckDic(dic, points[i]);
            }
            return dic.Count;

        }

        private void CheckDic(Dictionary<(int, int), (int, int)> dic, int[] point)
        {
            (int, int) pos = (point[0], point[1]);
            if (dic.Count == 0)
            {
                dic.Add(pos, pos);
                return;
            }
            bool needAdd = true;
            foreach ((int, int) key in dic.Keys)
            {
                // 如果pos不在射箭范围内，直接检查下一个key
                if (pos.Item2 < dic[key].Item1 || pos.Item1 > dic[key].Item2)
                {
                   continue;
                }
                // 和已知气球区间有交叉，pos在允许射箭区间内，则更新射箭的最窄区间
                if (pos.Item1 >= key.Item1 && pos.Item1 <= key.Item2 || pos.Item2 >= key.Item1 && pos.Item2 <= key.Item2)
                {
                    needAdd = false;
                    (int, int) val = dic[key];
                    int a = Math.Max(pos.Item1, val.Item1);
                    int b = Math.Min(pos.Item2, val.Item2);
                    dic[key] = (a, b);
                    break;
                }
            }
            if (needAdd)
            {
                dic.Add(pos, pos);
            }

        }

        // method 1-官方题解1
        // 贪心：一定存在射出最小箭数的最优方法，即每支箭的射出位置都恰好对应着某个气球的右边界。
        // 时间复杂度：O(nlogn)（排序所耗），空间复杂度：O(logn)（排序所耗）
        public int FindMinArrowShots_1(int[][] points)
        {
            if (points.Length == 0)
            {
                return 0;
            }
            // 把气球的右边界做升序处理
            System.Array.Sort(points, (a, b)=> a[1].CompareTo(b[1]));
            int pos = points[0][1]; // 一号气球的右边界
            int num = 1;
            foreach (var balloon in points)
            {
                // 如果该气球的左边界比pos右边界大，说明俩气球隔得远
                // 因为前面做了排序，所以只需要下面一种判断，即离当前射箭位置（某气球的右边界）有距离，肯定是要一只新箭。
                if (balloon[0] > pos)
                {
                    pos = balloon[1];
                    num++;
                }
            }
            return num;

        }



    }




}
