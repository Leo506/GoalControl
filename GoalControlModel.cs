using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class GoalControlModel
    {
        public ObservableCollection<Goal> goals { get; set; }

        public GoalControlModel()
        {
            var g = SaveLoad.Load();
            goals = new ObservableCollection<Goal>();
            if (g != null)
            {
                foreach (var item in g)
                {
                    var goal = new Goal(item.Description);
                    foreach (var task in item.Tasks)
                    {
                        GoalTask t = new GoalTask(task.Text);
                        t.IsDone = task.IsDone;
                        goal.AddTask(t);
                    }
                    goals.Add(goal);
                }
            }   
        }


        /// <summary>
        /// Добавляет новую глобальную цель
        /// </summary>
        /// <param name="description">Описание цели</param>
        public void AddGoal(string description)
        {
            goals.Add(new Goal(description));
        }

        public void Save()
        {
            List<SaveGoal> saveGoals = new List<SaveGoal>();
            foreach (var item in goals)
            {
                List<SaveTask> tasks = new List<SaveTask>();
                foreach (var task in item.Tasks)
                {
                    tasks.Add(new SaveTask(task.Text, task.IsDone));
                }

                saveGoals.Add(new SaveGoal(item.Description, tasks));
            }
            SaveLoad.Save(saveGoals);
            Trace.WriteLine("Saving...");
        }


        /// <summary>
        /// Удаляет цель
        /// </summary>
        /// <param name="description">Описание цели</param>
        public void RemoveGoal(string description)
        {
            foreach (var goal in goals)
            {
                if (goal.Description == description)
                {
                    goals.Remove(goal);
                    return;
                }
            }
        }


        /// <summary>
        /// Удаляет цель
        /// </summary>
        /// <param name="index">Индекс цели в списке</param>
        public void RemoveGoal(int index)
        {
            goals.RemoveAt(index);
        }

        internal void AddTask(string text, Goal goal)
        {
            goal.AddTask(text);
        }


        /// <summary>
        /// Добавляет новую задачу конкретной цели
        /// </summary>
        /// <param name="text">Текст задачи</param>
        /// <param name="goalIndex">Индекс цели</param>
        public void AddTask(string text, int goalIndex)
        {
            goals[goalIndex].AddTask(text);
        }


        /// <summary>
        /// Удаляет задачу из цели
        /// </summary>
        /// <param name="taskIndex">Индекс задачи</param>
        /// <param name="goalIndex">Индекс цели</param>
        public void RemoveTask(int taskIndex, int goalIndex)
        {
            goals[goalIndex].RemoveTask(taskIndex);
        }


       
    }
}
