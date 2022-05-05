using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    [Serializable]
    public class SaveGoal
    {
        public string Description;
        public List<SaveTask> Tasks;

        public SaveGoal(string desc, List<SaveTask> tasks)
        {
            Description = desc;
            Tasks = tasks;
        }
    }
}
