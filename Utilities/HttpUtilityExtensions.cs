﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyToolkit.Utilities
{
	public static class HttpUtilityExtensions
	{
		public static Dictionary<string, string> ParseQueryString(string queryString)
		{
			var dict = new Dictionary<string, string>();
			foreach (var s in queryString.Split('&'))
			{
				var index = s.IndexOf('=');
				if (index != -1 && index + 1 < s.Length)
				{
					var key = s.Substring(0, index);
					var value = Uri.UnescapeDataString(s.Substring(index + 1));
					dict.Add(key, value);
				}
			}
			return dict;
		}
	}
}