namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 203. 移除链表元素
    /// https://leetcode-cn.com/problems/remove-linked-list-elements/
    /// </summary>


    public class Solution_203
    {

        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // method 0
        // mine
        public ListNode RemoveElements(ListNode head, int val)
        {
            // 哨兵节点 
            ListNode sentinel = new ListNode(0); 
            sentinel.next = head;
            ListNode pre = sentinel;
            ListNode curr = head;

            while (curr != null)
            {
                if (curr.val == val)
                {
                    pre.next = curr.next;
                }
                else
                {
                    pre = curr;
                }
                curr = curr.next;
            }
            return sentinel.next;

        }



    }
}