using System.Collections.Generic;

namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 剑指 Offer 06. 从尾到头打印链表
    /// https://leetcode-cn.com/problems/cong-wei-dao-tou-da-yin-lian-biao-lcof/
    /// </summary>

    public class Solution_Offer06_ReversePrint
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // method 0
        public int[] ReversePrint_0(ListNode head)
        {
            Stack<int> stack = new Stack<int>();
            ListNode curr = head;
            while (curr != null)
            {
                stack.Push(curr.val);
                curr = curr.next;
            }
            int[] arr = new int[stack.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = stack.Pop();
            }
            return arr;

        }

    }

}