using System;
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
using System.Windows.Shapes;

namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для AddGoalWindow.xaml
    /// </summary>
    public partial class AddGoalWindow : Window
    {
        public event Action<string>? NewGoalEvent;

        public AddGoalWindow()
        {
            InitializeComponent();
        }


        private void AddGoalClick(object sender, RoutedEventArgs e)
        {
            NewGoalEvent?.Invoke(GoalInput.Text);
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
