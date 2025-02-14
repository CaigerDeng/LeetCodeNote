
namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 83. 删除排序链表中的重复元素
    /// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/
    /// </summary>


    public class Solution_083
    {
        //Definition for singly-linked list.
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
        // mine
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode currNode = head;
            while (currNode != null && currNode.next != null)
            {
                if (currNode.val == currNode.next.val)
                {
                    ListNode nextNode = currNode.next;
                    currNode.next = nextNode.next;
                    nextNode.next = null;
                }
                else
                {
                    currNode = currNode.next;
                }
            }
            return head;

        }


    }
}