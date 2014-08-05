﻿using System.Linq;
using Dip;
using FluentAssertions;
using NUnit.Framework;

namespace DipTests
{
    public class IisLogFileTests
    {
        [Test]
        public void ReadLogEntires_ValidFile_ReturnsCorrectEntires()
        {
            var logFile = TestUtils.ExtractResourceToFile("DipTests.Resources.HTTPERR");
            var iisLog = new IisLog(logFile);

            iisLog.ReadLogEntries().Should().HaveCount(4);
            iisLog.ReadLogEntries().Where(l => l.Type == LogType.Error).Should().HaveCount(2);
        }
    }
}