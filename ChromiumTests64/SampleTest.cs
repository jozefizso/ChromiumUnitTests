using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.OffScreen;
using NUnit.Framework;

namespace ChromiumTests64
{
    [TestFixture]
    public class SampleTest
    {
        [Test]
        public void Method1()
        {
            var timeout = TimeSpan.FromSeconds(5);
            var tempDir = Path.GetTempPath();
            var baseDir = TestContext.CurrentContext.TestDirectory;

            var settings = new CefSettings()
            {
                BrowserSubprocessPath = Path.Combine(baseDir, "CefSharp.BrowserSubprocess.exe"),
                WindowlessRenderingEnabled = true,
                LogFile = "chromium.log",
                LogSeverity = LogSeverity.Verbose
            };
            CefSharpSettings.ShutdownOnExit = true;

            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
            var browser = new ChromiumWebBrowser("https://tls-v1-2.badssl.com:1012/");
            SpinWait.SpinUntil(() => browser.IsBrowserInitialized, timeout);

            Assert.IsNotNull(browser);
            Assert.IsTrue(browser.IsBrowserInitialized);
        }
    }
}
