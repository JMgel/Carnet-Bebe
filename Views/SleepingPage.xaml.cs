using CarnetBebe.ViewModels;

namespace CarnetBebe.Views;

public partial class SleepingPage : ContentPage
{
	public SleepingPage(SleepingViewModel sleepingViewModel)
	{
		InitializeComponent();
		BindingContext = sleepingViewModel;
	}
}