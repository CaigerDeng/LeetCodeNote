using System;
using System.Collections.Generic;

namespace LeetCodeNote.HashTable
{
    /// <summary>
    /// 204. 计数质数
    /// https://leetcode-cn.com/problems/count-primes/
    /// </summary>

    public class Solution_204_CountPrimes
    {
        // method 0
        // 暴力法
        // https://leetcode-cn.com/problems/count-primes/solution/ji-shu-zhi-shu-bao-li-fa-ji-you-hua-shai-fa-ji-you/
        public int CountPrimes_0(int n)
        {
            int count = 0;
            // 要检测的数在[2, n)之间
            for (int i = 2; i < n; i++)
            {
                bool sign = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sign = false;
                        break;
                    }
                }
                if (sign)
                {
                    count++;
                }
            }
            return count;

        }

        // method 1
        // 暴力法 优化
        // https://leetcode-cn.com/problems/count-primes/solution/kuai-lai-miao-dong-shai-zhi-shu-by-sweetiee/
        public int CountPrimes_1(int n)
        {
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }
            return count;

        }

        private bool IsPrime(int n)
        {
            // 如果不是质数（素数），则必有一个因子<= Sqrt(n)，另一个因子>=Sqrt(n)
            int a = (int)Math.Sqrt(n);
            for (int i = 2; i <= a; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;

        }

        // method 2
        // 埃氏筛
        public int CountPrimes_2(int n)
        {
            bool[] primeArr = new bool[n];
            for (int i = 0; i < primeArr.Length; i++)
            {
                // 先假设所有值都是质数
                primeArr[i] = true;
            }
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (primeArr[i] == true)
                {
                    count++;
                    // 用int可能会超出范围
                    if ((long)i * i < n)
                    {
                        for (int j = i * i; j < n; j += i)
                        {
                            // 质数的2倍，3倍...当然不是质数
                            primeArr[j] = false;
                        }
                    }
                }
            }
            return count;

        }

        // method 3
        // 线性筛
        public int CountPrimes_3(int n)
        {
            List<int> primeList = new List<int>();
            bool[] primeArr = new bool[n];
            for (int i = 0; i < primeArr.Length; i++)
            {
                // 先假设所有值都是质数
                primeArr[i] = true;
            }
            for (int i = 2; i < n; i++)
            {
                if (primeArr[i])
                {
                    primeList.Add(i);
                }
                for (int j = 0; j < primeList.Count && i * primeList[j] < n; j++)
                {
                    // 质数乘以某个数才得到i，则i肯定不是质数
                    primeArr[i * primeList[j]] = false;
                    // ...不重复标记合数
                    if (i % primeList[j] == 0)
                    {
                        break;
                    }
                }
            }
            return primeList.Count;

        }




    }



}