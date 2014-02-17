using System;
using System.Collections.Generic;
using WeiboSDKForWinRT;

namespace iYao
{
	public class MyHashTable : Object, IAppSetting
	{
		private Dictionary<string, object> mData = new Dictionary<string, object>();

		public MyHashTable ()
		{
		}


		#region IAppSetting implementation
		public bool ContainsKey (string key)
		{
			return mData.ContainsKey (key);
		}
		public object this [string index] {
			get {
				return mData[index];
			}
			set {
				//save value
				mData [index] = value;
			}
		}
		#endregion
	}
}

