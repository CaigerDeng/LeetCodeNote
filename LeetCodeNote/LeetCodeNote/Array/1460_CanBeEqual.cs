namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1460. 通过翻转子数组使两个数组相等
    /// https://leetcode-cn.com/problems/make-two-arrays-equal-by-reversing-sub-arrays/
    /// </summary>

    public class Solution_1460
    {
        // method 0
        public bool CanBeEqual_0(int[] target, int[] arr)
        {
            int[] a = new int[target.Length];
            System.Array.Copy(target, a, target.Length);
            int[] b = new int[arr.Length];
            System.Array.Copy(arr, b, arr.Length);
            System.Array.Sort(a);
            System.Array.Sort(b);
            // C#没有对数组的==和Equals重写，所以不能直接比较
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }               
            }
            return true;

        }



    }


}