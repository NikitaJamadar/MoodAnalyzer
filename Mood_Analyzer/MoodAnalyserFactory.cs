﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Mood_Analyzer
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = "." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);

                }

                catch (Exception e)
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }

            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }
        public static object MoodAnalyserParameterisedConstructor(string className, string constrcutorName)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constrcutorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_Constructor, "Constructor not found");
                }
            }

            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyserObject = MoodAnalyserFactory.MoodAnalyserParameterisedConstructor("Mood_Analyzer.MoodAnalyser", "MoodAnalyser");
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }

            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_VALUE, "method not found");
            }
        }
        public static string Setfield(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyse = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                field.SetValue(moodAnalyse, message);
                return moodAnalyse.msg;
            }

            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}
