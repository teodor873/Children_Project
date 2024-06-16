using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Children
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                teodor 6382749384 boy 34 190 90
                gabriela 0194826391 girl 12 180 50
                denislav 0392847394 boy 14 179 70
                preslava 0394948274 girl 23 165 45
                nikolay 8274913857 boy 11 130 40
             */
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
 _       __     __                        
| |     / /__  / /________  ____ ___  ___ 
| | /| / / _ \/ / ___/ __ \/ __ `__ \/ _ \
| |/ |/ /  __/ / /__/ /_/ / / / / / /  __/
|__/|__/\___/_/\___/\____/_/ /_/ /_/\___/                                                                                                                                                                                                                                                                                            
");


            List<ChildInfo> children = new List<ChildInfo>();
            List<Boy> boys = new List<Boy>();
            List<Girl> girls = new List<Girl>();

            try
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("What do you want to do?" +
                        "\n1-Add" +
                        "\n2-print N kids" +
                        "\n3-print skinny kids by gender" +
                        "\n4-shows the average hight of the kids" +
                        "\n5-Shows the oldest kid" +
                        "\n6-Shows all kids sorted" +
                        "\n7-Save" +
                        "\n8-Save As" +
                        "\n9-Bye(End)");
                    Console.WriteLine();
                    Console.Write("Enter:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string choise = Console.ReadLine();
                    Console.WriteLine();

                    if (choise.ToLower() == "end" || choise.ToLower() == "bye" || choise.ToLower() == "9")
                    {
                        break;
                    }

                    switch (choise)
                    {
                        case "1": AddChildren(children, boys, girls); break;

                        case "2": PrintN(children); break;

                        case "3": PrintSkinnyKids(boys, girls); break;

                        case "4": PrintAverageHeight(children); break;

                        case "5": PrintOldest(children); break;

                        case "6": PrintSorted(children); break;

                        case "7": Save(children); break;

                        case "8": SaveAs(children); break;

                        default:
                            Console.WriteLine("There is no command");
                            break;
                    }

                    Console.WriteLine();
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void AddChildren(List<ChildInfo> children, List<Boy> boys, List<Girl> girls)
        {
            string danni = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("When you want to stop type end!");
            Console.ForegroundColor = ConsoleColor.White;
            while (danni.ToLower() != "end")
            {

                Console.WriteLine("Enter:[Name], [egn], [gender], [age when last measured], [hight(cm)], [weight].");
                string[] danni2 = Console.ReadLine().Split();

                danni = danni2[0].ToLower();
                if (danni == "end")
                {
                    break;
                }
                if (danni2[2].ToLower() == "boy")
                {
                    Boy boy = new Boy(danni2[0], danni2[1], danni2[2], int.Parse(danni2[3]), int.Parse(danni2[4]), float.Parse(danni2[5]));
                    boys.Add(boy);
                    children.Add(boy);
                }
                if (danni2[2].ToLower() == "girl")
                {
                    Girl girl = new Girl(danni2[0], danni2[1], danni2[2], int.Parse(danni2[3]), int.Parse(danni2[4]), float.Parse(danni2[5]));
                    girls.Add(girl);
                    children.Add(girl);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("...");
            Console.WriteLine("Done");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void PrintN(List<ChildInfo> children)
        {
            Console.Write("Enter how many kids you want to show:");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Kids:");
            for (int i = 0; i < count; i++)
            {
                if (i >= children.Count)
                {
                    Console.WriteLine("No more kids");
                    break;
                }
                Console.WriteLine(children[i].Print());
            }
        }

        public static void PrintSkinnyKids(List<Boy> boys, List<Girl> girls)
        {
            float skinnyBoy = boys.Min(x => x.Weight);
            float skinnyGirl = girls.Min(x => x.Weight);

            Console.WriteLine("Skiniest boy");
            foreach (Boy boy in boys)
            {
                if (boy.Weight == skinnyBoy)
                {

                    Console.WriteLine(boy.Print());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Skiniest girl");
            foreach (Girl girl in girls)
            {
                if (girl.Weight == skinnyGirl)
                {
                    Console.WriteLine(girl.Print());
                }
            }
        }

        public static void PrintAverageHeight(List<ChildInfo> children)
        {
            foreach (ChildInfo chd in children)
            {
                double height = chd.GetHeight(children);
                Console.WriteLine($"Average height: {height:f2}");
                break;
            }
        }

        public static void PrintOldest(List<ChildInfo> children)
        {
            var oldestChild = children.OrderBy(x => x.AgeMeasure).Last();
            Console.WriteLine($"Oldest child:\n{oldestChild.Print()}");
            Console.WriteLine();
        }

        public static void Sorted(List<ChildInfo> children)
        {
            ChildComparer cc = new ChildComparer();

            Console.WriteLine("Sorted:");
            children.Sort(cc);
            children.ToList().ForEach(x => x.Print());

            Console.WriteLine();

        }

        public static void PrintSorted(List<ChildInfo> children)
        {
            Console.WriteLine("Sorted kids by name:");

            ChildComparer compare = new ChildComparer();
            children.Sort(compare);
            children.ForEach(x => Console.WriteLine(x.Print()));
            Console.WriteLine();
        }

        public static void Save(List<ChildInfo> children)
        {
            using (StreamWriter writer = new StreamWriter("deca.txt"))
            {
                children.ToList().ForEach(x => writer.WriteLine(x.Print()));
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("...");
            Console.WriteLine("Done");
            Console.WriteLine("Data is saved.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void SaveAs(List<ChildInfo> children)
        {
            Console.WriteLine("Enter files name(.txt):");
            string fileName = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                children.ToList().ForEach(x => writer.WriteLine(x.Print()));
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("...");
            Console.WriteLine("Done");
            Console.WriteLine("Data is saved.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }


    }
}
