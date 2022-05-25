using System.Collections;

namespace lab2_IPZ_11_Zganyayko_Volodymyr
{
    class BinaryTreeNode : IComparable
    {
        public int Data { get; set; }
        public BinaryTreeNode Right { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode(int Data)
        {
            this.Data = Data;
        }
        public int CompareTo(object other)
        {
            return Data.CompareTo((int)other);
        }
    }
    class BinaryTree : IEnumerable
    {
        private BinaryTreeNode Head;
        int Count;
        public void Add(int data)
        {
            if (Head == null)
            {
                Head = new BinaryTreeNode(data);
            }
            else
            {
                AddTo(Head, data);
                Count++;
            }
        }
        public void AddTo(BinaryTreeNode node, int data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode(data);
                }
                else
                {
                    AddTo(node.Left, data);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode(data);
                }
                else
                {
                    AddTo(node.Right, data);
                }
            }
        }
        public bool Remove(int data)
        {
            BinaryTreeNode current;
            BinaryTreeNode parent;
            current = FindWithParent(data, out parent);
            if (current == null)
            {
                return false;
            }
            Count--;
            if (current.Right == null)
            {
                if (parent == null)
                {
                    Head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    Head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                BinaryTreeNode leftmost = current.Right.Left;
                BinaryTreeNode leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }
                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (parent == null)
                {
                    Head = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        parent.Left = leftmost; 
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;                 
                    }
                }
            }
            return true;
            
        }
        public BinaryTreeNode FindWithParent(int data, out BinaryTreeNode parent)
        {
            parent = null;
            BinaryTreeNode current = Head;
            while (current != null)
            {
                int result = current.CompareTo(data);
                if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (result > 0)
                {
                    parent = current;current = current.Left;
                }
                else
                {
                    break;
                }
            }
            return current;
        }
        public IEnumerator GetEnumerator()
        {
            return PrintFromHighToLow();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator PrintFromHighToLow()
        {
            if (Head != null)
            {
                Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
                BinaryTreeNode current = Head;
                bool flag = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (flag)
                    {
                        while (current.Right != null)
                        {
                            stack.Push(current);
                            current = current.Right;
                        }
                    }
                    yield return current.Data;
                    if (current.Left != null)
                    {
                        current = current.Left;
                        flag = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        flag = false;
                    }
                }
            }
        }
    }
}
