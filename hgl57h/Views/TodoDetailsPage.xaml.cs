using hgl57h.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace hgl57h.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TodoDetailsPage : Page
    {
        
        public TodoDetailsPage()
        {
            this.InitializeComponent();

            PriorityBox.ItemsSource = Enum.GetValues(typeof(Priority)).Cast<Priority>();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItem todoItem = new TodoItem();

            todoItem.Id = MainPage.Todos.Count() + 1;
            todoItem.IsDone = Done_CheckBox.IsChecked.GetValueOrDefault();
            todoItem.Priority = (Priority)PriorityBox.SelectedValue;
            todoItem.Description = Description.Text;
            todoItem.Title = Title.Text;
            todoItem.Deadline = DatePicker.Date;

            MainPage.Todos.Add(todoItem);

            Frame.Navigate(typeof(MainPage), null); 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Done_CheckBox.IsChecked = MainPage.Todos[(int)e.Parameter].IsDone;
                Title.Text = MainPage.Todos[(int)e.Parameter].Title;
                Description.Text = MainPage.Todos[(int)e.Parameter].Description;
                Title.Text = MainPage.Todos[(int)e.Parameter].Title;
                PriorityBox.SelectedItem = MainPage.Todos[(int)e.Parameter].Priority;
                DatePicker.Date = MainPage.Todos[(int)e.Parameter].Deadline;
            }
        }
    }

 
}
