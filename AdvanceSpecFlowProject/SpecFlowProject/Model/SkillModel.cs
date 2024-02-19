using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Model
{
    public class SkillModel
    {
        public string title { get; set; }

        public string description { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string  tags { get; set; }
        public string serviceType { get; set; }
        public string locationType { get; set; }
        public List<string> day { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string skillTrade { get; set; }
        public string skillExchangeOrCredit { get; set; }
        public string active { get; set; }

    }
}
