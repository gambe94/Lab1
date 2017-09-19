using hgl57h.Models;
using hgl57h.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace hgl57h
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        
        public static ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>()
        
    {
        new TodoItem()
        {
             Id = 1,
            Title = "Tejet venni",
            Description = "Ha van tojás, hozz tizet!",
            Priority = Priority.Normal,
            IsDone = true,
            Deadline = DateTimeOffset.Now + TimeSpan.FromDays(1)
        },
        new TodoItem()
        {
            Id = 2,
            Title = "Megírni a szakdolgozatot",
            Description = "Minimum 40 oldal, szépen kitöltve screenshotokkal",
            Priority = Priority.High,
            IsDone = false,
             Deadline = new DateTime(2017, 12, 08, 12, 00, 00, 00)
        }
    };

        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TodoDetailsPage), null);
        }

        private void Details_Click(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (TodoItem)e.ClickedItem;
            int index = clickedItem.Id;
            Frame.Navigate(typeof(TodoDetailsPage), index - 1);
        }
    }
}
