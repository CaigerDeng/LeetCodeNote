namespace LeetCodeNote.LinkedList
{
    public class Solution_Face02_KthToLast
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
        // 参考Offer22_GetKthFromEnd
        public int KthToLast_0(ListNode head, int k)
        {
            ListNode slow = head;
            ListNode fast = head;
            int i = 0;
            while (fast != null)
            {
                if (i >= k)
                {
                    slow = slow.next;
                }
                fast = fast.next;
                i++;
            }
            return slow.val;

        }



    }
}