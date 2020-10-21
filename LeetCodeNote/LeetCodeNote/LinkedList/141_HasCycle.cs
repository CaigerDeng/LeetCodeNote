using System.Collections.Generic;

namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 141. 环形链表
    /// https://leetcode-cn.com/problems/linked-list-cycle/
    /// </summary>

    public class Solution_141
    {

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        // method 0
        public bool HasCycle_0(ListNode head)
        {
            HashSet<ListNode> visited = new HashSet<ListNode>();
            while (head != null)
            {
                if (visited.Contains(head))
                {
                    return true;
                }
                visited.Add(head);
                head = head.next;
            }
            return false;

        }

        // method 1
        // 快慢指针
        public bool HasCycle_1(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != fast)
            {
                // 此时已走到结尾
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;

        }




    }
}