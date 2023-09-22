//Diogo Santos Teixeira && Guilherme Ferreira Santos
using Microsoft.Maui.Platform;

namespace TarefasApp;

public partial class EditPopupPage : ContentPage
{
	private Models.Task  selectedTask;
    public EditPopupPage(Models.Task task)
	{
		InitializeComponent();
		this.selectedTask = task;
		BindingContext = task;
    }

	private async void onEdit(object sender, EventArgs e)
	{
        MessagingCenter.Send(this, "EditTask", selectedTask);
        BindingContext = selectedTask;
        await Navigation.PopAsync();
    }

    private async void onCancel(object sender, EventArgs e)
	{
        await Navigation.PopAsync();

	}
}