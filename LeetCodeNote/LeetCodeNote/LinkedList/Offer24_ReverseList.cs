using System.Dynamic;

namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 剑指 Offer 24. 反转链表
    /// https://leetcode-cn.com/problems/fan-zhuan-lian-biao-lcof/
    /// </summary>


    public class Solution_Offer24_ReverseList
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }

        public ListNode ReverseList_0(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;

        }



    }



}