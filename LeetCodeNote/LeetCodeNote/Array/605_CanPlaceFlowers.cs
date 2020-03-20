namespace LeetCodeNote.Array
{
    /// <summary>
    /// 605. 种花问题
    /// https://leetcode-cn.com/problems/can-place-flowers/
    /// </summary>

    public class Solution_605
    {
        // method 0 
        // 贪心算法出现
        public bool CanPlaceFlowers_0(int[] flowerbed, int n)
        {
            int i = 0;
            int count = 0;
            if (flowerbed.Length == 1 && flowerbed[0] == 0)
            {
                return 1 >= n;
            }
            while (i < flowerbed.Length)
            {
                if (flowerbed[i] == 0)
                {
                    bool canPlace = false;
                    if (!canPlace && i == 0 && flowerbed[i + 1] == 0)
                    {
                        canPlace = true;
                    }
                    if (!canPlace && i == flowerbed.Length - 1 && flowerbed[i - 1] == 0)
                    {
                        canPlace = true;
                    }
                    if (!canPlace && i - 1 >= 0 && flowerbed[i - 1] == 0 && i + 1 < flowerbed.Length && flowerbed[i + 1] == 0)
                    {
                        canPlace = true;
                    }
                    if (canPlace)
                    {
                        count++;
                        flowerbed[i] = 1;
                        continue;
                    }
                }
                i++;
            }
            return count >= n;

        }

        // method 1
        // 优化method 0对count >= n的检测
        public bool CanPlaceFlowers_1(int[] flowerbed, int n)
        {
            int i = 0;
            int count = 0;
            if (n == 0)
            {
                return true;
            }
            if (flowerbed.Length == 1 && flowerbed[0] == 0)
            {
                return 1 >= n;
            }
            while (i < flowerbed.Length)
            {
                if (flowerbed[i] == 0)
                {
                    bool canPlace = false;
                    if (!canPlace && i == 0 && flowerbed[i + 1] == 0)
                    {
                        canPlace = true;
                    }
                    if (!canPlace && i == flowerbed.Length - 1 && flowerbed[i - 1] == 0)
                    {
                        canPlace = true;
                    }
                    if (!canPlace && i - 1 >= 0 && flowerbed[i - 1] == 0 && i + 1 < flowerbed.Length && flowerbed[i + 1] == 0)
                    {
                        canPlace = true;
                    }
                    if (canPlace)
                    {
                        count++;
                        flowerbed[i] = 1;
                        if (count >= n)
                        {
                            return true;
                        }
                        continue;
                    }
                }
                i++;
            }
            return false;



        }




    }










}