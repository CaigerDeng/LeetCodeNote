namespace LeetCodeNote.LinkedList
{
    public class Solution_Face02_GetIntersectionNode
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // method 0
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
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