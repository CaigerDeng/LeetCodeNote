using System.Linq;

namespace LeetCodeNote.HashTable
{

    /// <summary>
    /// 面试题 01.04. 回文排列
    /// https://leetcode-cn.com/problems/palindrome-permutation-lcci/
    /// </summary>


    public class Solution_Face01_CanPermutePalindrome
    {
        // method 0
        // 没用哈希表，直接linq
        // https://leetcode-cn.com/problems/palindrome-permutation-lcci/solution/hui-wen-pai-xu-jie-ti-si-lu-hui-wen-jiu-shi-zui-du/
        public bool CanPermutePalindrome_0(string s)
        {          
            return s.ToList().GroupBy(i => i).Count(x => x.Count() % 2 == 1) < 2;

        }

    }
}