using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shiftly_Xamarin.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
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
	}
}