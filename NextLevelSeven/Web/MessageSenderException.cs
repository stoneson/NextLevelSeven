﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextLevelSeven.Diagnostics;

namespace NextLevelSeven.Web
{
    /// <summary>
    /// Represents an exception that would be thrown by a web HL7 message sender.
    /// </summary>
    public class MessageSenderException : Exception
    {
        /// <summary>
        /// Create a generic message sender exception.
        /// </summary>
        public MessageSenderException(ErrorCode code) : base(ErrorMessages.Get(code))
        {
        }
    }
}
