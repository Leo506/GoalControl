using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    [System.Serializable]
    public class Goal : INotifyPropertyChanged
    {
        public string Description { get; private set; }

        public ObservableCollection<GoalTask> Tasks { get; private set; }

        private float _progress;
        public string Progress
        {
            get
            {
                return $"{_progress * 100}%";
            }
        }

        public Goal(string description)
        {
            Description = description;
            Tasks = new ObservableCollection<GoalTask>();
            _progress = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// Добавляет задачу к цели
        /// </summary>
        /// <param name="text">Текст задачи</param>
        public void AddTask(string text)
        {
            var task = new GoalTask(text);
            task.PropertyChanged += RecountProgress;
            Tasks.Add(task);
        }

        private void RecountProgress(object? sender, PropertyChangedEventArgs e)
        {
            _progress = (float)Tasks.Where(x => x.IsDone).Count() / Tasks.Count();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
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
