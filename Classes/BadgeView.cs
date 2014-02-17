using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace iYao
{
	public class BadgeView:UILabel
	{
		public BadgeView (RectangleF re,string text)
		{
			this.Frame = re;
			this.Layer.MasksToBounds = true;
			this.Layer.CornerRadius = re.Width/2;
			this.TextColor = UIColor.White;
			this.Text = text;
			this.TextAlignment = UITextAlignment.Center;
			this.BackgroundColor = UIColor.Blue;
			this.Layer.BorderColor = UIColor.White.CGColor;
			this.Layer.BorderWidth = 3;  


		}
	}
}

