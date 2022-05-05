using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GoalControlModel model;
        string tmpString;

        public MainWindow()
        {
            InitializeComponent();
            Closing += OnClose;
            model = new GoalControlModel();
            GoalList.ItemsSource = model.goals;
        }

        private void OnClose(object? sender, CancelEventArgs e)
        {
            model.Save();
        }

        private void AddGoalClick(object sender, RoutedEventArgs e)
        {
            var window = new AddGoalWindow();
            window.NewGoalEvent += model.AddGoal;
            window.ShowDialog();

        }

        private void AddNewTask(object sender, RoutedEventArgs e)
        {
            var window = new AddTaskWindow();
            window.NewTaskEvent += (str) => tmpString = str;
            var result = window.ShowDialog();
            if (result != null && result.Value)
            {
                var goal = ((GoalExtension)sender).Goal;
                model.AddTask(tmpString, goal);
            }
        }
    }
}
