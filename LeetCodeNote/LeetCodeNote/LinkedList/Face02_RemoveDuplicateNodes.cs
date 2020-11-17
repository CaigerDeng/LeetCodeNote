using System.Collections.Generic;

namespace LeetCodeNote.LinkedList
{
    public class Solution_Face02_01
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        // 之前Solution_268_missingNumber的解法，我想过用异或的位运算来消掉重复数字，但不行
        // 因为这种是针对重复数字两对两对出现多次的情况，但如果我用1，2，3，3为例就不通。

        // method 0
        public ListNode RemoveDuplicateNodes_0(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            HashSet<int> hash = new HashSet<int>();
            hash.Add(head.val);
            ListNode prev = head;
            while (prev.next != null)
            {
                ListNode curr = prev.next;
                if (hash.Add(curr.val))
                {
                    prev = prev.next;
                }
                else
                {
                    prev.next = curr.next;
                }
            }
            return head;

        }

        // method 1
        // 这里用的是空间复杂度下降，但时间复杂度提升的设计
        public ListNode RemoveDuplicateNodes_1(ListNode head)
        {
            ListNode a = head;
            while (a != null)
            {
                ListNode b = a;
                // 这里和method 0差不多
                while (b.next != null)
                {
                    if (b.next.val == a.val)
                    {
                        b.next = b.next.next;
                    }
                    else
                    {
                        b = b.next;
                    }
                }
                a = a.next;
            }
            return head;

        }





    }
}