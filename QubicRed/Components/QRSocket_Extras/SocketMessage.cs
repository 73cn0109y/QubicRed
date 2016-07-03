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
			/*string d = data.ToString();
			string[] split = d.Split('\n');

			foreach (string s in split)
			{
				string val = s.Trim();

				if (string.IsNullOrWhiteSpace(val))
					continue;
				if (val == "}" || val == "{" || val == "]" || val == "[")
					continue;
				if (val.EndsWith(","))
					val = val.Substring(0, val.Length - 1);

				string name = val.Substring(1, val.IndexOf(':') - 2);
				string value = val.Substring(val.IndexOf(':') + 1, val.Length - val.IndexOf(':') - 1).Trim();

				if (name.StartsWith("\"") || name.StartsWith("'"))
					name = name.Substring(1, name.Length - 2);
				if (value.StartsWith("\"") || value.StartsWith("'"))
					value = value.Substring(1, value.Length - 2);

				value = value.Replace("\\\"", "\"");
				value = value.Replace("\\'", "'");

				if (!Data.ContainsKey(name))
					Data.Add(name, value);
				else
					Data[name] = value;
			}*/
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
