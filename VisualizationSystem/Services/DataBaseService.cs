using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataExchange.Model;
using ML.DataRepository.Models;
using ML.DataRepository.Models.GenericRepository;
using Ninject.Parameters;
using VisualizationSystem.Model.DataBase;

namespace VisualizationSystem.Services
{
    public class DataBaseService
    {
        public List<int> GetBlocksIds(DateTime from, DateTime till)
        {
            var ids = new List<int>();
            using (var repoUnit = new RepoUnit())
            {
                ids.AddRange(repoUnit.BlockLog.Load(blc => blc.Date > from && blc.Date < till).Select(r => r.Id));
            }
            return ids;
        }
        public List<ParameterData> GetAnalogSignalsById(int id)
        {
            var parameterData = new List<ParameterData>();
            using (var repoUnit = new RepoUnit())
            {
                var block = repoUnit.BlockLog.FindFirstBy(blc => blc.Id == id);
                parameterData.AddRange(block.AnalogSignalLogs.Select(signal => new ParameterData
                {
                    Name = signal.SignalType.Type,
                    Value = signal.SignalValue
                }));
            }
            return parameterData;
        }
        public List<List<ParameterData>> GetAnalogSignals(DateTime from, DateTime till)
        {
            var parameterData = new List<List<ParameterData>>();
            using (var repoUnit = new RepoUnit())
            {
                var blocks = repoUnit.BlockLog.Load(blc => blc.Date > from && blc.Date < till);
                parameterData.AddRange(blocks.Select(block => block.AnalogSignalLogs.Select(b => new ParameterData { Name = b.SignalType.Type, Value = b.SignalValue }).ToList()).ToList());
            }
            return parameterData;
        }

        public bool FillDataBase(Parameters parameters)
        {
            var analogSignals = new List<AnalogSignalLog>();
            analogSignals.Add(new AnalogSignalLog{SignalTypeId = 1, SignalValue = parameters.s});
            analogSignals.Add(new AnalogSignalLog { SignalTypeId = 2, SignalValue = parameters.s_two });
            analogSignals.Add(new AnalogSignalLog { SignalTypeId = 3, SignalValue = parameters.v });
            analogSignals.Add(new AnalogSignalLog { SignalTypeId = 4, SignalValue = parameters.a });
            var blockLog = new BlockLog
            {
                Date = DateTime.Now,
                AnalogSignalLogs = analogSignals
            };
            using (var repoUnit = new RepoUnit())
            {
                repoUnit.BlockLog.Save(blockLog);
            }
            return true;
        }
    }
}
