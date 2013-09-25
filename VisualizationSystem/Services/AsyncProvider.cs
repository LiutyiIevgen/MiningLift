using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;


namespace VisualizationSystem.Services
{
    public delegate void TimerPointer(Timer timer);
    public static class AsyncProvider
    {
       // private static List <Timer> timers;
        public static void StartTimer(int milliSeconds, TimerPointer action)
        {
            var timer = new Timer(milliSeconds);
            //timers.Add(timer);
            timer.Elapsed += (sender, args) => action(timer);
            timer.Start();
            timer.Enabled = true;
        }
    }
}
