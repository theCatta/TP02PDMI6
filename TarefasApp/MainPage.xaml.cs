using Microsoft.Maui.Controls.Xaml;
using System.Collections.ObjectModel;
using TarefasApp.Models;
namespace TarefasApp;

public partial class MainPage : ContentPage
{
    int cout = 0;
    ObservableCollection<Models.Task> tasks = new ObservableCollection<Models.Task>
    {
        new Models.Task(1, "Exemplo", "Descrição da tarefa exemplo", DateTime.Now, 1),
    };

    public MainPage()
	{
        InitializeComponent();

        MessagingCenter.Subscribe<DetailTask, Models.Task>(this, "RemoveTask", (sender, task) =>
        {
            // Remove the task from the list
            tasks.Remove(task);
        });

        MessagingCenter.Subscribe<DetailTask, Models.Task>(this, "EditTask", (sender, task) =>
        {
            tasks.Where(x => x.Id == task.Id).First().Title = task.Title;
            tasks.Where(x => x.Id == task.Id).First().Description = task.Description;
            tasks.Where(x => x.Id == task.Id).First().Created = task.Created;
            tasks.Where(x => x.Id == task.Id).First().Priority = task.Priority;
            
        });

        lstTasks.ItemsSource = tasks;
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
        if (e.SelectedItem != null)
        {
            var selectedItem = (Models.Task)e.SelectedItem;

            await Navigation.PushAsync(new DetailTask(selectedItem));

            ((ListView)sender).SelectedItem = null;
        }
    }
    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        // Abra a página de adição de tarefas e passe a lista de tarefas
        AddTaskPage addTaskPage = new AddTaskPage(tasks);
        await Navigation.PushAsync(addTaskPage);
    }

}

