using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyzer
{
    public class MoodAnalyser
    {
        public string AnalyseMood(string msg)
        {
            if (msg.ToLower().Contains("sad"))
                return "SAD";

            else
                return "HAPPY";
        }
    }
}
