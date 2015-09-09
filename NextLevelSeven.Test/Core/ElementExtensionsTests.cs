﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextLevelSeven.Core;

namespace NextLevelSeven.Test.Core
{
    [TestClass]
    public class ElementExtensionsTests
    {
        [TestMethod]
        public void ElementExtensions_CanInsertElementAfter()
        {
            var message = new NativeMessage(ExampleMessages.Standard);
            var modifiedMessage = new NativeMessage(ExampleMessages.Standard);
            modifiedMessage.InsertAfter(2, message[2]);
            Assert.AreEqual(modifiedMessage[3], message[2], "Element insertion (after) failed: duplication didn't work.");
            Assert.AreEqual(modifiedMessage[4], message[3], "Element insertion (after) failed: shifted segments weren't in order.");
        }

        [TestMethod]
        public void ElementExtensions_CanInsertStringAfter()
        {
            const string testSegment = @"TST|0|";

            var message = new NativeMessage(ExampleMessages.Standard);
            var modifiedMessage = new NativeMessage(ExampleMessages.Standard);
            modifiedMessage[1].InsertAfter(testSegment);
            Assert.AreEqual(modifiedMessage[2], testSegment, "Text insertion (after) failed: expected string didn't appear in modified message.");
            Assert.AreEqual(modifiedMessage[3], message[2], "Text insertion (after) failed: shifted segments weren't in order.");
        }
    }
}
