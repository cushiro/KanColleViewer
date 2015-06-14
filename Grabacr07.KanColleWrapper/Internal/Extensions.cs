﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy.Models;

namespace Grabacr07.KanColleWrapper.Internal
{
	internal static class Extensions
	{
		public static string GetResponseAsJson( this SessionData session ) {
			return session.ResponseString.Replace( "svdata=", "" );
		}

		public static void SafeDispose(this IDisposable resource)
		{
			if (resource != null) resource.Dispose();
		}


		/// <summary>
		/// <see cref="Int32" /> 型の配列に安全にアクセスします。
		/// </summary>
		public static int? Get(this int[] array, int index)
		{
			return array.Length > index ? (int?)array[index] : null;
		}

		public static string Join(this IEnumerable<string> values, string separator)
		{
			return string.Join(separator, values);
		}

		public static Task WhenAll(this IEnumerable<Task> tasks)
		{
			return Task.WhenAll(tasks);
		}

		public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
		{
			return Task.WhenAll(tasks);
		}
	}
}
