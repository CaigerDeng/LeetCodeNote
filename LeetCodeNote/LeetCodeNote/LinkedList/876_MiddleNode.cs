namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 876. 链表的中间结点
    /// https://leetcode-cn.com/problems/middle-of-the-linked-list/
    /// </summary>

    public class Solution_876
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
        // 快慢指针
        // mine
        public ListNode MiddleNode_0(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;

        }

    }
}