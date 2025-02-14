using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.LinkedList
{
    /// <summary>
    /// 116. 填充每个节点的下一个右侧节点指针
    /// https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node/
    /// </summary>

    public class Solution_116
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }



        // method 0
        // 层次遍历
        public Node Connect_0(Node root)
        {
            if (root == null)
            {
                return root;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    Node node = queue.Dequeue();
                    if (i < count - 1)
                    {
                        node.next = queue.Peek();
                    }
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }
            return root;

        }

        // method 1
        // 从最左结点开始连完同层所有，再进入下一层
        public Node Connect_1(Node root)
        {
            if (root == null)
            {
                return root;
            }
            Node mostLeft = root;
            while (mostLeft.left != null)
            {
                Node head = mostLeft;
                while (head != null)
                {
                    head.left.next = head.right;
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }
                    // 连完同层所有
                    head = head.next;
                }
                // 进入下一层
                mostLeft = mostLeft.left;
            }
            return root;

        }

    }

  



}