using System;
using System.Collections.Generic;


namespace LeetCodeNote.Array
{
    /// <summary>
    /// 509. 斐波那契数
    /// https://leetcode-cn.com/problems/fibonacci-number/
    /// </summary>

    public class Solution_509
    {
        // method 0 
        // 默认求法
        public int Fib_0(int N)
        {
            if (N <= 1)
            {
                return N;
            }
            return Fib_0(N - 1) + Fib_0(N - 2);
        }

        // method 1 
        // 对method 0 的优化，使用数组记录算过的结果
        public int Fib_1(int N)
        {
            if (N <= 1)
            {
                return N;
            }
            return memoize_1(N);
        }

        private int memoize_1(int N)
        {
            int[] cache = new int[N + 1];
            cache[1] = 1;
            for (int i = 2; i <= N; i++) // 题目 N > 1
            {
                cache[i] = cache[i - 1] + cache[i - 2];
            }
            return cache[N];
        }

        // method 2 
        // 和method 1 意思一样，只不过method 1的for循环这里变成递归
        private int[] cache2 = new int[31];
        public int Fib_2(int N)
        {
            for (int i = 0; i < cache2.Length; i++)
            {
                cache2[i] = -1;
            }
            if (N <= 1)
            {
                return N;
            }
            cache2[0] = 0;
            cache2[1] = 1;
            return memoize_2(N);
        }

        private int memoize_2(int N)
        {
            if (cache2[N] != -1) // C#中cache2是有默认值的，用!= null不可
            {
                return cache2[N];
            }
            cache2[N] = memoize_2(N - 1) + memoize_2(N - 2);
            return memoize_2(N);
        }

        // method 3
        // 大脑直译
        public int Fib_3(int N)
        {
            if (N <= 1)
            {
                return N;
            }
            if (N == 2)
            {
                return 1;
            }
            int cur = 0;
            int pre1 = 1;
            int pre2 = 1;
            for (int i = 3; i <= N; i++)
            {
                cur = pre1 + pre2;
                pre2 = pre1;
                pre1 = cur;
            }
            return cur;
        }

        // 官方题解 https://leetcode-cn.com/problems/fibonacci-number/solution/fei-bo-na-qi-shu-by-leetcode/

        // method 4       
        // ...没看太懂
        public int Fib_4(int N)
        {
            if (N <= 1)
            {
                return N;
            }
            int[,] A = new int[,] { { 1, 1 }, { 1, 0 } };
            MatrixPower(A, N - 1);
            return A[0, 0];
        }

        private void MatrixPower(int[,] A, int N)
        {
            if (N <= 1)
            {
                return;
            }
            MatrixPower(A, N / 2);
            Multiply(A, A);
            int[,] B = new int[,] { { 1, 1 }, { 1, 0 } };
            if (N % 2 != 0)
            {
                Multiply(A, B);
            }
        }

        private void Multiply(int[,] A, int[,] B)
        {
            int x = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0];
            int y = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1];
            int z = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0];
            int w = A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1];

            A[0, 0] = x;
            A[0, 1] = y;
            A[1, 0] = z;
            A[1, 1] = w;
        }


        // method 5
        // 黄金分割和斐波那契数列的关系 https://demonstrations.wolfram.com/GeneralizedFibonacciSequenceAndTheGoldenRatio/
        // ...没看太懂
        public int Fib_5(int N)
        {
            double goldenRatio = (1 + Math.Sqrt(5)) / 2;
            return (int)Math.Round(Math.Pow(goldenRatio, N) / Math.Sqrt(5));
        }




    }
}