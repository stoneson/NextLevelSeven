﻿using System;
using System.Linq;
using NextLevelSeven.Core;

namespace NextLevelSeven.MessageGeneration
{
    /// <summary>
    ///     An ACK message generator for HL7v2 messages, used as responses to requests. This is a static class.
    /// </summary>
    public static class AckMessageGenerator
    {
        /// <summary>
        ///     Generate an HL7v2 ACK message.
        /// </summary>
        /// <param name="message">Message to acknowledge.</param>
        /// <param name="code">Response code.</param>
        /// <param name="reason">MSA-3 text field string.</param>
        /// <param name="facility">Facility name for MSH-3.</param>
        /// <param name="application">Application name for MSH-4.</param>
        /// <returns>A complete ACK message.</returns>
        private static INativeMessage Generate(INativeMessage message, string code, string reason = null, string facility = null,
            string application = null)
        {
            var sourceMsh = message["MSH"].First();
            var result = new NativeMessage(sourceMsh.Value);
            var targetMsh = result[1];
            var msa = result[2];

            targetMsh[5].Value = sourceMsh[3].Value;
            targetMsh[6].Value = sourceMsh[4].Value;
            targetMsh[3].Value = application ?? sourceMsh[5].Value;
            targetMsh[4].Value = facility ?? sourceMsh[6].Value;
            targetMsh[7].As.DateTime = DateTime.Now;
            targetMsh[9][0][1].Value = "ACK";

            msa[0].Value = "MSA";
            msa[1].Value = code;
            msa[2].Value = sourceMsh[10].Value;
            if (reason != null)
            {
                msa[3].Value = reason;
            }

            return result;
        }

        /// <summary>
        ///     Generate an HL7v2 ACK indicating an error.
        /// </summary>
        /// <param name="message">Message to acknowledge.</param>
        /// <param name="reason">MSA-3 text field string.</param>
        /// <param name="facility">Facility name for MSH-3.</param>
        /// <param name="application">Application name for MSH-4.</param>
        /// <returns>Complete HL7 ACK message.</returns>
        public static INativeMessage GenerateError(INativeMessage message, string reason = null, string facility = null,
            string application = null)
        {
            return Generate(message, "AE", reason, facility, application);
        }

        /// <summary>
        ///     Generate an HL7v2 ACK indicating a rejection. Mainly used to tell the sender the data is invalid.
        /// </summary>
        /// <param name="message">Message to acknowledge.</param>
        /// <param name="reason">MSA-3 text field string.</param>
        /// <param name="facility">Facility name for MSH-3.</param>
        /// <param name="application">Application name for MSH-4.</param>
        /// <returns>Complete HL7 ACK message.</returns>
        public static INativeMessage GenerateReject(INativeMessage message, string reason = null, string facility = null,
            string application = null)
        {
            return Generate(message, "AR", reason, facility, application);
        }

        /// <summary>
        ///     Generate an HL7v2 ACK indicating a successful transfer.
        /// </summary>
        /// <param name="message">Message to acknowledge.</param>
        /// <param name="reason">MSA-3 text field string.</param>
        /// <param name="facility">Facility name for MSH-3.</param>
        /// <param name="application">Application name for MSH-4.</param>
        /// <returns>Complete HL7 ACK message.</returns>
        public static INativeMessage GenerateSuccess(INativeMessage message, string reason = null, string facility = null,
            string application = null)
        {
            return Generate(message, "AA", reason, facility, application);
        }
    }
}