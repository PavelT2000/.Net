using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TODOLIst;

namespace TaskManager
{
    public static class TasksData
    {
        static private List<MyTask> tasks = new List<MyTask>();
        static public void Save()
        {
            string jsonData = JsonConvert.SerializeObject(tasks);
            File.WriteAllText("file.json", jsonData);
        }
        public static void Load()
        {
            if (File.Exists("file.json"))
            {
                string jsonData = File.ReadAllText("file.json");
                tasks = JsonConvert.DeserializeObject<List<MyTask>>(jsonData);
            }
        }
        public static List<MyTask> GetTasks()
        {
            return tasks;
        }
        public static MyTask GetTaskById(int id)
        {
            if (id >= 0 && id < tasks.Count)
            {
                return tasks[id];
            }
            else
            {
                throw new Exception("Out of tasks range");
            }
        }
        public static void AddTask(string name, string description, DateTime? timeD)
        {

            tasks.Add(new MyTask(name, description, timeD));

        }
        public static void RemoveTask(int id)
        {

            tasks.RemoveAt(id);
        }

    }



}

