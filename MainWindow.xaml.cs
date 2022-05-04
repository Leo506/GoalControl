﻿using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            model = new GoalControlModel();
            model.AddGoal("Goal1");
            model.AddGoal("Goal2");
            model.AddTask("task1", 0);
            GoalList.ItemsSource = model.goals;
        }

        private void AddGoalClick(object sender, RoutedEventArgs e)
        {
            var window = new AddGoalWindow();
            window.NewGoalEvent += model.AddGoal;
            var result = window.ShowDialog();
            if (result != null && result.Value)
                GoalList.ItemsSource = model.goals;

        }
    }
}
