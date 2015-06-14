﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Titanium.Web.Proxy.Models;

namespace Grabacr07.KanColleWrapper
{
	public static class KanColleProxyExtensions
	{
		/// <summary>
		/// FiddlerCore でフックした <see cref="Session"/> オブジェクトの <see cref="Session.ResponseBody"/> データを
		/// <typeparamref name="TResult"/> 型にパースします。
		/// </summary>
		public static IObservable<SvData<TResult>> TryParse<TResult>( this IObservable<SessionData> source )
		{
			Func<SessionData, SvData<TResult>> converter = session =>
			{
				SvData<TResult> result;
				return SvData.TryParse(session, out result) ? result : null;
			};

			return source.Select(converter).Where(x => x != null && x.IsSuccess);
		}

		/// <summary>
		/// FiddlerCore でフックした <see cref="Session" /> オブジェクトの <see cref="Session.ResponseBody" /> データを
		/// <see cref="SvData" /> 型にパースします。
		/// </summary>
		public static IObservable<SvData> TryParse( this IObservable<SessionData> source )
		{
			Func<SessionData, SvData> converter = session =>
			{
				SvData result;
				return SvData.TryParse(session, out result) ? result : null;
			};

			return source.Select(converter).Where(x => x != null && x.IsSuccess);
		}
	}
}
