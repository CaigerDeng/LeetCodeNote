using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace LeetCodeNote.LinkedList
{

    /// <summary>
    /// 234. 回文链表
    /// https://leetcode-cn.com/problems/palindrome-linked-list/
    /// </summary>

    public class Solution_234
    {

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // method 0
        // 空间复杂度：O(n)，不符题意
        public bool IsPalindrome_0(ListNode head)
        {
            List<int> list = new List<int>();
            ListNode n = head;
            while (n != null)
            {
                list.Add(n.val);
                n = n.next;
            }
            int begin = 0;
            int end = list.Count - 1;
            while (begin != end)
            {
                if (list[begin] != list[end])
                {
                    return false;
                }
                begin++;
                end--;
            }
            return true;

        }

        // method 1
        // 空间复杂度：O(n)，不符题意
        private ListNode beginNode;
        public bool IsPalindrome_1(ListNode head)
        {
            beginNode = head;
            return CheckPalindrome(head);

        }

        private bool CheckPalindrome(ListNode node)
        {
            if (node != null)
            {
                if (!CheckPalindrome(node.next))
                {
                    // 进行中也可能发现不是
                    return false;
                }
                if (node.val != beginNode.val)
                {
                    return false;
                }
                beginNode = beginNode.next;
            }
            return true;

        }

        // method 2
        public bool IsPalindrome_2(ListNode head)
        {
            if (head == null)
            {
                return true;
            }
            ListNode firstHalfEnd = EndOfFirstHalf(head);
            ListNode secondHalfStart = ReverseList(firstHalfEnd.next);
            ListNode p1 = head;
            ListNode p2 = secondHalfStart;
            bool res = true;
            while (p1 != null && p2 != null)
            {
                if (p1.val != p2.val)
                {
                    res = false;
                    break;
                }
                p1 = p1.next;
                p2 = p2.next;
            }
            firstHalfEnd.next = ReverseList(secondHalfStart);
            return res;

        }

        // 翻转链表
        private ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;

        }

        // 求前半段的节点
        private ListNode EndOfFirstHalf(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;

        }




    }
}