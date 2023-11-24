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
        // 迭代
        // 这里特别在于它的空间复杂度O(1)，因为是直接在原链表上改的
        // 时间复杂度O(n)，空间复杂度O(1)
        public ListNode MergeTwoLists_1(ListNode a, ListNode b)
        {
            if (a == null || b == null)
            {
                return a ?? b;
            }
            // 哨兵节点head，不参与业务逻辑
            ListNode head = new ListNode(-1);
            ListNode node = head;
            while (a != null && b != null)
            {
                if (a.val <= b.val)
                {
                    node.next = a;
                    // a请进
                    a = a.next;
                }
                else
                {
                    node.next = b;
                    // b请进
                    b = b.next;
                }
                // node自己前进
                node = node.next;
            }
            // 考虑a或b还没走完的情况
            node.next = a ?? b;
            // 返回第一个业务逻辑节点
            return head.next;

        }


    }


    



}