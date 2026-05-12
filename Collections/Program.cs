namespace HomeWork
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> list = new List<string>() { "a", "b", "c", };
        public void TaskLoop()
            {
                while (true)
                {
                    Console.WriteLine("Введите новую строку:");
                    string newElement = Console.ReadLine();
                    list.Add(newElement);

                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("Введите новую строку:");
                    string newElement2 = Console.ReadLine();
                    list.Insert(list.Count / 2, newElement2);

                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("Чтобы выйти введите -exit");
                    if (Console.ReadLine() == "-exit")
                    { return; }
                }
            }
        }

        private class LinkedListTask
        {
            private LinkedList<string> nodeList = new LinkedList<string>();

            public void TaskLoop()
            {
                while (true)
                {
                    while (nodeList.Count < 4)
                    {
                        Console.WriteLine("Введите новый элемент");
                        nodeList.AddLast(Console.ReadLine());
                    }

                    foreach (string node in nodeList)
                    {
                        Console.WriteLine(node);
                    }

                    foreach (string node in nodeList.Reverse())
                    {
                        Console.WriteLine(node);
                    }

                    Console.WriteLine("Чтобы выйти введите -exit");
                    if (Console.ReadLine() == "-exit")
                    { return; }
                    nodeList.Clear();
                }
            }
        }

        private class DictionaryTask
        {
            private Dictionary<string, int> students = new Dictionary<string, int>();

            public void TaskLoop()
            {
                while (true)
                {
                    Console.WriteLine("Введите фамилию студента:");
                    string newName = Console.ReadLine();

                    Console.WriteLine("Введите оценку студента:");
                    int grade;

                    while (true)
                    {
                        grade = Convert.ToInt32(Console.ReadLine());
                        if (grade >= 2 && grade <= 5)
                        {
                            break;
                        }
                        Console.WriteLine("Оцека может быть только от 2 до 5");
                    }

                    students.Add(newName, grade);


                    Console.WriteLine("Введите фамилию студента:");
                    string name = Console.ReadLine();

                    if (students.TryGetValue(name, out int grade2))
                    {
                        Console.WriteLine(grade2);
                    }
                    else
                    {
                        Console.WriteLine("Студента с таким именем не существует");
                    }

                    Console.WriteLine("Чтобы выйти введите -exit");
                    if (Console.ReadLine() == "-exit")
                    { return; }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
            int.TryParse(Console.ReadLine(), out int task);
            switch (task)
            {
                case 1:
                    CheckTaskFirst();
                    break;
                case 2:
                    CheckTaskSecond();
                    break;
                case 3:
                    CheckTaskThird(); 
                    break;
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }
        private static void CheckTaskSecond()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }
        private static void CheckTaskThird()
        {
            var linkedListTask = new LinkedListTask();
            linkedListTask.TaskLoop();
        }
    }
}




