// deng：为什么这个需要写代码判断呢？pos不为-1那不就是有环吗？——> 理解错题目了，题目不会给我pos，pos是它自己内部用的。

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
        // 哈希表
        // 时间复杂度O(n)，空间复杂度O(n)
        public bool HasCycle_0(ListNode head)
        {
            HashSet<ListNode> visited = new HashSet<ListNode>();
            // 这里同时考虑了链表为空的情况
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
        // 快慢指针/Floyd 判圈算法/龟兔赛跑算法
        // 简单来说就是如果有环则快慢指针一定会在某时刻重合
        public bool HasCycle_1(ListNode head)
        {
            // 考虑链表为空或者大小为1无环的情况
            if (head == null || head.next == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != fast)
            {
                // 已走到结尾的情况，必然无环
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