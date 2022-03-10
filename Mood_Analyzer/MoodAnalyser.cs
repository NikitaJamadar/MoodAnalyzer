using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyzer
{
    public class MoodAnalyser
    {
        public string msg;
        public MoodAnalyser()
        {

        }
        public MoodAnalyser(string msg)
        {
            this.msg = msg;
        }

        public string AnalyseMood()
        {
            try
            {
                if (msg.ToLower().Equals(string.Empty))
                {
                    throw new CustomException(CustomException.ExceptionType.Empty_Type_Exception, "Message should not be empty");
                }
                if (msg.ToLower().Contains("sad".ToLower()))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.Null_Type_Exception, "Message should not be null");
            }
        }
    }
}
