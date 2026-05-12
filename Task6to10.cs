using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Task6to10
{

    public static List<T> ReadList<T>()
    {
        List<T> list = new List<T>();
        int count;
        Console.Write("Введите количество элементов: ");
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.Write("Ошибка! Введите число > 0: ");
        }
        for (int i = 0; i < count; i++)
        {
            Console.Write("Элемент " + (i + 1) + ": ");
            string input = Console.ReadLine();
            T value = (T)Convert.ChangeType(input, typeof(T));
            list.Add(value);
        }
        return list;
    }

    public static void InsertSorted<T>(List<T> list1, List<T> list2) where T : IComparable<T>
    {
        for (int i = 0; i < list2.Count; i++)
        {
            T value = list2[i];

            int pos= 0;

            while (pos < list1.Count && list1[pos].CompareTo(value) < 0)
            {
                pos++;
            }

            list1.Insert(pos, value);
        }
    }

    public static void PrintList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }

    public static LinkedList<T> ReadLinkedList<T>()
    {
        LinkedList<T> list = new LinkedList<T>();
        int count;
        Console.Write("Введите количество элементов: ");
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.Write("Ошибка! Введите число > 0: ");
        }
        for (int i = 0; i < count; i++)
        {
            Console.Write("Элемент " + (i + 1) + ": ");
            string input = Console.ReadLine();
            T value = (T)Convert.ChangeType(input, typeof(T));
            list.AddLast(value);
        }
        return list;
    }

    public static int CountEqualNeighbors<T>(LinkedList<T> list) where T : IEquatable<T>
    {
        if (list.Count < 3)
        {
            return 0;
        }
        int count = 0;
        LinkedListNode<T> current = list.First;
        while (current != null)
        {
            if (current.Previous != null && current.Next != null)
            {
                if (current.Previous.Value.Equals(current.Next.Value))
                {
                    count++;
                }
            }
            current = current.Next;
        }
        return count;
    }

    public static void PrintLinkedList<T>(LinkedList<T> list)
    {
        LinkedListNode<T> current = list.First;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public static List<HashSet<string>> ReadVisit()
    {
        List<HashSet<string>> visitors = new List<HashSet<string>>();
        int n = 0;
        int k = 0;
        Console.Write("Введите количество посетителей: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Ошибка! Введите целое число больше 0: ");
        }
        for (int i = 0; i < n; i++)
        {
            HashSet<string> numDishes = new HashSet<string>();
            Console.Write("Введите количество блюд у посетителя: ");
            while (!int.TryParse(Console.ReadLine(), out k) || k < 0)
            {
                Console.Write("Ошибка! Введите целое число больше 0: ");
            }
            for (int j = 0; j < k; j++)
            {
                Console.Write("Введите блюдо: ");
                string dish = Console.ReadLine();
                numDishes.Add(dish);
            }
            visitors.Add(numDishes);
        }
        return visitors;
    }

    public static void Dishes(HashSet<string> allDishes, List<HashSet<string>> visitors)
    {
        HashSet<string> all = new HashSet<string>(allDishes);
        HashSet<string> some = new HashSet<string>();

        foreach (var visitorDishes in visitors)
        {
            some.UnionWith(visitorDishes);
        }

        HashSet<string> intersection = new HashSet<string>(allDishes);
        foreach (var visitorDishes in visitors)
        {
            intersection.IntersectWith(visitorDishes); 
        }

        HashSet<string> none = new HashSet<string>(allDishes);
        none.ExceptWith(some); 

        Console.WriteLine("Заказали все:");
        PrintSet(all);

        Console.WriteLine("Заказали некоторые:");
        PrintSet(some);

        Console.WriteLine("Не заказал никто:");
        PrintSet(none);
    }

    public static void PrintSet(HashSet<string> set)
    {
        List<string> list = new List<string>(set);
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }

    public static void PrintConsonants(string path)
    {
        string text = File.ReadAllText(path);
        string[] words = SplitWords(text);

        HashSet<char> result = new HashSet<char>();

        foreach (string word in words)
        {
            if (word != "")
            {
                HashSet<char> lettersInWord = new HashSet<char>();
                foreach (char c in word)
                {
                    if (IsConsonant(c))
                    {
                        lettersInWord.Add(c);
                    }
                }
                foreach (char c in lettersInWord)
                {
                    // если буква уже встречалась — удаляем
                    if (result.Contains(c))
                    {
                        result.Remove(c);
                    }
                    else
                    {
                        // если встретили впервые — добавляем
                        result.Add(c);
                    }
                }
            }
        }
        foreach (char c in result)
        {
            Console.Write(c + " ");
        }
    }

    private static bool IsConsonant(char c)
    {
        string consonants = "бвгджзйклмнпрстфхцчшщ";
        return consonants.IndexOf(c) != -1;  // проверка, есть ли символ в строке (-1 если нет)
    }

    private static string[] SplitWords(string text)
    {
        char[] separators = { ' ', ',', '.', '!', '?', ':', ';', '\n', '\r', '\t' };
        return text.Split(separators);
    }


    public static void CompetitionTop3(string path)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string[] lines = File.ReadAllLines(path);
        int n = int.Parse(lines[0]); // кол-во участников
        // чтение и подсчёт
        for (int i = 1; i <= n; i++)
        {
            string[] parts = lines[i].Split(' ');
            string name = parts[0] + " " + parts[1]; // фио
            int sum = 0;
            for (int j = 2; j < parts.Length; j++)
            {
                sum += int.Parse(parts[j]);
            }
            if (dict.ContainsKey(name)) // если участиник есть 
            {
                dict[name] += sum; // добавляем 
            }
            else
            {
                dict[name] = sum;
            }
        }
        for (int k = 0; k < 3; k++)
        {
            string bestName = "";
            int bestScore = -1;
            foreach (var item in dict)
            {
                if (item.Value > bestScore)
                {
                    bestScore = item.Value;
                    bestName = item.Key;
                }
            }
            Console.WriteLine(bestName + " " + bestScore);
            dict.Remove(bestName);
        }
    }
}

























