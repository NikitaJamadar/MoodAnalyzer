﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyzer
{
    public class CustomException:Exception
    {
        public ExceptionType type;

        public enum ExceptionType
        {
            Null_Type_Exception,
            Empty_Type_Exception,
            NO_SUCH_CLASS,
            NO_SUCH_Constructor,
            NO_SUCH_METHOD
        }
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
