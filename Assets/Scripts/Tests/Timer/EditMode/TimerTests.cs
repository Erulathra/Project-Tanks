using NUnit.Framework;

namespace Tests.Timer.EditMode
{
    public class TimerTests
    {
        private s1nu5.Timer testTimer;
    
        [SetUp]
        public void SetUp()
        {
            testTimer = new s1nu5.Timer(10);
        }
    
        [Test]
        public void TimerConstructor()
        {
            var timer = new s1nu5.Timer(10f);
            Assert.AreEqual(10f, timer.TimeToEnd, 0.001f);
            Assert.AreEqual(10f, timer.RemainingSeconds, 0.001f);
            Assert.IsFalse(timer.IsTicking);
        }

        [Test]
        public void TimerUpdate()
        {
            var deltaTime = testTimer.TimeToEnd - 5.5f;
            testTimer.Start();
            testTimer.Update(deltaTime);
            Assert.AreEqual(testTimer.TimeToEnd - deltaTime, testTimer.RemainingSeconds, 0.001f);
        }
    
        [Test]
        public void TimerUpdateTimerIsNotNegative()
        {
            var deltaTime = testTimer.TimeToEnd + 5.5f;
            testTimer.Start();
            testTimer.Update(deltaTime);
            Assert.AreEqual(0f, testTimer.RemainingSeconds, 0.001f);
        }

        [Test]
        public void TimerInvokeEvent()
        {
            var deltaTime = (testTimer.TimeToEnd / 2f) + 1f;
            int invokeCount = 0;
            void AddInvokeCount() => invokeCount++;
            testTimer.OnTimerEnd += AddInvokeCount;
            testTimer.Start();
        
            testTimer.Update(deltaTime);
            Assert.AreEqual(0, invokeCount);
            testTimer.Update(deltaTime);
            Assert.AreEqual(1, invokeCount);
            testTimer.Update(deltaTime);
            Assert.AreEqual(1, invokeCount);
        
        }
    
        [Test]
        public void TimerStart()
        {
            var deltaTime = (testTimer.TimeToEnd / 2f) + 1f;
            testTimer.Update(deltaTime);
            Assert.AreEqual(testTimer.TimeToEnd, testTimer.RemainingSeconds, 0.001f);
            testTimer.Start();
            testTimer.Update(deltaTime);
            Assert.True(testTimer.TimeToEnd > testTimer.RemainingSeconds);

        }
    
        [Test]
        public void TimerStop()
        {
            var deltaTime = (testTimer.TimeToEnd / 2f) + 1f;
            testTimer.Start();

            testTimer.Update(deltaTime);
            testTimer.Stop();
            Assert.AreEqual(testTimer.TimeToEnd, testTimer.RemainingSeconds, 0.001f);
            testTimer.Update(deltaTime);
            Assert.AreEqual(testTimer.TimeToEnd, testTimer.RemainingSeconds, 0.001f);
        }
    
        [Test]
        public void TimerPause()
        {
            var deltaTime = testTimer.TimeToEnd / 2f;
            testTimer.Start();

            testTimer.Update(deltaTime);
            testTimer.Pause();
            Assert.AreEqual(testTimer.TimeToEnd - deltaTime, testTimer.RemainingSeconds, 0.001f);
            testTimer.Update(deltaTime);
            Assert.AreEqual(testTimer.TimeToEnd - deltaTime, testTimer.RemainingSeconds, 0.001f);
        }
    }
}
