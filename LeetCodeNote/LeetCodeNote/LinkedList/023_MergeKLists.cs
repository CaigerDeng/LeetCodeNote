using System;
using System.Collections.Generic;

namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 23. 合并K个升序链表
    /// https://leetcode.cn/problems/merge-k-sorted-lists/description/
    /// </summary>

    public class Solution_023
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

        // 直接照搬“21. 合并两个有序链表”的method 1
        private ListNode MergeTwoLists(ListNode a, ListNode b)
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

        // method 1
        // 顺序合并
        // 直接在“21. 合并两个有序链表”的方法上套个循环
        // 时间复杂度O(k*k*n)，空间复杂度O(1)
        public ListNode MergeKLists_0(ListNode[] lists)
        {
            ListNode node = null;
            for (int i = 0; i < lists.Length; i++)
            {
                node = MergeTwoLists(node, lists[i]);
            }
            return node;

        }

        // method 1
        // 分治合并
        // 时间复杂度O(kn*logk)，空间复杂度O(logk)
        public ListNode MergeKLists_1(ListNode[] lists)
        {
            return Merge(lists, 0, lists.Length - 1);

        }

        private ListNode Merge(ListNode[] lists, int left, int right)
        {
            if (left == right)
            {
                return lists[left];
            }
            if (left > right)
            {
                return null;
            }
            int mid = left + (right - left) / 2;
            return MergeTwoLists(Merge(lists, left, mid), Merge(lists, mid + 1, right));

        }

        // method 2
        // 使用优先队列合并
        // 优先队列使用知识：https://www.bytehide.com/blog/priority-queque-csharp
        // 时间复杂度O(kn*logk)，空间复杂度O(k)
        public ListNode MergeKLists_2(ListNode[] lists)
        {
            // 优先级算法直接用了Status里边写好的CompareTo
            PriorityQueue<Status, Status> priorityQueue = new PriorityQueue<Status, Status>();
            foreach (var item in lists)
            {
                if (item != null)
                {
                    Status s = new Status(item.val, item);
                    priorityQueue.Enqueue(s, s);
                }
            }
            // 哨兵节点head
            ListNode head = new ListNode(-1);
            ListNode node = head;
            while (priorityQueue.Count > 0)
            {
                // 优先队列排出优先级最低的值，即最小值
                Status status = priorityQueue.Dequeue();
                node.next = status.node;
                node = node.next;
                if (status.node.next != null)
                {
                    Status s = new Status(status.node.next.val, status.node.next);
                    priorityQueue.Enqueue(s, s);
                }

            }
            // 返回第一个业务节点
            return head.next;

        }


        // deng：这个IComparable和IComparer写起来有啥不一样？——> IComparable只允许同类比较，IComparer都能比较
        public class Status : IComparable<Status>
        {
            public int val;
            public ListNode node;

            public Status(int val, ListNode node)
            {
                this.val = val;
                this.node = node;
            }

            public int CompareTo(Status other)
            {
                return val - other.val; // 从大到小排

            }

        }



    }






}