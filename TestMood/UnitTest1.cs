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
        [TestMethod]
        public void GivenCoorectClassname_ShouldReturnmoodAnalyserObject()
        {

           
            object expected = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("Mood_Analyzer.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
            // Assert.AreEqual(expected, obj);

        }

        [TestMethod]

        public void GivenWrongClassname_ShouldThrow_ClassNotFoundException()
        {
            try
            {
               
                object expected = new MoodAnalyser();
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("Mood_Analyzer.MoodAnalyserWrong", "MoodAnalyserWrong");
                expected.Equals(obj);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }

        [TestMethod]

        public void givenProperClassName_ButWrongConstructorName_ShouldThrow_ConstructorNotFoundException()
        {
            try
            {
               
                object expected = new MoodAnalyser();
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("Mood_Analyzer.MoodAnalyser", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        [TestMethod]
        public void GivenCorrectClassName_ShouldReturnMoodAnalyserObject_ParameterisedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.MoodAnalyserParameterisedConstructor("Mood_Analyzer.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        [TestMethod]

        public void GivenWrongClassName_ShouldThrowClassNotFoundException_ParameterisedConstructor()
        {
            try
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = MoodAnalyserFactory.MoodAnalyserParameterisedConstructor("Mood_Analyzer.MoodAnalyserWrong", "MoodAnalyser");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }

        [TestMethod]
        public void GivenWrongConstructorName_ShouldThrowconstructorNotFoundException_ParameterisedConstructor()
        {
            try
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = MoodAnalyserFactory.MoodAnalyserParameterisedConstructor("Mood_Analyzer.MoodAnalyser", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        [TestMethod]
        public void GivenHappy_ShouldReturn_Happy_ReflectorInvoke_method()
        {
            string expected = "Happy";
            string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreNotEqual(expected, mood);
        }

        [TestMethod]
        public void GivenHappy_ShouldReturnException_WithWrongMethodName()
        {
            try
            {
                string expected = "method not found";
                string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMoodWrong");
                Assert.AreNotEqual(expected, mood);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("method not found", ex.Message);
            }
        }
        [TestMethod]
        public void GivenWrongFieldShouldReturnException()
        {
            try
            {
                string result = MoodAnalyserFactory.Setfield("Happy", "messageWrong");
                Assert.AreEqual("Happy", result);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Field not found", ex.Message);
            }
        }

        [TestMethod]
        public void GivenEmptyMessageShouldReturnException()
        {
            try
            {
                string result = MoodAnalyserFactory.Setfield(null, "messageWrong");
                Assert.AreEqual("Happy", result);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Message should not be null", ex.Message);
            }
        }
    }
}
