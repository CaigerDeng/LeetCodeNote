namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 剑指 Offer 52. 两个链表的第一个公共节点
    /// https://leetcode-cn.com/problems/liang-ge-lian-biao-de-di-yi-ge-gong-gong-jie-dian-lcof/
    /// </summary>

    public class Offer52_GetIntersectionNode
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // method 0
        // 双指针
        public ListNode GetIntersectionNode_0(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }
            ListNode a = headA;
            ListNode aEnd = null;
            ListNode b = headB;
            ListNode bEnd = null;
            while (a != b)
            {
                if (a.next == null)
                {
                    aEnd = a;
                    a = headB;
                }
                else
                {
                    a = a.next;
                }
                if (b.next == null)
                {
                    bEnd = b;
                    b = headA;
                }
                else
                {
                    b = b.next;
                }
                if (aEnd != null && bEnd != null && aEnd != bEnd)
                {
                    return null;
                }
            }
            return a;

        }



    }

}


