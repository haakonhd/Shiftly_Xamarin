using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Shiftly_Xamarin.Models;
using Shiftly_Xamarin.Views;
using Shiftly_Xamarin.ViewModels;

namespace Shiftly_Xamarin.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;

		public ItemsPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);

			BindingContext = viewModel = new ItemsViewModel();

			gridWrapper.SizeChanged += (sender, e) => RefreshGrid();
		}


		void RefreshGrid()
		{

			if (gridWrapper.Height >= gridWrapper.Width)
			{
				gridLayout.WidthRequest = gridWrapper.Width - 40;
				gridLayout.HeightRequest = gridWrapper.Width -40;
			}
			else
			{
				gridLayout.HeightRequest = gridWrapper.Height - 40;
				gridLayout.WidthRequest = gridWrapper.Height - 40;
			}
		}
		
		void ToggledMasterDetails(object sender, EventArgs e)
		{
			MessagingCenter.Send(EventArgs.Empty, "OpenMenu");
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			// Note: Only on UPW and WPF because of a bug.
			if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
			{
				NavigationPage.SetHasNavigationBar(this, true);
				NavigationPage.SetHasNavigationBar(this, false);
				MasterDetailPage mainPage = App.Current.MainPage as MasterDetailPage;
				if (mainPage != null)
				{
					mainPage.MasterBehavior = MasterBehavior.Default;
					mainPage.MasterBehavior = MasterBehavior.Popover;
					mainPage.IsPresented = false;
				}
			}
		}

		//async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		//{
		//	var item = args.SelectedItem as Item;
		//	if (item == null)
		//		return;

		//	await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

		//	// Manually deselect item.
		//	ItemsListView.SelectedItem = null;
		//}

		async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
		}

	}		
}