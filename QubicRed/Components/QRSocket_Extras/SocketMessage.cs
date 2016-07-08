using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QubicRed.Components.QRSocket_Extras
{
	public class SocketMessage
	{
		public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

		public SocketMessage(object data)
		{
			Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
		}

		public SocketMessage(params object[][] data)
		{
			foreach (object[] obj in data)
				Add(obj[0].ToString(), obj[1]);
		}

		public object GetValue(string key)
		{
			if (!Data.ContainsKey(key))
				return null;
			return Data[key];
		}

		public bool Has(string key)
		{
			return Data.ContainsKey(key);
		}

		public void Add(string key, object value)
		{
			Data.Add(key, value);
		}
	}

	public static class ExtSocketMessage
	{
		public static string ToJSON(this SocketMessage e)
		{
			return JsonConvert.SerializeObject(e.Data);
		}
	}
}
