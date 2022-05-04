using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Goal
    {
        public string Description { get; set; }

        public List<string> Tasks { get; set; }

        public Goal(string description)
        {
            Description = description;
            Tasks = new List<string>();
        }


        /// <summary>
        /// Добавляет задачу к цели
        /// </summary>
        /// <param name="text">Текст задачи</param>
        public void AddTask(string text)
        {
            Tasks.Add(text);
        }


        /// <summary>
        /// Удаляет задачу
        /// </summary>
        /// <param name="index">Индекс задачи в списке</param>
        public void RemoveTask(int index)
        {
            Tasks.RemoveAt(index);
        }
    }
}
