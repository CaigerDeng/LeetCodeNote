using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 134. 加油站
    /// https://leetcode.cn/problems/gas-station/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>


    public class Solution_134
    {
        public void Run()
        {
            //int[] gas = { 1, 2, 3, 4, 5 };
            //int[] cost = { 3, 4, 5, 1, 2 };

            //int[] gas = { 2, 3, 4 };
            //int[] cost = { 3, 4, 3 };


            //int[] gas = { 1, 2, 3, 4, 3, 2, 4, 1, 5, 3, 2, 4 };
            //int[] cost = { 1, 1, 1, 3, 2, 4, 3, 6, 7, 4, 3, 1 };

            int[] gas = { 5, 1, 2, 3, 4 };
            int[] cost = { 4, 4, 1, 5, 1 };

            int index = CanCompleteCircuit_My_1(gas, cost);
            Console.WriteLine("index:{0}", index);


        }


        // 我的题解0，没有特别算法，按题意直写
        // 没通过！如果数组过大，会超过时限！
        public int CanCompleteCircuit_My_0(int[] gas, int[] cost)
        {
            int allGas = gas.Sum();
            int allCost = cost.Sum();
            if (allCost > allGas)
            {
                return -1;
            }
            int index = -1;
            int n = gas.Length;
            for (int i = 0; i < n; i++)
            {
                if (cost[i] > gas[i])
                {
                    continue;
                }
                int j = i;
                int leftGas = 0;
                while (leftGas >= 0)
                {
                    leftGas += gas[j] - cost[j];
                    if (leftGas >= 0)
                    {
                        j = (j + 1) % n;
                        if (j == i)
                        {
                            return i;
                        }
                    }
                }
            }
            return index;

        }

        // 我的题解1，在“我的题解0”的基础上针对数组过大的情况做了优化，把算总和的步骤分散到for循环里（“快进”的设计），这样时间复杂度就是O(n)
        // 通过！
        public int CanCompleteCircuit_My_1(int[] gas, int[] cost)
        {
            int index = -1;
            int n = gas.Length;
            int beforGas = 0;
            for (int i = 0; i < n; i++)
            {
                bool canSkip = false;
                if (gas[i] >= cost[i])
                {
                    int nowGas = 0;
                    for (int j = i; j < n; j++)
                    {
                        nowGas += gas[j] - cost[j];
                        if (nowGas < 0)
                        {
                            // 因为起点油量为0（也就是说起点肯定没问题），
                            // i快进到出问题的那个点j，因为是到这个点j才出了问题，所以i到j之间的点都不用再考虑，这之间的点到j肯定出问题。
                            // 下一次最外层for循环i就会从j+1出发。
                            i = j;
                            beforGas += nowGas;
                            canSkip = true;
                            break;
                        }
                    }
                    if (canSkip == false && nowGas >= 0 && nowGas + beforGas >= 0)
                    {
                        index = i;
                        break;
                    }
                }
                if (canSkip == false)
                {
                    beforGas += gas[i] - cost[i];
                }
            }
            return index;

        }

        // 官方题解，解释没写人话，但大意和“我的题解1”是一样的。


        // method 1-他人题解1
        // 他写的比我更清楚简洁，他没有设计“跳过”，而是记录了峰底，从峰底出发就没问题，因为后面再怎么低都是上升
        // https://leetcode.cn/problems/gas-station/solutions/488357/jia-you-zhan-by-leetcode-solution/comments/2436428
        // 我暂时也想不出balance>=0但无解的例子。
        public int CanCompleteCircuit_1(int[] gas, int[] cost)
        {
            // 最低可能的油量，可能为负，表示出发前借的油
            int minBalance = 0;
            // 达到最低油量的加油站索引，在此加油站出发
            // 油量不会低于最低值，所以此加油站即为题目所求
            int minIndex = 0;
            int n = gas.Length;
            int balance = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                // 计算后的balance为到达下一加油站 i + 1的油量，如果创了新低则记录之
                balance = balance + gas[i] - cost[i];
                if (balance < minBalance)
                {
                    minBalance = balance;
                    minIndex = i + 1;
                }
            }
            // 从第一个加油站出发，如果油量恢复到出发前以上，代表可能跑完一圈
            // 在中间出现负值也没有关系，可以想象出发前向别人借了一些油，最后
            // 能还上就可以了
            return balance >= 0 ? minIndex : -1;

        }


    }


}
