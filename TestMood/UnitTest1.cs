using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood_Analyzer;
namespace TestMood
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_I_am_in_sad_msg_inMethod_shouldReturn_SadMood()
        {
            string msg = "I am in sad mood";
            string expected = "SAD";

            MoodAnalyser mood = new MoodAnalyser();

            string actual = mood.AnalyseMood(msg);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Given_I_am_in_any_msg_inMethod_shouldReturn_HaapyMood()
        {
            string msg = "I am in Any mood";
            string expected = "HAPPY";

            MoodAnalyser mood = new MoodAnalyser();

            string actual = mood.AnalyseMood(msg);

            Assert.AreEqual(expected, actual);
        }
    }
}
