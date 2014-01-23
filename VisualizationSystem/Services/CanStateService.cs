using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ML.DataExchange.Model;
using VisualizationSystem.Model;

namespace VisualizationSystem.Services
{
    class CanStateService
    {
        public void StartListener()
        {
            IoC.Resolve<DataListener>().SetReceiveFunction(ReceiveParameter);
            Thread listenerThread = new Thread(StateListener){IsBackground = true};
            listenerThread.Start();
        }


        private void ReceiveParameter(Parameters parameters)
        {
            _lastConnectionDate = DateTime.Now;
        }
        private void StateListener()
        {
            while (true)
            {
                if (DateTime.Now - _lastConnectionDate > new TimeSpan(0, 0, 0, 0, 200))
                    IsConnected = false;
                else
                    IsConnected = true;
                Thread.Sleep(100);
            }
        }

        public volatile bool IsConnected;
        private DateTime _lastConnectionDate;
    }
}
