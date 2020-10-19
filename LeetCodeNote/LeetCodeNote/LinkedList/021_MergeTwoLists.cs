namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 21. 合并两个有序链表
    /// https://leetcode-cn.com/problems/merge-two-sorted-lists/
    /// </summary>

    public class Solution_021
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }


        // method 1
        public ListNode MergeTwoLists_1(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);
            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }        
            prev.next = l1 ?? l2;
            // 返回的是真正的第一个节点，而不是返回哨兵节点
            return prehead.next;

        }


    }


    



}