using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    public class TestMisc
    {
        public void Run()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };




    


        }

        private void QuickSort(int[] nums)
        {
            QuickSortDetail(nums, 0, nums.Length - 1);

        }

        private void QuickSortDetail(int[] nums, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pivotIndex = Part(nums, left, right);
            QuickSortDetail(nums, 0, pivotIndex - 1);
            QuickSortDetail(nums, pivotIndex + 1, right);
            
        }

        private int Part(int[] nums, int left, int right)
        {


        }


    }




}
