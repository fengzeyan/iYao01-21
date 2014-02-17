using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using System.Drawing;

namespace iYao
{
	public class LegendinMessageCell : UITableViewCell
	{
		public static NSString KeyLeft = new NSString ("BubbleElementLeft");
		public static NSString KeyRight = new NSString ("BubbleElementRight");
		//		public static UIImage bleft, bright, left, right;
		public static UIFont font = UIFont.SystemFontOfSize (14);
		public		UIView view;
		public string uID;
		//		UIView imageView;
		public	UIImageView userImageView;
		public	UILabel label;
		bool isLeft;

		static LegendinMessageCell ()
		{

//			bright = UIImage.FromFile ("Images/green.png");

//			bleft = UIImage.FromFile ("Images/grey.png");



// buggy, see https://bugzilla.xamarin.com/show_bug.cgi?id=6177

//left = bleft.CreateResizableImage (new UIEdgeInsets (10, 16, 18, 26));

//right = bright.CreateResizableImage (new UIEdgeInsets (11, 11, 17, 18));

//			left = bleft.StretchableImage (26, 16);

//			right = bright.StretchableImage (11, 11);
		}

		public LegendinMessageCell (bool isLeft, UIViewController vc) : base (UITableViewCellStyle.Default, isLeft ? KeyLeft : KeyRight)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			userImageView = new UIImageView ();
			var rect = new RectangleF (0, 5, 1, 1);

			//圆形ImageView

			userImageView.Layer.MasksToBounds = true;
			userImageView.Layer.CornerRadius = 22;




			this.isLeft = isLeft;

			if (isLeft) {
				userImageView.Frame = new RectangleF (10, 5, 44, 44);
				rect = new RectangleF (rect.X + 54, rect.Y, rect.Width, rect.Height);

			} else {
				userImageView.Frame = new RectangleF (266, 5, 44, 44);

				rect = new RectangleF (rect.X - 54, rect.Y, rect.Width, rect.Height);

			}

//			userImageView.BackgroundColor = UIColor.Black;

			view = new UIView (rect);

//			imageView = new UIImageView (isLeft ? left : right);

//			view.AddSubview (imageView);

			label = new UILabel (rect) {

				LineBreakMode = UILineBreakMode.WordWrap,

				Lines = 0,

				Font = font,

				BackgroundColor = UIColor.Clear

			};


			if (isLeft) {
			
				userImageView.UserInteractionEnabled = true;
				UITapGestureRecognizer tap = new UITapGestureRecognizer ();
				tap.AddTarget (() => {
					OtherUserInfoViewController ou = new OtherUserInfoViewController ();
					ou.userID = uID;
					vc.PresentViewController (ou, true, null);
					Console.WriteLine ("asdas");
				});
				userImageView.AddGestureRecognizer (tap);
			}
			lblName = new UILabel ();
			lblName.BackgroundColor = UIColor.Clear;

			if (isLeft) {
				lblName.Frame = new RectangleF (65, 5, 235, 20);
				lblName.TextAlignment = UITextAlignment.Left;
			} else {
				lblName.Frame = new RectangleF (0, 5, 255, 20);
				lblName.TextAlignment = UITextAlignment.Right;
			}

			view.AddSubview (label);
			ContentView.AddSubview (lblName);

			ContentView.Add (view);
			ContentView.Add (userImageView);

			if (AppDelegate.currentUser.gender == "m") {
				BackgroundColor = UIColor.FromRGB (225, 235, 137);
			} else {
				BackgroundColor = UIColor.FromRGB (216, 109, 98);
			}
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			var frame = ContentView.Frame;
			var size = GetSizeForText (this, label.Text) + LegendinMessagePadding;
//			imageView.Frame = new RectangleF (new PointF (isLeft ? 10 : frame.Width - size.Width - 10, frame.Y), size);
			view.SetNeedsDisplay ();
			//			frame = imageView.Frame;
			frame = new RectangleF (new PointF (isLeft ? 10 : frame.Width - size.Width - 10, frame.Y), size);
			label.Frame = new RectangleF (new PointF (frame.X + (isLeft ? 12 : 8), frame.Y + 26), size - LegendinMessagePadding);
		
		}

		public	UILabel lblName;
		static internal SizeF LegendinMessagePadding = new SizeF (22, 16);

		static internal SizeF GetSizeForText (UIView tv, string text)
		{

			return tv.StringSize (text, font, new SizeF (tv.Bounds.Width * .7f - 10 - 22, 99999));

		}

		public void Update (string text)
		{
			label.Text = text;
			SetNeedsLayout ();
		}
	}
}

