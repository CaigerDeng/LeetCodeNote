using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 面试题 02.06. 回文链表
    /// https://leetcode-cn.com/problems/palindrome-linked-list-lcci/
    /// </summary>


    class Face02_IsPalindrome
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // method 0
        // 同Solution_234 method 2
        public bool IsPalindrome_0(ListNode head)
        {
            if(head == null)
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
