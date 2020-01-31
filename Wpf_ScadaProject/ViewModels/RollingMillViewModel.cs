using Caliburn.Micro;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_ScadaProject.Models;

namespace Wpf_ScadaProject.ViewModels
{
    public class RollingMillViewModel : Screen
    {
		private int _testValue;
      
		public int TestValue
		{
			get 
			{

                return _testValue; 
			}
			set 
			{ 
				_testValue = value; 
			}
		}

		private BindableCollection<RollingMillModelBckTM> _backColorTM = new BindableCollection<RollingMillModelBckTM>();

		public BindableCollection<RollingMillModelBckTM> BackColorTM
		{
			get 
			{
				return _backColorTM;
			}
		}

	}
}
