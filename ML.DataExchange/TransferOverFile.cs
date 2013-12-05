using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using ML.DataExchange.Interfaces;
using Timer = System.Timers.Timer;

namespace ML.DataExchange
{
    public class TransferOverFile:IDataExchange
    {
        public bool StartExchange(string strPort)
        {                     
            _fileName = strPort;          
            _timer = new Timer(Interval);
            _timer.Elapsed += (sender, e) => TimerEvent();
            _timer.Enabled = true;
            _timer.Start();
            return true;
        }

        public bool StopExchange()
        {
            _timer.Stop();
            return true;
        }

        private void TimerEvent()
        {
            double[] param;
                int k;               
                 try
                 {
                     mymutex = Mutex.OpenExisting("NonPersisterMemoryMappedFilemutex");
                     myNonPersisterMemoryMappedFile = MemoryMappedFile.OpenExisting(_fileName); 
                     mymutex.WaitOne();                               
                     k = 0;
                     param = new double[30];
                     StreamReader sr = new StreamReader(myNonPersisterMemoryMappedFile.CreateViewStream());
                     while (sr.EndOfStream != true)
                     {
                         string s = sr.ReadLine();
                         double data;
                         if (double.TryParse(s,out data))
                             param[k] = data;
                         else
                             break;
                         k++;
                     }
                     sr.Close();
                     mymutex.ReleaseMutex();
                 }
                 catch (Exception ex)
                 {    
                     if(mymutex!=null)
                       mymutex.ReleaseMutex();
                     return;
                 }
            Parameters parameters = new Parameters(param);
            if (ReceiveEvent != null)
                ReceiveEvent(parameters);
            if ((parameters.f_ostanov == 1 && parameters.load_state == 1) && DrawLoad != null)
            {
                DrawLoad();
                _drawLoad = DrawLoad;
                DrawLoad = null;
            }
        }
        public event ReceiveHandler ReceiveEvent;
        public event Action DrawLoad;
        private event Action _drawLoad;
        private Timer _timer;
        private string _fileName;
        private const int Interval = 50;
        private Mutex mymutex;
        private MemoryMappedFile myNonPersisterMemoryMappedFile;

    }
}
