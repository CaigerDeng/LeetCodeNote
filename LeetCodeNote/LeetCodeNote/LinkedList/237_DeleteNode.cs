namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 237. 删除链表中的节点
    /// https://leetcode-cn.com/problems/delete-node-in-a-linked-list/
    /// </summary>


    public class Solution_237
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
        public void DeleteNode_0(ListNode node)
        {
            // 没有head！
            node.val = node.next.val;
            node.next = node.next.next;
        }



    }
}