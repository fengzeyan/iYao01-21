using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using iYao.iYaoWebService;
using Newtonsoft.Json;

namespace iYao
{
	public partial class RecruitDetailViewController : UIViewController
	{
		public RecruitDetailViewController () : base ("RecruitDetailViewController", null)
		{
		}

		public Recruit recruit;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		void LoadBackButton()
		{
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);

			//			btnBack.SetImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.Frame = new RectangleF (btnBack.Frame.Location,new SizeF (50,27));
			btnBack.SetBackgroundImage(UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.TitleEdgeInsets = new UIEdgeInsets (0, 5, 0, 0);
			btnBack.TouchUpInside+= delegate(object sender, EventArgs e) {
				this.DismissViewController(true,null);
			};
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			LoadBackButton ();
			btnApply.TouchUpInside += SendApply;
			// Perform any additional setup after loading the view, typically from a nib.
		}

		void SendApply (object sender, EventArgs e)
		{
			LegendinBaseMessage lmsg = new LegendinBaseMessage ();

			lmsg.SendTime = DateTime.Now;
			lmsg.fromUserID = AppDelegate.currentUser.id.ToString ();
			lmsg.messageID = Guid.NewGuid ().ToString ();
			lmsg.toUserID = recruit.PublishUser.idstr;
			lmsg.messageBody = "小帅哥" + AppDelegate.currentUser.name + "愿意帮你" + recruit.Target.RecruitTargetDisplayName;

			lmsg.RecruitID = recruit.rid.ToString ();

			lmsg.messageType = MessageType.Apply;

			string msgBody = JsonConvert.SerializeObject (lmsg);
			//send to server 
			string msg = msgBody + "\0";// "\0" 表示一个消息的结尾
			byte[] bMsg = System.Text.Encoding.UTF8.GetBytes (msg);//消息使用UTF-8编码
			Common.tcpPassiveEngine.SendMessageToServer (bMsg);

			MessageViewController vc = new MessageViewController ();
			vc.fromUser = Common.GetUserFromLocalUser (AppDelegate.currentUser);
			vc.toUser = recruit.PublishUser;
			vc.recruit = recruit;
			this.PresentViewController (vc, true, null);

		}
	}
}

