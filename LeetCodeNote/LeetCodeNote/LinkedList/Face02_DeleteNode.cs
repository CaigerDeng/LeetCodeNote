namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 面试题 02.03. 删除中间节点
    /// https://leetcode-cn.com/problems/delete-middle-node-lcci/
    /// </summary>

    public class Solution_Face02_DeleteNode
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
        // 此题和237_DeleteNode一样
        public void DeleteNode(ListNode node)
        {
            ListNode next = node.next;
            // next肯定不为空，因为node不是末尾节点
            node.val = next.val;
            node.next = next.next;
        }



    }
}