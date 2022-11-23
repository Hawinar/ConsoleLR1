using System;

namespace ConsoleLR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Введите {i + 1}-е целочисленное число:");
                int number = int.Parse(Console.ReadLine());
                list.AddElement(ref list._current, number);
            }
            while (true)
            {
                Console.WriteLine("Введите:\n1 - для просмотра всех элементов списка" +
               "\n2 - для вставки элемента справа" +
               "\n3 - для поиска элемента" +
               "\n4 - для удаления элемента" +
               "\n5 - для очистки списка" +
               "\n6 - для замены элемента" +
               "\n7 - для ввода числа справа от первого");
                int number = 0;
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        list.Show();
                        break;
                    case 2:
                        Console.WriteLine("Введите число для добавления:");
                        number = int.Parse(Console.ReadLine());
                        list.AddElement(ref list._current, number);
                        break;
                    case 3:
                        Console.WriteLine("Введите число для поиска");
                        number = int.Parse(Console.ReadLine());
                        if (list.Search(number) != null)
                            Console.WriteLine(list.Search(number).Value);
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 4:
                        Console.WriteLine("Введите число для удаления");
                        number = int.Parse(Console.ReadLine());
                        if (list.Search(number) != null)
                            list.RemoveElement(list.Search(number));
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 5:
                        list.ClearList();
                        break;
                    case 6:
                        Console.WriteLine("Введите число для редактирования");
                        int target = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите желаемое число");
                        number = int.Parse(Console.ReadLine());
                        if (list.Search(target) != null)
                            list.Replace(list.Search(target), number);
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 7:
                        Console.WriteLine("Введите число для ввода правее первого");
                        number = int.Parse(Console.ReadLine());
                        list.AddElementRight(number);
                        break;
                }
            }
        }
    }
    class MyListElement
    {
        public int Value;
        public MyListElement Next;
        public MyListElement(MyListElement next, int value)
        {
            Next = next;
            Value = value;
        }
    }
    class MyList
    {
        public MyListElement _head = null;
        public MyListElement _current = null;
        public MyList() { }
        public void AddFirstElement(int value)
        {
            MyListElement tmp = new MyListElement(null, value);
            if (_head == null)
                _head = tmp;
            else
            {
                _head.Next = _head;
                _head = tmp;
            }
        }
        public void AddElement(ref MyListElement current, int value)
        {
            if (_head == null)
            {
                AddFirstElement(value);
                _current = _head;
            }
            else
            {
                MyListElement tmp = new MyListElement(null, value);
                tmp.Next = _current.Next;
                _current.Next = tmp;
                _current = tmp;
            }
            current = _current;
        }
        public void Show()
        {
            Console.WriteLine("Вывод всех элементов однонаправленного списка:");
            MyListElement tmp = _head;
            while (tmp != null)
            {
                Console.Write(tmp.Value + " ");
                tmp = tmp.Next;
            }
        }
        public MyListElement Search(int value)
        {
            MyListElement tmp = _head;
            while (tmp != null)
            {
                if (tmp.Value == value)
                    return tmp;
                tmp = tmp.Next;
            }
            return null;

        }
        public void RemoveElement(MyListElement target)
        {
            if (_head == target)
                _head = _head.Next;
            else
            {
                MyListElement tmp = _head;
                while (tmp.Next != target)
                    tmp = tmp.Next;
                tmp.Next = target.Next;
            }
        }
        public void ClearList()
        {
            MyListElement tmp;
            while (_head != null)
            {
                tmp = _head.Next;
                _head = tmp;
            }
        }
        public void Replace(MyListElement target, int number)
        {
            target.Value = number;
        }
        public void AddElementRight(int value)
        {
            if (_head == null)
            {
                AddFirstElement(value);
                _current = _head;
            }
            else
            {
                MyListElement node = new MyListElement(null, value);
                MyListElement tmp = _head.Next;
                _head.Next = node;
                node.Next = tmp;
            }
        }
    }
}