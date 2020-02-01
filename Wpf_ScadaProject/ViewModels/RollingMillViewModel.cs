using Caliburn.Micro;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Wpf_ScadaProject.Models;

namespace Wpf_ScadaProject.ViewModels
{
    public class RollingMillViewModel : Screen
    {
		private int _testValue;
		private DispatcherTimer timer=null;
		private void timeStart()
		{
			timer = new DispatcherTimer();
			timer.Tick += new EventHandler(timerTick);
			timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
			timer.Start();
		}

        private void timerTick(object sender, EventArgs e)
        {
            {
                Plc plc = new Plc(CpuType.S71500, "192.168.0.202", 0, 1);
                if (plc.IsAvailable)
                {
                    plc.Open();
                    if (plc.IsConnected)
                    {
                        int count = 0;
                        for (int i = 112; i < 2380; i += 126)
                        {
                            count += 1;
                            var buffer = new RollingMillModelBckTM();
                            plc.ReadClass(buffer, 9000, i);
                        }
                    }
                    else
                        Console.WriteLine("Connection not alive");
                    plc.Close();
                }
                else
                    Console.WriteLine("PLC not available");

            }
        }


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
