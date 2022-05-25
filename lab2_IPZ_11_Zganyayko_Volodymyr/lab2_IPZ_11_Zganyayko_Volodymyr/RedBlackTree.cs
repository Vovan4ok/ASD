namespace lab2_IPZ_11_Zganyayko_Volodymyr
{
    public enum Colour
    {
        Red,
        Black
    }
    public class RedBlackTree
    {
        public class Node
        {
            public Colour Colour;
            public Node? Left;
            public Node? Right;
            public Node? Parent;
            public int Data;
            public Node(int Data)
            {
                this.Data = Data;
            }
            public Node(Colour Colour)
            {
                this.Colour = Colour;
            }
            public Node(int Data, Colour Colour)
            {
                this.Data = Data;
                this.Colour = Colour;
            }
        }
        Node? Root;
        public void Insert(int data)
        {
            Node newItem = new Node(data);
            if (Root == null)
            {
                Root = newItem;
                Root.Colour = Colour.Black;
                return;
            }
            Node? node = null;
            Node? Current = Root;
            while (Current != null)
            {
                node = Current;
                if (newItem.Data < Current.Data)
                {
                    Current = Current.Left;
                }
                else
                {
                    Current = Current.Right;
                }
            }
            newItem.Parent = node;
            if (node == null)
            {
                Root = newItem;
            }
            else if (newItem.Data < node.Data)
            {
                node.Left = newItem;
            }
            else
            {
                node.Right = newItem;
            }
            newItem.Left = null;
            newItem.Right = null;
            newItem.Colour = Colour.Red;
            InsertFixUp(newItem);
        }
        public void InsertFixUp(Node? item)
        {
            while (item != Root && item.Parent.Colour == Colour.Red)
            {
                if (item.Parent == item.Parent.Parent.Left)
                {
                    Node? node = item.Parent.Parent.Right;
                    if (node != null && node.Colour == Colour.Red)
                    {
                        item.Parent.Colour = Colour.Black;
                        node.Colour = Colour.Black;
                        item.Parent.Parent.Colour = Colour.Red;
                        item = item.Parent.Parent;
                    }
                    else
                    {
                        if (item == item.Parent.Right)
                        {
                            item = item.Parent;
                            LeftRotate(item);
                        }
                        item.Parent.Colour = Colour.Black;
                        item.Parent.Parent.Colour = Colour.Red;
                        RightRotate(item.Parent.Parent);
                    }
                }
                else
                {
                    Node? node = null;
                    node = item.Parent.Parent.Left;
                    if (node != null && node.Colour == Colour.Black)
                    {
                        item.Parent.Colour = Colour.Red;
                        node.Colour = Colour.Red;
                        item.Parent.Parent.Colour = Colour.Black;
                        item = item.Parent.Parent;
                    }
                    else
                    {
                        if (item == item.Parent.Left)
                        {
                            item = item.Parent;
                            RightRotate(item);
                        }
                        item.Parent.Colour = Colour.Black;
                        item.Parent.Parent.Colour = Colour.Red;
                        LeftRotate(item.Parent.Parent);
                    }
                }
                Root.Colour = Colour.Black;
            }
        }
        public void LeftRotate(Node? Current)
        {
            Node? node = Current.Right;
            Current.Right = node.Left;
            if (node.Left != null)
            {
                node.Left.Parent = Current;
            }
            if (node != null)
            {
                node.Parent = Current.Parent;
            }
            if (Current.Parent == null)
            {
                Root = node;
            }
            if (Current == Current.Parent.Left)
            {
                Current.Parent.Left = node;
            }
            else
            {
                Current.Parent.Right = node;
            }
            node.Left = Current;
            if (Current != null)
            {
                Current.Parent = node;
            }
        }
        public void RightRotate(Node? Current)
        {
            Node? node = Current.Left;
            Current.Left = node.Right;
            if (node.Right != null)
            {
                node.Right.Parent = Current;
            }
            if (node != null)
            {
                node.Parent = Current.Parent;
            }
            if (Current.Parent == null)
            {
                Root = node;
            }
            if (Current == Current.Parent.Right)
            {
                Current.Parent.Right = node;
            }
            if (Current == Current.Parent.Left)
            {
                Current.Parent.Left = node;
            }
            node.Right = Current;
            if (Current != null)
            {
                Current.Parent = node;
            }
        }
        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Елементів в дереві немає!");
            }
            else
            {
                RecursiveDisplay(Root);
            }
        }
        public void RecursiveDisplay(Node? current)
        {
            if (current != null)
            {
                RecursiveDisplay(current.Left);
                if (current.Colour == Colour.Red) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(current.Data + " ");
                RecursiveDisplay(current.Right);
            }
        }
        public Node? FindElement(int key)
        {
            bool flag = false;
            Node? temp = Root;
            Node? item = null;
            while (!flag && temp != null)
            {
                if (key > temp.Data)
                {
                    temp = temp.Right;
                }
                else if (key < temp.Data)
                {
                    temp = temp.Left;
                }
                else
                {
                    flag = true;
                    item = temp;
                }
            }
            if (flag)
            {
                Console.WriteLine("Елемент знайдено.");
                return item;
            }
            else
            {
                Console.WriteLine("Елемент відсутній.");
                return null;
            }

        }
        public void Delete(int key)
        {
            Node item = FindElement(key);
            Node node1 = null;
            Node node2 = null;
            if (item == null)
            {
                Console.WriteLine("Такого елементу немає в дереві.");
                return;
            }
            if (item.Left == null || item.Right == null)
            {
                node2 = item;
            }
            else
            {
                node2 = TrueSuccessor(item);
            }
            if (node2.Left != null)
            {
                node1 = node2.Left;
            }
            else
            {
                node1 = node2.Right;
            }
            if (node1 != null)
            {
                node1.Parent = node2;
            }
            if (node2.Parent == null)
            {
                Root = node1;
            }
            else if (node2 == node2.Parent.Left)
            {
                node2.Parent.Left = node1;
            }
            else
            {
                node2.Parent.Left = node1;
            }
            if (node2 != item)
            {
                item.Data = node2.Data;
            }
            if (node2.Colour == Colour.Black)
            {
                DeleteFixUp(node1);
            }
        }
        public void DeleteFixUp(Node? item)
        {
            while (item != null && item != Root && item.Colour == Colour.Black)
            {
                if (item == item.Parent.Left)
                {
                    Node? node = item.Parent.Right;
                    if (node.Colour == Colour.Red)
                    {
                        node.Colour = Colour.Black;
                        item.Parent.Colour = Colour.Red;
                        LeftRotate(item.Parent);
                        node = item.Parent.Right;
                    }
                    if (node.Left.Colour == Colour.Black && node.Right.Colour == Colour.Black)
                    {
                        node.Colour = Colour.Red;
                        item = item.Parent;
                    }
                    else if (node.Right.Colour == Colour.Black)
                    {
                        node.Left.Colour = Colour.Black;
                        node.Colour = Colour.Red;
                        RightRotate(node);
                        node = item.Parent.Right;
                    }
                    node.Colour = item.Parent.Colour;
                    item.Parent.Colour = Colour.Black;
                    node.Right.Colour = Colour.Black;
                    LeftRotate(item.Parent);
                    item = Root;
                }
                else
                {
                    Node? node = item.Parent.Left;
                    if (node.Colour == Colour.Red)
                    {
                        node.Colour = Colour.Black;
                        item.Parent.Colour = Colour.Red;
                        RightRotate(item.Parent);
                        node = item.Parent.Left;
                    }
                    if (node.Right.Colour == Colour.Black && node.Left.Colour == Colour.Black)
                    {
                        node.Colour = Colour.Black;
                        item = item.Parent;
                    }
                    else if (node.Left.Colour == Colour.Black)
                    {
                        node.Right.Colour = Colour.Black;
                        node.Colour = Colour.Red;
                        LeftRotate(node);
                        node = item.Parent.Left;
                    }
                    node.Colour = item.Parent.Colour;
                    item.Parent.Colour = Colour.Black;
                    node.Left.Colour = Colour.Black;
                    RightRotate(item.Parent);
                    item = Root;
                }
            }
            if (item != null)
            {
                item.Colour = Colour.Black;
            }
        }
        public Node? TrueSuccessor(Node? item)
        {
            if (item.Left != null)
            {
                return Minimum(item);
            }
            else
            {
                Node? node = item.Parent;
                while (node != null && item == node.Right)
                {
                    item = node;
                    node = node.Parent;
                }
                return node;
            }
        }
        public Node? Minimum(Node? item)
        {
            while (item.Left.Left != null)
            {
                item = item.Left;
            }
            if (item.Left.Right != null)
            {
                item = item.Left.Right;
            }
            return item;
        }
    }
}