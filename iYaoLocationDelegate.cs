using System;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace iYao
{
	public class iYaoLocationDelegate:CLLocationManagerDelegate
	{
		public iYaoLocationDelegate ()
		{
		}

		public override void LocationsUpdated (CLLocationManager manager, CLLocation[] locations)
		{
			if (locations != null && locations.Length > 0) {
				var latLong = Math.Round (locations[0].Coordinate.Latitude, 4) + ","
					+ Math.Round (locations[0].Coordinate.Longitude, 4);
				Console.WriteLine (latLong);

				Common.Latitude = locations[0].Coordinate.Latitude;
				Common.Longitude = locations[0].Coordinate.Longitude;
				InvokeInBackground (() => {
					try
					{
					if (AppDelegate.currentUser != null) {
						AppDelegate.web.UpdateLatitudeAndLongitude (Common.Latitude, Common.Longitude, AppDelegate.currentUser.idstr);
					}
					}
					catch(Exception ex)
					{

					}
				});
				//上传用户经纬度
			
				Console.WriteLine (latLong);
				manager.StopUpdatingLocation ();
			}
		}

		[Obsolete ("Deprecated in iOS 6.0")]
		public override void UpdatedLocation (CLLocationManager manager, CLLocation newLocation, CLLocation oldLocation)
		{
//			Console.WriteLine (newLocation.);
			var latLong = Math.Round (newLocation.Coordinate.Latitude, 4) + ","
			              + Math.Round (newLocation.Coordinate.Longitude, 4);
			Console.WriteLine (latLong);

			Common.Latitude = newLocation.Coordinate.Latitude;
			Common.Longitude = newLocation.Coordinate.Longitude;

			//上传用户经纬度
			if (AppDelegate.currentUser != null) {
				AppDelegate.web.UpdateLatitudeAndLongitude (Common.Latitude, Common.Longitude, AppDelegate.currentUser.idstr);
			}
			Console.WriteLine (latLong);
			manager.StopUpdatingLocation ();

		}
	}
}

