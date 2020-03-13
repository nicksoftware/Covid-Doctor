using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaDoctor.Models.SafetyTips
{
    public class SafetyTip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public List<SafetyStep> SafetySteps { get; set; }
    }
}
