using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab2_IPZ_11_Zganyayko_Volodymyr
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Лаб 3, ІПЗ-11, Зганяйко Володимир");
            Menu();
        }
        static void Menu()
        {
            char menu;
            do
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Меню!!!");
                Console.WriteLine("1. Робота з бінарними деревами.");
                Console.WriteLine("2. Робота з АВЛ деревами.");
                Console.WriteLine("3. Робота з червоно-чорними деревами.");
                Console.WriteLine("0. Вихід із програми.");
                Console.Write("Введіть пункт меню: ");
                menu = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                switch(menu)
                {
                    case '1': MenuForBinaryTree(); break;
                    case '2': MenuForAVLTree(); break;
                    case '3': MenuForRedBlackTree(); break;
                    case '0': Console.WriteLine("Вихід із програми..."); break;
                    default: Console.WriteLine("Введена неправильна команда. Спробуйте знову!!!"); break;
                }
                Console.WriteLine(new string('-', 50));
            } while (menu != '0');
        }
        static void MenuForBinaryTree()
        {
            char menu;
            BinaryTree tree = new BinaryTree();
            Stopwatch stopwatch;
            do
            {                
                Console.WriteLine("Меню для бінарного дерева!!!");
                Console.WriteLine("1. Додавання елементу.");
                Console.WriteLine("2. Видалення елементу.");
                Console.WriteLine("3. Виведення дерева в порядку спадання.");
                Console.WriteLine("0. Вихід із меню.");
                Console.Write("Введіть пункт меню: ");
                menu = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                switch (menu)
                {
                    case '1': stopwatch = new Stopwatch(); Console.Write("Введіть елемент для додавання: "); int data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); tree.Add(data); stopwatch.Stop(); Console.WriteLine("Елемент додано. Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '2': stopwatch = new Stopwatch(); Console.Write("Введіть елемент для видалення: "); data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); tree.Remove(data); stopwatch.Stop(); Console.WriteLine("Елемент видалено. Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '3': stopwatch = new Stopwatch(); Console.WriteLine("Дерево в порядку спадання: "); stopwatch.Start(); foreach (int item in tree) Console.Write(item + " "); stopwatch.Stop(); Console.WriteLine("\nТривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '0': Console.WriteLine("Вихід із меню..."); break;
                    default: Console.WriteLine("Введена неправильна команда. Спробуйте знову!!!"); break;
                }
                Console.WriteLine(new string('-', 50));
            } while (menu != '0');
        }
        static void MenuForAVLTree()
        {
            char menu;
            AVL_Tree tree = new AVL_Tree();
            Stopwatch stopwatch;
            do
            {
                Console.WriteLine("Меню для АВЛ дерева!!!");
                Console.WriteLine("1. Додавання елементу.");
                Console.WriteLine("2. Видалення елементу.");
                Console.WriteLine("3. Пошук елемента.");
                Console.WriteLine("4. Виведення дерева в порядку спадання.");
                Console.WriteLine("0. Вихід із меню.");
                Console.Write("Введіть пункт меню: ");
                menu = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                switch (menu)
                {
                    case '1': stopwatch = new Stopwatch(); Console.Write("Введіть елемент для додавання: "); int data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); tree.Add(data); stopwatch.Stop(); Console.WriteLine("Елемент додано. Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '2': stopwatch = new Stopwatch(); Console.Write("Введіть елемент для видалення: "); data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); tree.Remove(data); stopwatch.Stop(); Console.WriteLine("Елемент видалено. Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '3': stopwatch = new Stopwatch(); Console.Write("Введіть елемент для його знаходження: "); data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); if (tree.Contains(data)) Console.WriteLine("Елемент знайдено."); else Console.WriteLine("Елемент відсутній."); stopwatch.Stop(); Console.WriteLine("Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '4': stopwatch = new Stopwatch(); Console.WriteLine("Дерево в порядку спадання: "); stopwatch.Start(); foreach (int item in tree) Console.Write(item + " "); stopwatch.Stop(); Console.WriteLine("\nТривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '0': Console.WriteLine("Вихід із меню..."); break;
                    default: Console.WriteLine("Введена неправильна команда. Спробуйте знову!!!"); break;
                }
                Console.WriteLine(new string('-', 50));
            } while (menu != '0');
        }
        static void MenuForRedBlackTree()
        {
            char menu;
            RedBlackTree tree = new RedBlackTree();
            Stopwatch stopwatch;
            do
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Меню!!!");
                Console.WriteLine("1. Додавання елементу.");
                Console.WriteLine("2. Видалення елементу.");
                Console.WriteLine("3. Пошук елементу.");
                Console.WriteLine("4. Виведення в порядку зростання.");
                Console.WriteLine("0. Вихід із програми.");
                Console.Write("Введіть пункт меню: ");
                menu = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                switch (menu)
                {
                    case '1': stopwatch = new Stopwatch(); Console.Write("Введіть значення елементу для додавання: "); int data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); tree.Insert(data); stopwatch.Stop(); Console.WriteLine("Елемент додано. Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '2': stopwatch = new Stopwatch(); Console.Write("Введіть значення елементу для видалення: "); data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); tree.Delete(data); stopwatch.Stop(); Console.WriteLine("Елемент видалено. Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '3': stopwatch = new Stopwatch(); Console.WriteLine("Введіть значення елемента для пошуку: "); data = Convert.ToInt32(Console.ReadLine()); stopwatch.Start(); RedBlackTree.Node contains = tree.FindElement(data); stopwatch.Stop(); Console.WriteLine("Тривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '4': stopwatch = new Stopwatch(); Console.WriteLine("Дерево в порядку спадання елементів: "); stopwatch.Start(); tree.DisplayTree(); stopwatch.Stop(); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("\nТривалість алгоритму: {0} ms", stopwatch.Elapsed); break;
                    case '0': Console.WriteLine("Вихід із програми..."); break;
                    default: Console.WriteLine("Введена неправильна команда. Спробуйте знову!!!"); break;
                }
                Console.WriteLine(new string('-', 50));
            } while (menu != '0');
        }
    }
}
