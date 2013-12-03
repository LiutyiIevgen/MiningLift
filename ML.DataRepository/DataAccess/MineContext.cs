using System.Data.Entity;
using ML.DataRepository.Models;

namespace ML.DataRepository.DataAccess
{
    public class MineContext : DbContext
    {
        public IDbSet<BlockLog> BlockLog { get; set; }
        public IDbSet<AnalogSignalLog> AnalogSignalLog { get; set; } 
        public IDbSet<AnalogSignal> AnalogSignals { get; set; } 
        public IDbSet<IOsignalsLog> IOsignalsLog { get; set; }
        
        public IDbSet<IOsignalType> IOsignalType { get; set; }

        public IDbSet<IOsignalState> IOsignalState { get; set; }
        public IDbSet<MainDigitSignalsLog> MainDigitSignalsLog { get; set; }

        public IDbSet<MainDigitSignalType> MainDigitSignalType { get; set; }

        public IDbSet<MainDigitSignalState> MainDigitSignalState { get; set; }
       // public IDbSet<FanState> FanState { get; set; }

        public IDbSet<SettingsLog> SettingsLog { get; set; }

        public IDbSet<RemoteLog> RemoteLog { get; set; }
        public IDbSet<RemoteState> RemoteState { get; set; }

        public MineContext()
            : base(GetConnectionName())
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected static string GetConnectionName() {
            return @"Data Source=.\SQLEXPRESS; Database=MineDataBase;Integrated Security=True;";
            //return @"Data Source=.\SQLExpress;Database=MineDb3;Trusted_Connection=True;";
            //return @"Data Source=(localdb)\Projects;Database=MineDb;Trusted_Connection=True;";

        }
    }
}
