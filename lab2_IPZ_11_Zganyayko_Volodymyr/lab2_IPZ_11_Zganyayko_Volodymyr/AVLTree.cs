using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_IPZ_11_Zganyayko_Volodymyr
{
    public class AVL_TreeNode : IComparable
    {
        AVL_Tree Tree;
        AVL_TreeNode Left;
        AVL_TreeNode Right;
        public AVL_TreeNode(int data, AVL_TreeNode parent, AVL_Tree tree)
        {
            Data = data;
            Parent = parent;
            Tree = tree;
        }
        public AVL_TreeNode left
        {
            get { return Left; }
            set { Left = value; if (Left != null) Left.Parent = this; }
        }
        public AVL_TreeNode right
        {
            get { return Right; }
            set { Right = value; if (Right != null) Right.Parent = this; }
        }
        public AVL_TreeNode Parent
        {
            get;
            set;
        }
        public int Data
        {
            get;
            set;
        }
        public int MaxChildHeight(AVL_TreeNode node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.left), MaxChildHeight(node.right));
            }
            return 0;
        }
        public int LeftHeight
        {
            get
            {
                return MaxChildHeight(left);
            }
        }
        public int RightHeight
        {
            get
            {
                return MaxChildHeight(right);
            }
        }
        TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return TreeState.LeftHeavy;
                }
                if (RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }
                return TreeState.Balanced;
            }
        }
        public int CompareTo(object other)
        {
            return Data.CompareTo(other);
        }
        public void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (right != null && right.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (left != null && left.BalanceFactor > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }
        public int BalanceFactor
        {
            get
            {
                return RightHeight - LeftHeight;
            }
        }
        enum TreeState
        {
            Balanced,
            LeftHeavy,
            RightHeavy,
        }
        public void LeftRotation()
        {
            AVL_TreeNode newRoot = right;
            ReplaceRoot(newRoot);
            right = newRoot.left;
            newRoot.left = this;
        }
        public void RightRotation()
        {
            AVL_TreeNode newRoot = left;
            ReplaceRoot(newRoot);
            left = newRoot.right;
            newRoot.right = this;
        }
        public void LeftRightRotation()
        {
            right.RightRotation();
            LeftRotation();
        }
        public void RightLeftRotation()
        {
            left.LeftRotation();
            RightRotation();
        }
        public void ReplaceRoot(AVL_TreeNode newRoot)
        {
            if (this.Parent != null)
            {
                if (this.Parent.left == this)
                {
                    this.Parent.left = newRoot;
                }
                else if (this.Parent.right == this)
                {
                    this.Parent.right = newRoot;
                }
            }
            else
            {
                Tree.Head = newRoot;
            }
            newRoot.Parent = this.Parent;
            this.Parent = newRoot;
        }
    }
    public class AVL_Tree : IEnumerable
    {
        public AVL_TreeNode Head
        {
            get;
            set;
        }
        public int Count
        {
            get;
            set;
        }
        public void Add(int data)
        {
            if (Head == null)
            {
                Head = new AVL_TreeNode(data, null, this);
            }
            else
            {
                AddTo(Head, data);
            }
            Count++;
        }
        public void AddTo(AVL_TreeNode node, int data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.left == null)
                {
                    node.left = new AVL_TreeNode(data, node, this);
                }
                else
                {
                    AddTo(node.left, data);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new AVL_TreeNode(data, node, this);
                }
                else
                {
                    AddTo(node.right, data);
                }
            }
        }
        public IEnumerator InOrderTraversal()
        {
            if (Head != null)
            {
                Stack<AVL_TreeNode> stack = new Stack<AVL_TreeNode>();
                AVL_TreeNode current = Head;
                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.left != null)
                        {
                            stack.Push(current);
                            current = current.left;
                        }
                    }
                    yield return current.Data;
                    if (current.right != null)
                    {
                        current = current.right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return InOrderTraversal();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool Contains(int data)
        {
            return Find(data) != null;
        }
        public AVL_TreeNode Find(int data)
        {
            AVL_TreeNode current = Head;
            while (current != null)
            {
                int result = current.CompareTo(data);
                if (result > 0)
                {
                    current = current.left;
                }
                else if (result < 0)
                {
                    current = current.right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }
        public bool Remove(int data)
        {
            AVL_TreeNode current;
            current = Find(data);
            if (current == null)
            {
                return false;
            }
            AVL_TreeNode treeToBalance = current.Parent;
            Count--;
            if (current.right == null)
            {
                if (current.Parent == null)
                {
                    Head = current.left;
                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        current.Parent.left = current.left;
                    }
                    else if (result < 0)
                    {
                        current.Parent.right = current.left;
                    }
                }
            }
            else if (current.right.left == null)
            {
                current.right.left = current.left;
                if (current.Parent == null)
                {
                    Head = current.right;
                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        current.Parent.left = current.right;
                    }
                    else if (result < 0)
                    {
                        current.Parent.right = current.right;
                    }
                }
            }
            else
            {
                AVL_TreeNode leftmost = current.right.left;
                while (leftmost.left != null)
                {
                    leftmost = leftmost.left;
                }
                leftmost.Parent.left = leftmost.right;
                leftmost.left = current.left;
                leftmost.right = current.right;
                if (current.Parent == null)
                {
                    Head = leftmost;
                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        current.Parent.left = leftmost;
                    }
                    else if (result < 0)
                    {
                        current.Parent.right = leftmost;
                    }
                }
            }
            if (treeToBalance != null)
            {
                treeToBalance.Balance();
            }
            else
            {
                if (Head != null)
                {
                    Head.Balance();
                }
            }
            return true;
        }
        public void Clear()
        {
            Head = null;
            Count = 0;
        }
    }
}
