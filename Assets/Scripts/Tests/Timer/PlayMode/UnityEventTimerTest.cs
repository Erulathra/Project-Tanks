using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using s1nu5;


namespace Tests.Timer.PlayMode
{
    public class UnityEventTimerTest
    {
        private GameObject gameObjectWithTimer;
        private UnityEventTimer testTimer;
        
        [SetUp]
        public void SetUp()
        {
            gameObjectWithTimer = new GameObject();
            testTimer = gameObjectWithTimer.AddComponent<UnityEventTimer>();
            testTimer.timeToEnd = 2f;
        }
        
        [UnityTest]
        public IEnumerator TestInvokeEvent()
        {
            int invokeCount = 0;
            void AddInvoke() => invokeCount++;
            testTimer.onTimerEnd.AddListener(AddInvoke);
            yield return new WaitForSeconds(2.5f);
            Assert.AreEqual(1, invokeCount);
        }
    }
}
