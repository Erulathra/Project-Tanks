using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using s1nu5;

public class TimerTests
{
    
    [Test]
    public void TimerConstructor()
    {
        var timer = new Timer(10);
        Assert.True(Math.Abs(timer.TimeToEnd - 10) < 0.001);
        Assert.True(Math.Abs(timer.RemainingSeconds - 10) < 0.001);
        Assert.True(timer.IsTicking == false);
        Assert.True(timer.WasInvoked == false);
    }
    
    
}
