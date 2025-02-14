namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 206. 反转链表
    /// https://leetcode-cn.com/problems/reverse-linked-list/
    /// </summary>

    public class Solution_206
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // method 0
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

        // method 1
        public ListNode ReverseList_1(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode p = ReverseList_1(head.next);
            head.next.next = head;
            head.next = null;
            return p;

        }


    }
}