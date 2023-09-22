//Diogo Santos Teixeira && Guilherme Ferreira Santos

using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace TarefasApp
{
    public partial class AddTaskPage : ContentPage
    {
        ObservableCollection<Models.Task> tasks;
        int count;

        public AddTaskPage(ObservableCollection<Models.Task> tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
            count = tasks.Count;
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            // Crie uma nova tarefa com os dados fornecidos
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            int priority = Convert.ToInt32(txtPriority.Text);

            Models.Task newTask = new Models.Task(++count, title, description, DateTime.Now, priority);

            // Adicione a nova tarefa à lista
            tasks.Add(newTask);

            // Volte para a página anterior
            Navigation.PopAsync();
        }
    }
}
