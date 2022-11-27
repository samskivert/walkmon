namespace walkmon {

using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class BattleTests {

  [Test]
  public void TestBattle () {
    var tino = AssetDatabase.LoadAssetAtPath<MonData>("Assets/Mons/Tino.asset");
    Assert.That(tino, Is.Not.Null);

    var stringy = AssetDatabase.LoadAssetAtPath<MonData>("Assets/Mons/Stringy.asset");
    Assert.That(stringy, Is.Not.Null);

    var state = new Battle.State {
      leftData = tino,
      left = new Mon.Info { hp = tino.hp },
      rightData = stringy,
      right = new Mon.Info { hp = stringy.hp }
    };

    var random = new System.Random();
    var actions = Battle.Fight(state, random);
    foreach (var action in actions) Debug.Log(action);
  }
}
}
