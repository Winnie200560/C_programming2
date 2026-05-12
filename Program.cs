using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Выберите задание: ");
        Console.WriteLine("1 - Max - Min");
        Console.WriteLine("2 - Min");
        Console.WriteLine("3 - Копировани строки");
        Console.WriteLine("4 - Бинарный файл");
        Console.WriteLine("5 - XML");
        Console.WriteLine("6 - Списки_1");
        Console.WriteLine("7 - Списки_2");
        Console.WriteLine("8 - Блюда");
        Console.WriteLine("9 - Согласные");
        Console.WriteLine("10 - Соревнования");
        Console.WriteLine("0 - Выход");
        Console.Write("Выбор: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                {
                    string file1 = "numbers.txt";
                    Task1to5.FillFileInt(file1, 10);
                    Task1to5.PrintFile(file1);
                    Console.WriteLine("Разность макс и мин: " + Task1to5.DifferentMaxMin(file1));
                    break;
                }
            case "2":
                {
                    string file2 = "numbers2.txt";
                    Task1to5.FillFileIntSeveral(file2, 10, 2);
                    Task1to5.PrintFile(file2);
                    Console.WriteLine("Минимальный элемент: " + Task1to5.FindMin(file2));
                    Console.WriteLine();
                    break;
                }
            case "3":
                {
                    string file2 = "numbers2.txt";
                    string input = "text.txt";
                    string output = "textout.txt";
                    if (!File.Exists(input))
                    {
                        Console.WriteLine("Файл не найден: " + input);
                    }
                    else if (!File.Exists(output))
                    {
                        Console.WriteLine("Файл не найден: " + output);
                    }
                    else
                    {
                        Task1to5.PrintFile(input);
                        Task1to5.CopyLines(input, output, 'S');
                        Console.WriteLine();
                        Console.WriteLine("После копирования:");
                        Task1to5.PrintFile(output);
                        Console.WriteLine();
                    }
                    break;
                }
            case "4":
                {
                    string inputBin = "bin.dat";
                    string outputBin = "result.dat";
                    Task1to5.FillBinaryFile(inputBin, 10);
                    Task1to5.PrintBinaryFile(inputBin);
                    int m = 2;
                    int n = 3;
                    Task1to5.FilterBinaryFile(inputBin, outputBin, m, n);
                    Console.WriteLine("После фильтрации (делятся на " + m + ", не делятся на " + n + "):");
                    Task1to5.PrintBinaryFile(outputBin);
                    Console.WriteLine();
                    break;
                }
            case "5":
                {
                    string fileXML = "luggage.xml";
                    Task1to5.FillFileXML(fileXML);
                    Console.WriteLine("До проверки: ");
                    Task1to5.PrintXmlFile(fileXML);
                    bool result = Task1to5.FindPass(fileXML, 10);
                    Console.WriteLine("Результат: ");
                    Console.WriteLine("Есть пассажир с 1 вещью < 10 кг: " + result);
                    Console.WriteLine();
                    break;
                }
            case "6":
                {
                    Console.Write("Введите тип данных (int/string/double): ");
                    string type = Console.ReadLine();

                    if (type == "int")
                    {
                        List<int> L1 = Task6to10.ReadList<int>();
                        List<int> L2 = Task6to10.ReadList<int>();

                        Console.WriteLine("L1 до:");
                        Task6to10.PrintList(L1);

                        Console.WriteLine("L2:");
                        Task6to10.PrintList(L2);

                        Task6to10.InsertSorted(L1, L2);

                        Console.WriteLine("L1 после вставки:");
                        Task6to10.PrintList(L1);
                    }
                    else if (type == "string")
                    {
                        List<string> L1 = Task6to10.ReadList<string>();
                        List<string> L2 = Task6to10.ReadList<string>();

                        Console.WriteLine("L1 до:");
                        Task6to10.PrintList(L1);

                        Console.WriteLine("L2:");
                        Task6to10.PrintList(L2);

                        Task6to10.InsertSorted(L1, L2);

                        Console.WriteLine("L1 после вставки:");
                        Task6to10.PrintList(L1);
                    }
                    else if (type == "double")
                    {
                        List<double> L1 = Task6to10.ReadList<double>();
                        List<double> L2 = Task6to10.ReadList<double>();

                        Console.WriteLine("L1 до:");
                        Task6to10.PrintList(L1);

                        Console.WriteLine("L2:");
                        Task6to10.PrintList(L2);

                        Task6to10.InsertSorted(L1, L2);

                        Console.WriteLine("L1 после вставки:");
                        Task6to10.PrintList(L1);
                    }
                    else
                    {
                        Console.WriteLine("Неподдерживаемый тип");
                    }

                    Console.WriteLine();
                    break;
                }

            case "7":
                {
                    Console.Write("Введите тип данных (int/string/double): ");
                    string type = Console.ReadLine();

                    if (type == "int")
                    {
                        LinkedList<int> L = Task6to10.ReadLinkedList<int>();

                        Console.WriteLine("Список:");
                        Task6to10.PrintLinkedList(L);

                        Console.WriteLine(
                            "Количество элементов с равными соседями: " +
                            Task6to10.CountEqualNeighbors(L)
                        );
                    }
                    else if (type == "string")
                    {
                        LinkedList<string> L =
                            Task6to10.ReadLinkedList<string>();

                        Console.WriteLine("Список:");
                        Task6to10.PrintLinkedList(L);

                        Console.WriteLine(
                            "Количество элементов с равными соседями: " +
                            Task6to10.CountEqualNeighbors(L)
                        );
                    }
                    else if (type == "double")
                    {
                        LinkedList<double> L =
                            Task6to10.ReadLinkedList<double>();

                        Console.WriteLine("Список:");
                        Task6to10.PrintLinkedList(L);

                        Console.WriteLine(
                            "Количество элементов с равными соседями: " +
                            Task6to10.CountEqualNeighbors(L)
                        );
                    }
                    else
                    {
                        Console.WriteLine("Неподдерживаемый тип");
                    }

                    Console.WriteLine();
                    break;
                }
            case "8":
                {
                    HashSet<string> allDishes = new HashSet<string>
                    {
                        "суп",
                        "салат",
                        "пицца",
                        "бургер",
                        "чай"
                    };
                    Console.WriteLine("Доступное меню: ");
                    foreach (var item in allDishes)
                    {
                        Console.WriteLine(item);
                    }
                    List<HashSet<string>> visitors = Task6to10.ReadVisit();
                    Task6to10.Dishes(allDishes, visitors);
                    break;
                }
            case "9":
                {
                    string rus = "russian.txt";
                    Console.WriteLine("Текст из файла:");
                    Console.WriteLine(File.ReadAllText(rus));
                    Console.Write("Согласные, которые входят ровно в одно слово: ");
                    Task6to10.PrintConsonants(rus);
                    break;
                }

            case "10":
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    string win = "sorev.txt";
                    Console.WriteLine("Текст из файла:");
                    Console.WriteLine(File.ReadAllText(win));

                    Console.WriteLine("\n Победители:");
                    Task6to10.CompetitionTop3(win);
                    break;
                }
            case "0":
                {
                    return;
                }

            default:
                {
                    Console.WriteLine("Неверный выбор");
                    break;
                }  
        }
    }
}


















