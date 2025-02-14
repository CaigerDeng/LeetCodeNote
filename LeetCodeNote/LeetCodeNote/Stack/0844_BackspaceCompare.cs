using System.Text;

namespace LeetCodeNote.Stack
{
    /// <summary>
    /// 844. 比较含退格的字符串
    /// https://leetcode-cn.com/problems/backspace-string-compare/
    /// </summary>


    public class Solution_844
    {

        // method 0
        public bool BackspaceCompare_0(string S, string T)
        {
            return Build(S) == Build(T);

        }

        private string Build(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c != '#')
                {
                    sb.Append(c);
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
            }
            return sb.ToString();

        }

        // method 1
        public bool BackspaceCompare_1(string S, string T)
        {
            int i = S.Length - 1;
            int j = T.Length - 1;
            int skipS = 0;
            int skipT = 0;
            while (i >= 0 || j >= 0)
            {
                // 处理S
                while (i >= 0)
                {
                    if (S[i] == '#')
                    {
                        skipS++;
                        i--;
                    }
                    else if (skipS > 0)
                    {
                        skipS--;
                        i--;
                    }
                    else
                    {
                        // 没有可以删的
                        break;
                    }
                }
                // 处理T
                while (j >= 0)
                {
                    if (T[j] == '#')
                    {
                        skipT++;
                        j--;
                    }
                    else if (skipT > 0)
                    {
                        skipT--;
                        j--;
                    }
                    else
                    {
                        // 没有可以删的
                        break;
                    }
                }
                if (i >= 0 && j >= 0)
                {
                    if (S[i] != T[j])
                    {
                        return false;
                    }
                }
                else
                {
                    // 如果正常走完的话，i和j是负数
                    if (i >= 0 || j >= 0)
                    {
                        return false;
                    }
                }
                // 以下两句是为了上面服务的
                i--;
                j--;
            }
            // 以上都是判断不相等的情况，如果都通过的话，那就是相等了
            return true;

        }



    }

}