using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    [Serializable]
    public class SaveTask
    {
        public string Text;
        public bool IsDone;

        public SaveTask(string text, bool done)
        {
            Text = text;
            IsDone = done;
        }
    }
}
