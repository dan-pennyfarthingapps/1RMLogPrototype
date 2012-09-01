using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using ElementPack;

namespace RMLogPrototype
{
	public class Exercise
	{
		private string _name;
		private Dictionary<DateTime, double> _rmLog;

		public Exercise ()
		{
			this._rmLog = new Dictionary<DateTime, double>();
		}

		public string Name {
			get { return this._name; }
			set { this._name = value; }

		}

		public void LogRM (DateTime date, double weight) {
			this._rmLog.Add(date, weight);


		}

		public int LogCount ()
		{
			return this._rmLog.Count;

		}

		public Section getAllEntries() {
			var list = this._rmLog.Keys.ToList();
			list.Sort();

			Section sect = new Section("1RM entries") { };
				foreach (var key in list) {
					CounterElement entry = new CounterElement(key.ToString(), this._rmLog[key].ToString());
					sect.Add(entry);
				}



			

			return sect;

		}
	}
}

