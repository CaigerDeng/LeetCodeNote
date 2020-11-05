namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 1290. 二进制链表转整数
    /// https://leetcode-cn.com/problems/convert-binary-number-in-a-linked-list-to-integer/
    /// </summary>

    public class Solution_1290
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

        // method 0
        public int GetDecimalValue_0(ListNode head)
        {
            ListNode curr = head;
            int res = 0;
            while (curr != null)
            {
                res = res * 2 + curr.val;
                curr = curr.next;
            }
            return res;

        }


    }



}