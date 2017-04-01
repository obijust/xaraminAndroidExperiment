using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WeatherApp.Droid
{
	[Activity (Label = "WeatherApp.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            Button getWeatherButton = FindViewById<Button>(Resource.Id.GetWeatherButton);
            getWeatherButton.Click += buttonClick;
		}

        private async void buttonClick(object sender, EventArgs e)
        {
            EditText zipCodeEntry = FindViewById<EditText>(Resource.Id.ZipCodeEntry);

            if (String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Toast.MakeText(this, "One has to fill out the zipCode to get Weather", ToastLength.Long).Show();
            }

            else if(zipCodeEntry.Length()< 5){
                Toast.MakeText(this, "A Standard US Zip Code is 5 digits long", ToastLength.Long).Show();
            }

            else
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                FindViewById<TextView>(Resource.Id.locationText).Text = weather.Title;
                FindViewById<TextView>(Resource.Id.tempText).Text = weather.Temperature;
                FindViewById<TextView>(Resource.Id.windText).Text = weather.Wind;
                FindViewById<TextView>(Resource.Id.visibilityText).Text = weather.Visibility;
                FindViewById<TextView>(Resource.Id.humidityText).Text = weather.Humidity;
                FindViewById<TextView>(Resource.Id.sunriseText).Text = weather.Sunrise;
                FindViewById<TextView>(Resource.Id.sunsetText).Text = weather.Sunset;
            }

        }
    }
}


