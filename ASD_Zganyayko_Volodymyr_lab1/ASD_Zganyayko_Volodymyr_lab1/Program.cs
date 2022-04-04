using System;
using System.Text;
using System.Diagnostics;

namespace ASD_Zganyayko_Volodymyr_lab1
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
        public void Print()
        {
            Console.Write(data + " ");
            if (next != null)
            {
                next.Print();
            }
        }
        public void AddToEnd(int data)
        {
            if (next == null)
            { 
                next = new Node(data);
            }
            else
            {
                next.AddToEnd(data);
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine("Лаб 1, ІПЗ-11(1), Зганяйко Володимир Віталійович");
            Menu();
        }
        static void Menu()
        {
            int menu;
            do
            {
                Console.WriteLine("МЕНЮ!!!");
                Console.WriteLine("1. Масив.");
                Console.WriteLine("2. Лінійний зв'язний список.");
                Console.WriteLine("0. Вихід із програми.");
                Console.Write("Оберіть структуру даних: ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1: Arrays(); break;
                    case 2: Nodes(); break;
                    case 0: Console.WriteLine("Кінець програми..."); break;
                    default: Console.WriteLine("Невірна команда. Спробуйте ще раз!"); break; 
                }
            } while (menu != 0);
        }
        static void Arrays()
        {            
            int menu;
            Console.WriteLine("Ви обрали структуру даних масив.");
            int length;
            Console.Write("Введіть довжину масиву: ");
            length = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[length];           
            array = ArrayGenerationAndOutput(array);                       
            do
            {
                Console.WriteLine("МАСИВИ!!!");
                Console.WriteLine("1. Лінійний пошук.");
                Console.WriteLine("2. Пошук з бар'єром.");
                Console.WriteLine("3. Бінарний пошук.");
                Console.WriteLine("4. Бінарний пошук з золотим перерізом.");
                Console.WriteLine("5. Вихід.");
                Console.Write("Оберіть пункт меню: ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1: LinarySearchForArray(array); break;
                    case 2: SearchWithBarrierForArray(array); break;
                    case 3: BinarySearchForArray(array, 0, array.Length); break;
                    case 4: BinarySearchWithGoldRatioForArray(array, 0, array.Length); break;
                    case 5: Console.WriteLine("Вихід..."); break;
                    default: Console.WriteLine("Невірна команда. Спробуйте знову!"); break;
                }
            } while (menu != 5);
        }        
        static int[] ArrayGenerationAndOutput(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, array.Length);
            }
            Console.WriteLine("Ваш масив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            return array;
        }
        static void LinarySearchForArray(int[] array)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            int key, index = 0;
            bool flag = false;
            Console.Write("Ви обрали лінійний пошук. Введіть елемент, який Ви хочете знайти в масиві: ");
            key = Convert.ToInt32(Console.ReadLine());
            Duration.Start();
            for (int i = 0; i < array.Length && !flag; i++)
            {
                iters++;
                if (array[i] == key)
                {
                    index = i;
                    flag = true;
                    Duration.Stop();
                }
            }
            Duration.Stop();
            if (flag)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {index}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
            else 
            {
                Console.WriteLine("Елемент відсутній у масиві.");
            }
        }
        static void SearchWithBarrierForArray(int[] array)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            int key, index = 0;
            int[] array1 = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                array1[i] = array[i];
            }
            Console.Write("Ви обрали пошук з бар'єром. Введіть елемент, який Ви хочете знайти в масиві: ");
            key = Convert.ToInt32(Console.ReadLine());
            array1[array.Length] = key;
            Duration.Start();
            while (array1[index] != key)
            {
                iters++;
                index++;
            }
            Duration.Stop();
            if (index == array.Length)
            {
                Console.WriteLine("Елемент відсутній у масиві.");
            }
            else 
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {index}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
        }
        static void BinarySearchForArray(int[] array, int left, int right)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            int key, middle = 0;
            bool flag = false;
            Console.Write("Ви обрали бінарний пошук.");
            Array.Sort(array);
            Console.WriteLine("Відсортований масив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Введіть елемент, яке Ви хочете знайти в масиві: ");
            key = Convert.ToInt32(Console.ReadLine());
            Duration.Start();
            while (left <= right && !flag)
            {
                iters++;
                middle = (left + right) / 2;
                if (key == array[middle])
                {
                    flag = true;
                    Duration.Stop();
                }
                else if (key < array[middle])
                {
                    right = middle - 1;
                }
                else 
                {
                    left = middle + 1;
                }
            }
            Duration.Stop();
            if (flag)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {middle}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
            else 
            {
                Console.WriteLine("Елемент відсутній у масиві.");
            }
        }
        static void BinarySearchWithGoldRatioForArray(int[] array, int left, int right)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            int key, middle = 0;
            double goldratio = (Math.Sqrt(5) + 1) / 2;
            bool flag = false;
            Console.Write("Ви обрали бінарний пошук з золотим перерізом."); 
            Array.Sort(array);
            Console.WriteLine("Відсортований масив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Введіть елемент, який Ви хочете знайти в масиві: ");
            key = Convert.ToInt32(Console.ReadLine());
            Duration.Start();
            while (left <= right && !flag)
            {
                iters++;
                middle = (int)(right - (right - left) / goldratio);
                if (key == array[middle])
                {
                    flag = true;
                    Duration.Stop();
                }
                else if (key < array[middle])
                {
                    right = middle - 1;
                }                                
                else 
                {
                    left = middle + 1;
                }

            }
            Duration.Stop();
            if (flag)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {middle}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
            else
            {
                Console.WriteLine("Елемент відсутній у масиві."); 
            }
        }
        static void Nodes()
        {
            int menu, length;
            Console.WriteLine("Ви обрали структуру даних лінійний зв'язний список.");
            Console.Write("Введіть довжину списку: ");
            length = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            Node MyNode = new Node(random.Next(0, length));
            NodeGenerationAndOutput(MyNode, length);
            do
            {
                Console.WriteLine("СПИСКИ!!!");
                Console.WriteLine("1. Лінійний пошук.");
                Console.WriteLine("2. Лінійний пошук з бар'єром.");
                Console.WriteLine("3. Бінарний пошук.");
                Console.WriteLine("4. Бінарний пошук з золотим перерізом.");
                Console.WriteLine("5. Вихід.");
                Console.Write("Введіть пункт меню: ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch(menu)
                {
                    case 1: LinarySearchForList(MyNode); break;
                    case 2: SearchWithBarrierForList(MyNode, length); break;
                    case 3: BinarySearchForList(MyNode, 0, length); break;
                    case 4: BinarySearchWithGoldRatioForList(MyNode, 0, length); break;
                    case 5: Console.WriteLine("Вихід..."); break;
                    default: Console.WriteLine("Невірна команда. Спробуйте знову!"); break;
                }
            } while (menu != 5);
        }
        static void NodeGenerationAndOutput(Node head, int length)
        {
            Random random = new Random();
            for (int i = 1; i < length; i++)
            {
                head.AddToEnd(random.Next(0, length));
            }
            Console.WriteLine("Ваш список: ");
            head.Print();
            Console.WriteLine("");
        }
        static int CurrentElement(Node element, int index)
        {
            for (int i = 0; i < index; i++)
            {
                element = element.next;
            }
            return element.data;
        }
        static void SortNode(Node head)
        {
            Node element;
            while (head != null)
            {
                element = head.next;
                while (element != null)
                {
                    if (head.data > element.data)
                    {
                        int temp = head.data;
                        head.data = element.data;
                        element.data = temp;
                    }
                    element = element.next;
                }
                head = head.next;
            }
        }
        static void LinarySearchForList(Node head)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            Console.WriteLine("Ви обрали лінійний пошук.");
            int key, index = 0;
            bool flag = false;
            Console.WriteLine("Введіть елемент, який Ви хочете знайти в списку: ");
            key = Convert.ToInt32(Console.ReadLine());
            Duration.Start();
            for (int i = 0; head != null && !flag; i++)
            {
                iters++;
                if (head.data == key)
                {
                    flag = true;
                    index = i;
                    Duration.Stop();
                }
                head = head.next;
            }
            Duration.Stop();
            if (flag)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {index}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
            else
            {
                Console.WriteLine("Елемент відсутній у списку.");
            }
        }
        static void SearchWithBarrierForList(Node head, int length)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            Console.WriteLine("Ви обрали лінійний пошук з бар'єром.");
            int key, index = 0;
            Console.Write("Введіть елемент, який Ви хочете знайти в списку: ");
            key = Convert.ToInt32(Console.ReadLine());
            head.AddToEnd(key);
            Duration.Start();
            while(head.data != key)
            {
                iters++;
                head = head.next;
                index++;
            }
            Duration.Stop();
            if (index != length)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {index}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
            else
            {
                Console.WriteLine("Елемент відсутній у списку.");
            }
        }
        static void BinarySearchForList(Node head, int left, int right)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            int key, middle = 0;
            bool flag = false;
            Console.WriteLine("Ви обрали бінарний пошук.");
            Console.WriteLine("Ваш список після сортування: ");
            SortNode(head);
            head.Print();
            Console.WriteLine();
            Console.Write("Введіть елемент, який ви хочете знайти в списку: ");
            key = Convert.ToInt32(Console.ReadLine());
            Duration.Start();
            while (left <= right && !flag)
            {
                iters++;
                middle = (int)((right + left) / 2);
                if (key == CurrentElement(head, middle))
                {
                    flag = true;
                    Duration.Stop();
                }
                else if (key < CurrentElement(head, middle))
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }

            }
            Duration.Stop();
            if (flag)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {middle}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
            else 
            {
                Console.WriteLine("Елементу відсутній в списку.");
            }
        }
        static void BinarySearchWithGoldRatioForList(Node head, int left, int right)
        {
            int iters = 0;
            Stopwatch Duration = new Stopwatch();
            int key, middle = 0;
            double goldratio = (Math.Sqrt(5) + 1) / 2;
            bool flag = false;
            Console.WriteLine("Ви обрали бінарний пошук.");
            Console.WriteLine("Ваш список після сортування: ");
            SortNode(head);
            head.Print();
            Console.WriteLine();
            Console.Write("Введіть елемент, який ви хочете знайти в списку: ");
            key = Convert.ToInt32(Console.ReadLine());
            Duration.Start();
            while (left <= right && !flag)
            {
                iters++;
                middle = (int)(right - ((right - left) / goldratio));
                if (key == CurrentElement(head, middle))
                {
                    flag = true;
                    Duration.Stop();
                }
                else if (key < CurrentElement(head, middle))
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }

            }
            Duration.Stop();
            if (flag)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс: {middle}");
                Console.WriteLine($"Кількість ітерацій циклу: {iters}");
                Console.WriteLine($"Тривалість роботи алгоритму: {Duration.ElapsedMilliseconds} ms.");
            }
            else
            {
                Console.WriteLine("Елементу відсутній в списку.");
            }
        }
    }
}
