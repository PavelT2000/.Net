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
    public class MyTask
    {
        [JsonProperty("name")]
        private string _name
        {
            get; set;
        }
        [JsonProperty("description")]
        private string _description
        {
            get; set;
        }
        [JsonProperty("date")]
        private DateTime? _date
        {
            get; set;
        }

        public MyTask()
        {
        }

        
        public MyTask(string name, string description)
        {
            this._name = name;
            this._description = description;
            _date = null;
            
        }

        public MyTask(string name, string description, DateTime? date)
        {
            this._name = name;
            this._description = description;
            this._date = date;
        }

        public void OutData()
        {
            Console.WriteLine($"Задача: {_name}\nОписание:\n{_description}\nДата: {_date.ToString()}\n");
            

        }
        public void SetName(string name)
        {
            this._name=name;
        }
        public void SetDescription(string description)
        {
            this._description = description;
        }
        public void SetDate(DateTime? date)
        {
            this._date = date;
        }
        public string name => _name;
        public string description => _description;
        public DateTime? date => _date;
        
    }
    
}
