using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood_Analyzer;
namespace TestMood
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_I_am_in_sad_mood_shouldReturnSadMood()
        {
            string msg = "I am in sad mood";
            string expected = "SAD";

            MoodAnalyser mood = new MoodAnalyser(msg);

            string actual = mood.AnalyseMood();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Given_I_am_in_any_mood_ShouldReturnHaapyMood()
        {
            string msg = "I am in Any mood";
            string expected = "HAPPY";

            MoodAnalyser mood = new MoodAnalyser(msg);

            string actual = mood.AnalyseMood();

            Assert.AreEqual(expected, actual);
        }
       
        [TestMethod]


        public void GivenNULLMessage_Throws_CustomNullexception()
        {
            string expected = "Message should not be null";
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                string result = moodAnalyser.AnalyseMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void GivenEmptyMessage_throws_CustomEmptyException()
        {
            string expected = "Message should not be empty";
            MoodAnalyser modeAnalyzer = new MoodAnalyser(string.Empty);

            try
            {
                string actual = modeAnalyzer.AnalyseMood();

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
    }
}
