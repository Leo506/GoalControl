using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class GoalControlModel
    {
        private List<Goal> goals;

        public GoalControlModel()
        {
            goals = new List<Goal>();
        }


        /// <summary>
        /// Добавляет новую глобальную цель
        /// </summary>
        /// <param name="description">Описание цели</param>
        public void AddGoal(string description)
        {
            goals.Add(new Goal(description));
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
