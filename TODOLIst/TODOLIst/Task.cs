using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TODOLIst
{
    [Serializable]
    public class Task
    {
        [JsonProperty("name")]
        private string name
        {
            get; set;
        }
        [JsonProperty("description")]
        private string description
        {
            get; set;
        }
        [JsonProperty("date")]
        private DateTime? date
        {
            get; set;
        }

        public Task()
        {
        }

        
        public Task(string name, string description)
        {
            this.name = name;
            this.description = description;
            date = null;
            
        }

        public Task(string name, string description, DateTime? date)
        {
            this.name = name;
            this.description = description;
            this.date = date;
        }

        public void OutData()
        {
            Console.WriteLine($"Задача: {name}\nОписание:\n{description}\nДата: {date.ToString()}\n");
            

        }
        
    }
    
}
