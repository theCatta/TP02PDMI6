//Diogo Santos Teixeira && Guilherme Ferreira Santos
using Microsoft.Maui.Platform;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using TarefasApp.Models;

namespace TarefasApp;

public partial class DetailTask : ContentPage
{
    private Models.Task selectedTask;
    public DetailTask(Models.Task task)
	{
		InitializeComponent();
		this.selectedTask = task;
		BindingContext = task;
	}

    private async void onRemove(object sender, EventArgs e)
    {
        bool awser = await DisplayAlert("My Task", "Do you want to remove your task?", "Yes", "No");

        if (awser)
        {
            MessagingCenter.Send(this, "RemoveTask", selectedTask);
            Navigation.PopAsync();
        }
    }

    private async void onEdit(object sender, EventArgs e)
    {
        var editPopupPage = new EditPopupPage(selectedTask);

        // Show the popup
        await Navigation.PushAsync(editPopupPage);
    }
}