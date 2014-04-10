using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataRepository.Models;
using ML.DataRepository.Models.GenericRepository;


namespace ML.DataExchange.Services
{
    public class DataBaseService
    {
        public DataBaseService()
        {
        }

        public void FillGeneralLog(string line)
        {
            var generalLog = new GeneralLog
            {
                Date = DateTime.Now,
                LogLine = line
            };
            using (var repoUnit = new RepoUnit())
            {
                repoUnit.GeneralLog.Save(generalLog);
            }
        }
    }
}
