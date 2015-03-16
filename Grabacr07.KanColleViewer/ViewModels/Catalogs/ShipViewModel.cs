﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Livet;

namespace Grabacr07.KanColleViewer.ViewModels.Catalogs
{
	public class ShipViewModel : ViewModel
	{
		public int Index { get; private set; }
		public Ship Ship { get; private set; }
		public List<SlotItemViewModel> SlotItems { get; private set; }

		public ShipViewModel(int index, Ship ship)
		{
			this.Index = index;
			this.Ship = ship;
			this.SlotItems = ship.EquippedSlots.Select(i => new SlotItemViewModel { SlotItem = i.Item.Info, Level = i.Item.Level }).ToList();
		}
	}
}
