namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 剑指 Offer 18. 删除链表的节点
    /// https://leetcode-cn.com/problems/shan-chu-lian-biao-de-jie-dian-lcof/
    /// </summary>

    public class Solution_Offer18
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
        // 就是普通的删除代码
        public ListNode DeleteNode_0(ListNode head, int val)
        {
            ListNode guard = new ListNode(0);
            guard.next = head;
            ListNode pre = guard;
            ListNode curr = head;
            while (curr != null)
            {
                if (curr.val == val)
                {
                    pre.next = curr.next;
                    curr.next = null;
                    break;
                }
                pre = curr;
                curr = curr.next;
            }
            return guard.next;

        }


    }




}