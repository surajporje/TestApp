using Microsoft.Maui.Controls;
using Serilog;
using System.Windows.Input;

namespace TestApp.View;

public partial class CreateControl : ContentPage
{

    public ICommand CreateCommand { get; private set; }

    public CreateControl()
	{
		InitializeComponent();


        CreateCommand = new Command<Type>((Type viewType) =>
        {
            Microsoft.Maui.Controls.View view = (Microsoft.Maui.Controls.View)Activator.CreateInstance(viewType);
            view.VerticalOptions = LayoutOptions.Center;
            stackLayout.Add(view);

            Log.Information($"Added {viewType.Name} Control to  {nameof(CreateControl)} Page");
        });

        BindingContext = this;
    }


   
}