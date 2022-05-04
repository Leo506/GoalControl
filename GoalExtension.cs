using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ToDoList
{
    public class GoalExtension : Button 
    {
        public static readonly DependencyProperty GoalProperty = DependencyProperty.RegisterAttached(
            "Goal",
            typeof(Goal),
            typeof(GoalExtension)
            );


        public Goal Goal
        {
            get { return (Goal)GetValue(GoalProperty); }
            set { SetValue(GoalProperty, value); }
        }

        /*public static Goal GetGoal(UIElement target)
        {
            return (Goal)target.GetValue(GoalProperty);
        }

        public static void SetValue(UIElement target, Goal value)
        {
            target.SetValue(GoalProperty, value);
        }*/
    }
}
