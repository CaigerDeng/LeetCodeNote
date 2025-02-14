using System.Collections.Generic;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 682. 棒球比赛
    /// https://leetcode-cn.com/problems/baseball-game/
    /// </summary>

    public class Solution_682
    {

        // method 0
        public int CalPoints_0(string[] ops)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < ops.Length; i++)
            {
                string val = ops[i];
                int score;
                if (int.TryParse(val, out score))
                {
                    stack.Push(score);
                }
                else
                {
                    switch (val)
                    {
                        case "+":
                            int v1 = stack.Pop();
                            int v2 = stack.Pop();
                            score = v1 + v2;
                            stack.Push(v2);
                            stack.Push(v1);
                            stack.Push(score);
                            break;
                        case "D":
                            int vv1 = stack.Pop();
                            score = vv1 * 2;
                            stack.Push(vv1);
                            stack.Push(score);
                            break;
                        case "C":
                            stack.Pop();
                            break;
                    }
                }
            }
            int res = 0;
            while (stack.Count > 0)
            {
                res += stack.Pop();
            }
            return res;

        }




    }


}