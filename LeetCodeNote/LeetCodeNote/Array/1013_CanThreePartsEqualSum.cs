using System.Linq;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1013. 将数组分成和相等的三个部分
    /// https://leetcode-cn.com/problems/partition-array-into-three-parts-with-equal-sum/
    /// </summary>

    public class Solution_1013
    {
        // method 0
        public bool CanThreePartsEqualSum_0(int[] A)
        {
            int sum = A.Sum();
            if (sum % 3 != 0)
            {
                return false;
            }
            int target = sum / 3;
            int i = 0;
            int cur = 0;
            while (i < A.Length)
            {
                cur += A[i];
                if (cur == target)
                {
                    break;
                }
                i++;
            }
            if (cur != target)
            {
                // 此时是不满足条件的数组，cur可能已经远大于target
                return false;
            }
            int j = i + 1;
            // 要保证最后一个数组非空，可能这里的j已经走到尽头
            while (j + 1 < A.Length)
            {
                cur += A[j];
                if (cur == target * 2)
                {
                    return true;
                }
                j++;
            }
            return false;
        }

    }


}