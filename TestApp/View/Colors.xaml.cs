using Serilog;

namespace TestApp.View;

public partial class Colors : ContentPage
{
	public Colors()
	{
		InitializeComponent();
		Log.Information($"At color page {nameof(Colors)} ");
	}
}