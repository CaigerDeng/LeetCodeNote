namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1. 两数之和
    /// https://leetcode-cn.com/problems/two-sum/
    /// </summary>

    public class Solution_1089
    {
        // method 0
        public void DuplicateZeros_0(int[] arr)
        {
            int possibleDups = 0;
            int len = arr.Length - 1;
            for (int left = 0; left <= len - possibleDups; left++)
            {
                if (arr[left] == 0)
                {
                    if (left == len - possibleDups)
                    {
                        arr[len] = 0;
                        len--;
                        break;
                    }
                    possibleDups++;
                }
            }
            int last = len - possibleDups;
            for (int i = last; i >= 0; i--)
            {
                if (arr[i] == 0)
                {
                    arr[i + possibleDups] = 0;
                    possibleDups--;
                    // 因为前面还有0，需要准备它的复写0的位置，这里就往后挪一个位置
                    arr[i + possibleDups] = 0;
                }
                else
                {
                    arr[i + possibleDups] = arr[i];
                }
            }




        }
    }
}