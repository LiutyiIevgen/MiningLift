using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    Value = signal.SignalValue.ToString()
                }));
            }
            return parameterData;
        }

        public List<ParameterData> GetInputSignalsById(int id)
        {
            var parameterData = new List<ParameterData>();
            using (var repoUnit = new RepoUnit())
            {
                var block = repoUnit.BlockLog.FindFirstBy(blc => blc.Id == id);
                var byteList = new List<byte> { block.InputSignalsLogs.First().Vio0, block.InputSignalsLogs.First().Vio1, block.InputSignalsLogs.First().Vio2, block.InputSignalsLogs.First().Vio3 };
                foreach (var _byte in byteList)
                {
                    byte b = _byte;
                    for (int i = 0; i < 8; i++)
                    {
                        parameterData.Add(new ParameterData
                        {
                            Name = "",
                            Value = (b & 0x01) == 1 ? "Лог '1'": "Лог '0'"
                        });
                        b = (byte)(b >> 1);
                    }
                }
            }
            return parameterData;
        }

        public List<ParameterData> GetOutputSignalsById(int id)
        {
            var parameterData = new List<ParameterData>();
            using (var repoUnit = new RepoUnit())
            {
                var block = repoUnit.BlockLog.FindFirstBy(blc => blc.Id == id);
                var byteList = new List<byte> { block.OutputSignalsLogs.First().Vio7, block.OutputSignalsLogs.First().Vio8, block.OutputSignalsLogs.First().Vio9, 
                    block.OutputSignalsLogs.First().Vio11, block.OutputSignalsLogs.First().Vio12 };
                foreach (var _byte in byteList)
                {
                    byte b = _byte;
                    for (int i = 0; i < 8; i++)
                    {
                        parameterData.Add(new ParameterData
                        {
                            Name = "",
                            Value = (b & 0x01) == 1 ? "Лог '1'" : "Лог '0'"
                        });
                        b = (byte)(b >> 1);
                    }
                }
            }
            return parameterData;
        }

        public BlockLog GetBlockLogById(int id)
        {
            BlockLog block;
            using (var repoUnit = new RepoUnit())
            {
                block = repoUnit.BlockLog.FindFirstBy(blc => blc.Id == id);
            }
            return block;
        }
        public List<List<ParameterData>> GetAnalogSignals(DateTime from, DateTime till)
        {
            var parameterData = new List<List<ParameterData>>();
            using (var repoUnit = new RepoUnit())
            {
                var blocks = repoUnit.BlockLog.Load(blc => blc.Date > from && blc.Date < till);
                parameterData.AddRange(blocks.Select(block => block.AnalogSignalLogs.Select(b => new ParameterData { Name = b.SignalType.Type, Value = b.SignalValue.ToString() }).ToList()).ToList());
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

            var inputSignals = new InputSignalsLog
            {
                Vio0 = parameters.AuziDIByteList[0],
                Vio1 = parameters.AuziDIByteList[1],
                Vio2 = parameters.AuziDIByteList[2],
                Vio3 = parameters.AuziDIByteList[3]
            };
            var outputSignals = new OutputSignalsLog
            {
                Vio7 = parameters.AuziDOByteList[0],
                Vio8 = parameters.AuziDOByteList[1],
                Vio9 = parameters.AuziDOByteList[2],
                Vio11 = parameters.AuziDOByteList[3],
                Vio12 = parameters.AuziDOByteList[4]
            };
            var blockLog = new BlockLog
            {
                Date = DateTime.Now,
                AnalogSignalLogs = analogSignals,
                InputSignalsLogs = new Collection<InputSignalsLog>{inputSignals},
                OutputSignalsLogs = new Collection<OutputSignalsLog> { outputSignals }
            };
            using (var repoUnit = new RepoUnit())
            {
                repoUnit.BlockLog.Save(blockLog);
            }
            return true;
        }
    }
}
