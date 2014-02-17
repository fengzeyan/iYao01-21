using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using WeiboSDKForWinRT;
using RestSharp;
using Newtonsoft .Json;
using Newtonsoft .Json.Converters;
using System.Linq;
using MonoTouch.CoreLocation;
using System.Threading.Tasks;

namespace iYao
{
	public class CmdUserInfo: ICustomCmdBase
	{
		public string Uid{ get; set; }

		public CmdUserInfo ()
		{
		
		}

		public		void ConvertToRequestParam (RestRequest request)
		{
			request.Resource = "/users/show.json";
			request.Method = Method.GET;
			if (Uid.Length > 0) {
				request.AddParameter ("uid", Uid);
			}

		}
	}
	public delegate void EventNotifyDelegate (Object sender, Object obj);
	public partial class LoginViewController : UIViewController
	{
		private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext ();
		private ClientOAuth oauthClient;

		public LoginViewController () : base ("LoginViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		private void weiboVisitFinish (Object sender, object obj)
		{
			string url = (string)obj;
			string code = SdkUility.GetQueryParameter (url, "code");
			oauthClient.Authorize (code);

			//get at user list
			var engine = new SdkNetEngine ();
			ISdkCmdBase cmdbase = null;
			cmdbase = new CmdAtUsers () {
				Keyword = "3"
			};
			var result = engine.RequestCmd (SdkRequestType.AT_USERS, cmdbase);

			ISdkCmdBase cmdUserInfo = null;
//			cmdUserInfo = new  cmd
			cmdUserInfo = new CmdUserInfo (){ Uid = responuserID };
			var userInfoResult = engine.RequestCmd (SdkRequestType.OTHER_API, cmdUserInfo);
			if (result.errCode == SdkErrCode.SUCCESS) {
				Console.WriteLine ("Get At userList Success");
				System.Console.WriteLine (result.content);
			} else {
				System.Console.WriteLine ("the api didn't work correctly.");
			}
			if (userInfoResult.errCode == SdkErrCode.SUCCESS) {
				Console.WriteLine ("Get userInfo Success");
				System.Console.WriteLine (userInfoResult.content);
				LocalUser u = JsonConvert.DeserializeObject<LocalUser> (userInfoResult.content);
				AppDelegate.currentUser = u;
				InvokeOnMainThread (delegate {
					UIAlertView alert = new UIAlertView ();
					if (u != null) {
						try {
							Console.WriteLine (JsonConvert.SerializeObject (Common.GetUserFromLocalUser (u)));
							AppDelegate.web.UserReg (Common.GetUserFromLocalUser (u));
						} catch (Exception ex) {
							Console.WriteLine ("User Reg Error" + ex.Message
							);
						}
						alert.Message = u.name;
						if (CreateUser (u)) {
							alert.AddButton ("add success");
//							if (u.gender == "m") {
////								MainPageForMale malePage = new  MainPageForMale ();
//								SplashScreenViewController malePage=new SplashScreenViewController ();
//								this.PresentViewController (malePage, true, null);
//							} else {
//								SplashScreenViewController malePage=new SplashScreenViewController ();
////								MainPageForFemale femalePage = new  MainPageForFemale ();
////								AppDelegate.mainPageForFemale = femalePage;
//								this.PresentViewController (malePage, true, null);
//							}
							MainPageViewController mainPage = new  MainPageViewController ();
							AppDelegate.MainPage = mainPage;
							this.PresentViewController (mainPage, true, null);

						}
					} else {
						alert.Message = userInfoResult.content;
					}	
					alert.AddButton ("OK");
					alert.Show ();
				});
			} else {
				System.Console.WriteLine ("the api didn't work correctly.");
			}
		}

		private bool CreateUser (LocalUser  user)
		{
			try {
				if (user == null)
					return false;

//			AppDelegate.AddActivity();

//			var list = new List { Name = name };

//				if(AppDelegate.db.QueryAsyncUser))

				AppDelegate.db.QueryAsync<LocalUser > ("SELECT * FROM LocalUser WHERE (id=?)", user.id)
					.ContinueWith (t => {
					if (t.Exception != null) {

					}
					if (t.Result.Count > 0) {
						AppDelegate.db.UpdateAsync (user).ContinueWith (t1 => {
							if (t.Exception != null) {
								Console.WriteLine ("Fail");

							}
							if (t1.Result > 0) {
								Console.WriteLine ("OK");
							} else {
								Console.WriteLine ("Fail");
							}

						});
					} else {
						AppDelegate.db.InsertAsync (user).ContinueWith (t2 => {

						});
					}

				}, uiScheduler);


			
			} catch (Exception ex) {
				return false;
			}
			return true;
		}



		string responuserID = "";
		UIImageView imgView;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Console.WriteLine (CLLocationManager.Status.ToString ());
			this.View.BackgroundColor = UIColor.FromRGB (38,19,16);
		
			weiboView.Hidden = true;

			UIButton btn = UIButton.FromType (UIButtonType.Custom);
			btn.Frame = new RectangleF (0, 410, 320, 40);
			btn.BackgroundColor = UIColor.FromRGB (232,235,236);
			btn.SetTitle ("使用微博登录", UIControlState.Normal);
			btn.SetTitleColor (UIColor.FromRGB (245, 147, 49), UIControlState.Normal);
			btn.TouchUpInside += ShowWebView;

			imgView	 = new UIImageView ();
			imgView.Frame = new RectangleF (80,160,150,150);
			UIImage img = UIImage.FromFile ("Images/logo@2x.png");
			imgView.Image = img;
			img.Dispose ();
			this.View.AddSubview (imgView);
			this.View.AddSubview (btn);



			MyHashTable myAppSettings = new MyHashTable ();
			ApplicationData.Current.LocalSettings.Values = myAppSettings;

			SdkData.AppKey = "1854220111";
			SdkData.AppSecret = "be3772d68ac3a29ec3ef52d855fcd92a";
			SdkData.RedirectUri = "https://api.weibo.com/oauth2/default.html";
			MyWeiboViewDelegate myWeibo = new MyWeiboViewDelegate ();
			myWeibo.NotifyDelegate = new EventNotifyDelegate (this.weiboVisitFinish);
			weiboView.Delegate = myWeibo;

			// Perform any additional setup after loading the view, typically from a nib.
			oauthClient = new ClientOAuth ();
			// 判断是否已经授权或者授权是否过期.
			if (oauthClient.IsAuthorized == false) {
				oauthClient.LoginCallback += (isSucces, err, response) => {
					if (isSucces) {
						weiboView.RemoveFromSuperview ();
						weiboView.Dispose ();
						// TODO: deal the OAuth result.
						System.Console.WriteLine ("Congratulations, Authorized successfully!");
						System.Console.WriteLine (string.Format ("AccesssToken:{0}, ExpriesIn:{1}, Uid:{2}",
							response.AccessToken, response.ExpriesIn, response.Uid));
						responuserID = response.Uid;

					} else {
						// TODO: handle the err.
						System.Console.WriteLine (err.errMessage);
					}
				};

				string url = oauthClient.GetAuthorizeUrl ();
				Console.WriteLine (url);
				NSUrlRequest request = NSUrlRequest.FromUrl (NSUrl.FromString (url));
				weiboView.LoadRequest (request);
//				oauthClient.BeginOAuth();
			} else {

			}



		}

		void UpdatedLocationEvent (object sender, CLLocationUpdatedEventArgs e)
		{
			
		}

		void ShowWebView (object sender, EventArgs e)
		{
			UIButton btn = sender as UIButton;
			if (btn != null) {
				btn.RemoveFromSuperview ();
			}
			if (imgView != null) {
				imgView.RemoveFromSuperview ();
			}
			weiboView.Hidden = false;
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}

	public class MyWeiboViewDelegate : UIWebViewDelegate
	{
		public EventNotifyDelegate NotifyDelegate {
			get;
			set;
		}

		public override void LoadFailed (UIWebView webView, NSError error)
		{
			webView.Reload ();
			System.Console.WriteLine ("webView LoadFailed");
		}

		public override void LoadingFinished (UIWebView webView)
		{
			System.Console.WriteLine ("webView LoadingFinished");
		}

		public override void LoadStarted (UIWebView webView)
		{
			System.Console.WriteLine ("webView LoadStarted");
		}

		public override bool ShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			System.Console.WriteLine ("webView ShouldStartLoad");
			string url = request.Url.ToString ();
			if (url.StartsWith (SdkData.RedirectUri)) {
				System.Console.WriteLine (url);
				if (NotifyDelegate != null) {
					NotifyDelegate (this, url);
				}
			}
			return true;
		}
	}
}

