namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 剑指 Offer 18. 删除链表的节点
    /// https://leetcode-cn.com/problems/shan-chu-lian-biao-de-jie-dian-lcof/
    /// </summary>

    public class Solution_Offer22
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
        // 双指针
        public ListNode GetKthFromEnd_0(ListNode head, int k)
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
            return slow;

        }

    }




}