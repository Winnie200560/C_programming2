using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Serializable]
public struct Luggage
{
    private string _name;
    private double _weight;
    public string Name
    {
        get 
        { 
            return _name; 
        }
        set 
        {
            if (value.Length != 0 && value != null)
            {
                _name = value;
            }
            else
            {
                Console.WriteLine("Название не может быть пустым!");
            }
        }
    }
    public double Weight
    {
        get 
        { 
            return _weight; 
        }
        set 
        {
            if (value <= 0)
            {
                Console.WriteLine("Ошибка! Значение должно быть не отрицательным!");
            }
            else
            {
                _weight = value;
            }
        }
    }
}

internal class Task1to5
{
    public static void FillFileInt(string way, int n)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        StreamWriter w = new StreamWriter(way);
        Random rnd = new Random();
        int num = 0;
        for (int i = 0; i < n; i++)
        {
            num = rnd.Next(0, 101);
            w.WriteLine(num);
        }
        w.Close();
    }

    public static int DifferentMaxMin(string way)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return 0;
        }
        StreamReader r = new StreamReader(way);
        int min = int.MaxValue;
        int max = int.MinValue;
        string l = " ";
        int num = 0;
        while ((l = r.ReadLine()) != null)
        {
            num = int.Parse(l);
            if (num < min)
            {
                min = num;
            }
            if (num > max)
            {
                max = num;
            }
        }
        r.Close();
        Console.WriteLine("Минимум: " + min);
        Console.WriteLine("Максимум: " + max);
        return max - min;
    }

    public static void PrintFile(string way)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        StreamReader r = new StreamReader(way);
        string l = " ";
        Console.WriteLine("Содержимое файла: ");
        while ((l = r.ReadLine()) != null)
        {
            Console.WriteLine(l);
        }
        r.Close();
    }

    public static void FillFileIntSeveral(string way, int line, int n)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        StreamWriter w = new StreamWriter(way);
        int num = 0;
        Random rnd = new Random();
        for (int i = 0; i < line; i++)
        {
            for (int j = 0; j < n; j++)
            {
                num = rnd.Next(0, 101);
                w.Write(num + " ");
            }
            w.WriteLine();
        }
        w.Close();
    }

    public static int FindMin(string way)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return 0;
        }
        StreamReader r = new StreamReader(way);
        int min = 1000;
        string l = "";
        int num = 0;
        while ((l = r.ReadLine()) != null)
        {
            string[] parts = l.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] != "")
                {
                    num = int.Parse(parts[i]);

                    if (num < min)
                    {
                        min = num;
                    }
                }
            }
        }
        r.Close();
        return min;
    }

    public static void CopyLines(string input, string output, char symbol)
    {
        if (!File.Exists(input))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        StreamReader r = new StreamReader(input);
        StreamWriter w = new StreamWriter(output);
        string l = " ";
        while ((l = r.ReadLine()) != null)
        {
            if (l.Length > 0 && l[0] == symbol)
            {
                w.WriteLine(l);
            }
        }
        r.Close();
        w.Close();
    }

    public static void FillBinaryFile(string way, int n)
    {
        BinaryWriter w = new BinaryWriter(File.Open(way, FileMode.Create));
        int num = 0;
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            num = rnd.Next(0, 11);
            w.Write(num);
        }
        w.Close();
    }

    public static void FilterBinaryFile(string input, string output, int m, int n)
    {
        if (!File.Exists(input))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        BinaryReader r = new BinaryReader(File.Open(input, FileMode.Open));
        BinaryWriter w = new BinaryWriter(File.Open(output, FileMode.Create));
        int num = 0;
        while (r.BaseStream.Position < r.BaseStream.Length)
        {
            num = r.ReadInt32();
            if (num % m == 0 && num % n != 0)
            {
                w.Write(num);
            }
        }
        r.Close();
        w.Close();
    }

    public static void PrintBinaryFile(string way)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        BinaryReader r = new BinaryReader(File.Open(way, FileMode.Open));
        Console.WriteLine("Содержимое бинарного файла:");
        int num = 0;
        while (r.BaseStream.Position < r.BaseStream.Length)
        {
            num = r.ReadInt32();
            Console.Write(num + " ");
        }
        Console.WriteLine();
        r.Close();
    }

    public static void FillFileXML(string way)
    {
        List<List<Luggage>> d = new List<List<Luggage>>
        {
            new List<Luggage>
            {
                new Luggage { Name = "чемодан", Weight = 20 },
                new Luggage { Name = "сумка", Weight = 5 }
            },
            new List<Luggage>
            {
                new Luggage { Name = "рюкзак", Weight = 8 }
            },
            new List<Luggage>
            {
                new Luggage { Name = "коробка", Weight = 15 },
                new Luggage { Name = "сумка", Weight = 10 }
            }
        };
        XmlSerializer ser = new XmlSerializer(typeof(List<List<Luggage>>));
        FileStream f = new FileStream(way, FileMode.Create);
        ser.Serialize(f, d);
        f.Close();
    }

    public static bool FindPass(string way, int m)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
            return false;
        }
        XmlSerializer ser = new XmlSerializer(typeof(List<List<Luggage>>));
        FileStream fs = new FileStream(way, FileMode.Open);
        List<List<Luggage>> d = (List<List<Luggage>>)ser.Deserialize(fs);
        fs.Close();
        for (int i = 0; i < d.Count; i++)
        {
            if (d[i].Count == 1 && d[i][0].Weight < m)
            {
                return true;
            }
        }
        return false;
    }

    public static void PrintXmlFile(string way)
    {
        if (!File.Exists(way))
        {
            Console.WriteLine("Файл не найден!");
        } 
        XmlSerializer ser = new XmlSerializer(typeof(List<List<Luggage>>));
        FileStream fs = new FileStream(way, FileMode.Open);
        List<List<Luggage>> d = (List<List<Luggage>>)ser.Deserialize(fs);
        fs.Close();
        Console.WriteLine("Содержимое файла багажа:");
        for (int i = 0; i < d.Count; i++)
        {
            Console.WriteLine("Пассажир " + (i + 1) + ":");
            for (int j = 0; j < d[i].Count; j++)
            {
                Console.WriteLine("  " +
                    d[i][j].Name + " - " +
                    d[i][j].Weight + " кг");
            }
        }
    }

}
