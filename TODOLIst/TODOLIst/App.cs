using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

enum state
{
    menu,
    delete,
    change
}
namespace TODOLIst
{
    abstract class App
    {
        static bool isWorking;
        static int choosedTask=-1;
        
        static string MainMenu =
            "Выберите действие\n" +
            "0. Выход\n" +
            "1. Вывод задач\n" +
            "2. Добавить задачу\n" +
            "3. Выбрать задачу\n" +
            "4. Удалить задачу\n" +
            "5. Редактиоровать задачу\n" +
            "6. Сохранить\n";
        static string DeleteMenu = 
            "1. Удалить выбранную\n" +
            "2. Удалить все\n";
        static string currentMenu=MainMenu;
        static state state = state.menu;
        static List<Task> tasks = new List<Task>();

        public static void StartApp()
        {
            Load();
            isWorking = true;
            state = state.menu;
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine(currentMenu);
                ReadInput();
            }
        }
        public static void ReadInput()
        {
            char key = Console.ReadKey().KeyChar;
            switch (state)
            {
                case state.menu:
                    switch (key)
                    {
                        case '0':
                            Exit();
                            break;
                        case '1':
                            OutTasks();
                            break;
                        case '2':
                            AddTask();
                            break;
                        case '3':
                            ChooseTask();
                            break;
                        case '4':
                            Delete();
                            break;
                        case '6':
                            Save();
                            break;
                    }
                    break;
                case state.delete:
                    switch(key)
                    {
                        case '1':
                            DeleteChoosed();
                            break;
                        case '2':
                            DeleteAll();
                                break;
                    }
                break;
            }
        }
        public static void Exit()
        {
            Console.Clear() ;
            Console.WriteLine($"Вы хотите соохранить задачи");
            Console.WriteLine("1.Да\n" +
                "2.Нет");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Save();
                    Console.Clear ();
                    Environment.Exit(0);
                    break;
                case '2':
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }
        public static void DeleteAll()
        {
            Console.Clear();
            
                Console.WriteLine($"Вы уверены что хотите удалить все задачи");
                Console.WriteLine("1.Да\n" +
                    "2.Нет");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        tasks.Clear();
                    Console.Clear();
                    Console.WriteLine("Вы всё нахуй удалили\nнажмите любую клавишу чтобы продолжить...");
                    Console.ReadKey();
                    break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Вы ничего не удалили\nнажмите любую клавишу чтобы продолжить...");
                        Console.ReadKey();
                        break;
                }
            
            currentMenu = MainMenu;
            state = state.menu;
        }
        public static void DeleteChoosed()
        {
            Console.Clear();
            if (choosedTask != -1)
            {
                Console.WriteLine($"Вы уверены что хотите удалить задачу {choosedTask + 1}");
                tasks[choosedTask].OutData();
                Console.WriteLine("1.Да\n" +
                    "2.Нет");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        tasks.RemoveAt(choosedTask);
                        Console.Clear();
                        Console.WriteLine($"Вы удалили задачу №{choosedTask+1}\nнажмите любую клавишу чтобы продолжить...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Вы ничего не удалили\nнажмите любую клавишу чтобы продолжить...");
                        Console.ReadKey();
                        break;
                }
            }
            currentMenu = MainMenu;
            state=state.menu;
        }
        public static void Delete()
        {
            state = state.delete;
            currentMenu = DeleteMenu;

        }

        public static void Save()
        {
            Console.Clear();
            Console.WriteLine("Сохраняем...");
            string jsonData = JsonConvert.SerializeObject(tasks);
            File.WriteAllText("file.json", jsonData);
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Сохранено\nнажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();
        }
        public static void Load()
        {
            if (File.Exists("file.json"))
            {
                string jsonData = File.ReadAllText("file.json");
                tasks = JsonConvert.DeserializeObject<List<Task>>(jsonData);
            }
        }

        public static void ChooseTask()
        {
            if (tasks.Count != 0)
            {
                Console.Clear();
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"ЗАДАЧА №{i + 1}\n");
                    tasks[i].OutData();
                }
                Console.WriteLine("Выберите номер задачи");
                choosedTask = -1;
                if (int.TryParse(Console.ReadLine(), out choosedTask))
                {
                    Console.WriteLine("Задача выбрана\nнажмите любую клавишу чтобы продолжить...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Задача не выбрана\nнажмите любую клавишу чтобы продолжить...");
                    Console.ReadKey();
                }
                choosedTask = choosedTask == -1 ? -1 : choosedTask -1;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("У вас нет ни одной задачи\nнажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
            }


        }
        public static void OutTasks()
        {
            Console.Clear();
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"ЗАДАЧА №{i+1}\n");
                tasks[i].OutData();
            }
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();
        }
        public static void AddTask()
        {
            Console.Clear();
            Console.WriteLine("Введите название задачи");
            string name = Console.ReadLine();
            Console.WriteLine("Введите описание задачи");
            string description = Console.ReadLine();
            Console.WriteLine("Время в формате дд.мм.гг или просто нажмите Enter");
            string time = Console.ReadLine();
            DateTime timeD = DateTime.Now;
            DateTime.TryParse(time, out timeD);
            tasks.Add(new Task(name, description, timeD));
            Console.WriteLine("Добавляем вашу задачу...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Успешно добавлено\nНажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();
        }
    }
}
