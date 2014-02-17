using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using iYao.iYaoWebService;
using System.Collections.Generic;
using Newtonsoft.Json;
using iYaoInPutBarLibrary;
using System.Linq;

namespace iYao
{
	public class iYaoTableView:UITableView
	{
		public override void ReloadData ()
		{
			base.ReloadData ();
			Console.WriteLine (this.ContentSize.ToString ());
			if (this.ContentSize.Height > this.Frame.Height) {
				this.SetContentOffset (new PointF (0, this.ContentSize.Height - this.Frame.Height), false);
			}
		}
	}

	public  class MessageViewController : UIViewController
	{
		void KeyboardWillToggle (object sender, UIKeyboardEventArgs e)
		{
			var duration = e.AnimationDuration;
			var startFrame = e.FrameBegin;
			var endFrame = e.FrameEnd;
			int signCorrection = 1;

			if (startFrame.Y < 0 || startFrame.X < 0 || endFrame.Y < 0 || endFrame.X < 0)
				signCorrection = -1;

			var widthChange = (endFrame.X - startFrame.X) * signCorrection;
			var heightChange = (endFrame.Y - startFrame.Y) * signCorrection;
			//var sizeChange = heightChange; //UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait ? heightChange : widthChange;
			var sizeChange = InterfaceOrientation == UIInterfaceOrientation.Portrait ? heightChange : widthChange;
//			 sizeChange+=64;
			var newContainerFrame = View.Frame;
			newContainerFrame = new RectangleF (View.Frame.X, View.Frame.Y, View.Frame.Width, View.Frame.Height + sizeChange);
			var offsetY = Math.Max (0.0f, tableView.ContentSize.Height - tableView.Frame.Size.Height - sizeChange);
			var newTextViewContentOffset = new PointF (0, offsetY);
			UIView.Animate (duration, 0, UIViewAnimationOptions.BeginFromCurrentState, () => View.Frame = newContainerFrame, null);
//			newTextViewContentOffset = new PointF (newTextViewContentOffset.X, newTextViewContentOffset.Y + 64);
			Console.WriteLine ("newTextViewContentOffset" + newTextViewContentOffset.Y);
//			tableView.SetContentOffset (newTextViewContentOffset, true);
		}

		iYaoTableView tableView;

		void KeyboardWillShow (object sender, UIKeyboardEventArgs e)
		{
//			Console.WriteLine ("show");

			composeBarView.Frame = new RectangleF (composeBarView.Frame.X, UIScreen.MainScreen.Bounds.Height - 40 - e.FrameEnd.Height, composeBarView.Frame.Width, composeBarView.Frame.Height);
			tableView.Frame = new RectangleF (tableView.Frame.X, tableView.Frame.Y, tableView.Frame.Width, UIScreen.MainScreen.Bounds.Height - tableView.Frame.Y - e.FrameEnd.Height - 40);
			if (tableView.ContentSize.Height > tableView.Frame.Height)
				tableView.SetContentOffset (new PointF (0, tableView.ContentSize.Height - tableView.Frame.Height), false);
			//			tableView.SetContentOffset (new PointF (0, 0), true);
		}

		void KeyboardWillHide (object sender, UIKeyboardEventArgs e)
		{
//			Console.WriteLine ("hide");
			composeBarView.Frame = new RectangleF (composeBarView.Frame.X, UIScreen.MainScreen.Bounds.Height - 40, composeBarView.Frame.Width, composeBarView.Frame.Height);
			tableView.Frame = new RectangleF (0, 64, 320, UIScreen.MainScreen.Bounds.Height - 104);
			if (tableView.ContentSize.Height > tableView.Frame.Height)
				tableView.SetContentOffset (new PointF (0, tableView.ContentSize.Height - tableView.Frame.Height), false);
		}

		public MessageViewController ()
		{
			keyboarWillShowNot = UIKeyboard.Notifications.ObserveWillShow (KeyboardWillShow);
			keyboarWillHideNot = UIKeyboard.Notifications.ObserveWillHide (KeyboardWillHide);
		}

		NSObject keyboarWillShowNot;
		NSObject keyboarWillHideNot;
		public Users fromUser;
		public Users toUser;
		public Recruit recruit;
		InPutBar composeBarView;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public void ReLoadMessageData ()
		{
			var re = AppDelegate.db.QueryAsync<LocalMessage > ("SELECT  * FROM LocalMessage WHERE (toUserID=? and fromUserID=?) or (toUserID=? and fromUserID=?) order by SendTime desc limit 0,20  ", objarray).Result;
			re = re.OrderBy (x => x.SendTime).ToList ();
			InvokeOnMainThread (delegate {
				source = new MessageTableViewSource (re, this);
				tableView.Source = source;
				tableView.ReloadData ();
			});
		}

		string[] objarray;
		UIButton btnBack;

		void LoadBackButton ()
		{
			btnBack = new UIButton ();
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);
			btnBack.SetTitle ("返回", UIControlState.Normal);
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);
			//			btnBack.SetImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.Frame = new RectangleF (16, 8, 50, 27);
			btnBack.SetBackgroundImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.TitleEdgeInsets = new UIEdgeInsets (0, 5, 0, 0);
			navBar.AddSubview (btnBack);
		}

		UINavigationBar navBar;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			objarray	= new string[]{ toUser.idstr, fromUser.idstr, fromUser.idstr, toUser.idstr };
			navBar = new UINavigationBar (new  RectangleF (0, 20, 320, 44));
			navBar.Translucent = false;
			View.AddSubview (navBar);
			if (fromUser != null) {
				UINavigationItem titleItem = new UINavigationItem (fromUser.name);
				navBar.PushNavigationItem (titleItem, false);
//				navBar.TopItem=new UINavigationItem (fromUser.name);
			}
			if (AppDelegate.currentUser.gender == "m") {
				this.View.BackgroundColor = UIColor.FromRGB (49, 49, 49);
				navBar.BarTintColor = UIColor.FromRGB (49, 49, 49);
				navBar.BackgroundColor = UIColor.Clear;
			
			} else {
				this.View.BackgroundColor = UIColor.FromRGB (65, 27, 35);
				navBar.BarTintColor = UIColor.FromRGB (65, 27, 35);
				navBar.BackgroundColor = UIColor.Clear;
			}

			Common.MSGViewController = this;
			LoadBackButton ();

			btnBack.TouchUpInside += BackToPrevious;
			UITapGestureRecognizer tap = new UITapGestureRecognizer ();
			tap.AddTarget (() => {
				this.View.EndEditing (true);
			});
			this.View.AddGestureRecognizer (tap);
			composeBarView = new InPutBar ();

			// This will handle when the user taps the main button
			composeBarView.SendButton.TouchUpInside += (sender, e) => {


//				Console.WriteLine ("Main button pressed. Text:\n{0}", composeBar.Text);

				string msgID = Guid.NewGuid ().ToString ();

				LegendinBaseMessage lmsg = new LegendinBaseMessage ();


				lmsg.fromUserID = AppDelegate.currentUser.id.ToString ();

				lmsg.toUserID = toUser.idstr;
				lmsg.messageBody = composeBarView.TxtView.Text;
				lmsg.messageID = msgID;
				lmsg.messageType = MessageType.ToUser;

				lmsg.SendTime = DateTime.Now;
				string msgBody = JsonConvert.SerializeObject (lmsg);




//				Message message = new Message (Message.CommandHeader.SendMessage, 1, 1,msgBody);
				LocalMessage cellMessage = new LocalMessage ();
				cellMessage.fromUserID = lmsg.fromUserID;
				cellMessage.messageBody = composeBarView.TxtView.Text;
				cellMessage.messageType = MessageType.ToUser;
				cellMessage.SendTime = DateTime.Now;
				cellMessage.toUserID = toUser.idstr;
				cellMessage.MessageID = msgID;
				source.messageList.Add (cellMessage);
				//send to server
				string msg = msgBody + "\0";// "\0" 表示一个消息的结尾
				byte[] bMsg = System.Text.Encoding.UTF8.GetBytes (msg);//消息使用UTF-8编码
				Common.tcpPassiveEngine.SendMessageToServer (bMsg);
				AppDelegate.db.InsertAsync (cellMessage).ContinueWith (t2 => {
					if (t2.Exception != null) {
						Console.WriteLine (t2.Exception.InnerException.ToString ());
					}
				});
//				var 	source =tableView.Source as MessageTableViewSource;
				NSIndexPath index = NSIndexPath.FromRowSection (source.messageList.Count - 1, 0);
				tableView.InsertRows (new NSIndexPath[] { index }, UITableViewRowAnimation.None);
				var cellheight =	source.GetHeightForRow (tableView, index);
				if (tableView.ContentSize.Height > tableView.Frame.Height)
					tableView.SetContentOffset (new PointF (0, tableView.ContentSize.Height - tableView.Frame.Height + cellheight), false);
				composeBarView.TxtView.Text = string.Empty;
//				tableView.ReloadData ();
			
			};

			// This will handle when the user taps the Utility button in this case a CameraButton
			composeBarView.FunctionButton.TouchUpInside += (sender, e) => {
				Console.WriteLine ("FunctionButton pressed");
			};


			tableView = new iYaoTableView ();
			//加载本地消息数据
			var re = AppDelegate.db.QueryAsync<LocalMessage > ("SELECT * FROM LocalMessage WHERE (toUserID=? and fromUserID=?) or (toUserID=? and fromUserID=?) order by SendTime desc limit 0,20", objarray).Result;
//			SELECT * FROM LocalMessage WHERE (toUserID='3978016657' and fromUserID='2158569197') or (toUserID='2158569197' and fromUserID='3978016657')
//			var messageResult=	AppDelegate.db.Table<LocalMessage> ().Where (v=> (v.fromUserID==fromUser.idstr && v.toUserID==toUser.idstr )|| (v.fromUserID==toUser.idstr && v.toUserID==fromUser.idstr )  );
			re = re.OrderBy (x => x.SendTime).ToList ();

			//减去104的是因为状态栏、导航栏、和输入框
			tableView.Frame = new RectangleF (0, 64, 320, UIScreen.MainScreen.Bounds.Height - 104);
//			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			if (AppDelegate.currentUser.gender == "m") {
				tableView.BackgroundColor = UIColor.FromRGB (225, 235, 137);
			} else {
				tableView.BackgroundColor = UIColor.FromRGB (216, 109, 98);

			}
			List<LocalMessage> datas = new  List<LocalMessage> ();

//			messageResult.ToListAsync ().ContinueWith (t => {
//			
//				if(t.Result!=null)
//				{
//					datas=t.Result;
//				}
//			});
			datas.AddRange (re);

			if (recruit != null) {
				LocalMessage msg = new LocalMessage ();
				msg.fromUserID = AppDelegate.currentUser.idstr;
				msg.messageBody = "小帅哥" + AppDelegate.currentUser.name + "愿意帮你" + recruit.Target.RecruitTargetDisplayName;
				msg.messageType = MessageType.Apply;
				msg.toUserID = toUser.idstr;
				msg.SendTime = DateTime.Now;
				datas.Add (msg);
			}


			source = new MessageTableViewSource (datas, this);
			tableView.Source = source;
			View.AddSubview (tableView);
			View.AddSubview (composeBarView);




			// Perform any additional setup after loading the view, typically from a nib.
		}

		MessageTableViewSource source;

		void AddMoreDatas ()
		{
			for (int i = 0; i < 10000; i++) {
				LocalMessage cellMessage = new LocalMessage ();
				cellMessage.fromUserID = fromUser.idstr;
				cellMessage.messageBody = i.ToString ();
				cellMessage.messageType = MessageType.ToUser;
				cellMessage.SendTime = DateTime.Now;
				cellMessage.toUserID = toUser.idstr;
				cellMessage.MessageID = Guid.NewGuid ().ToString ();
				source.messageList.Add (cellMessage);
				AppDelegate.db.InsertAsync (cellMessage).ContinueWith (t2 => {
					if (t2.Exception != null) {
						Console.WriteLine (t2.Exception.InnerException.ToString ());
					}
				});
			}

		}

		void BackToPrevious (object sender, EventArgs e)
		{
//			AddMoreDatas ();
			this.DismissViewController (true, null);
		}
	}
}

