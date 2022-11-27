namespace walkmon {

using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;

public class BattleTests {

  [Test]
  public void TestBattle () {
    var tino = new MonData {
      hp = 50,
      speed = 2,
      attack = 20,
      accuracy = 10,
      critical = 5,
      defenseMin = 8,
      defenseMax = 10,
      evasion = -10,
    };
    var stringy = new MonData {
      hp = 50,
      speed = 2,
      attack = 20,
      accuracy = 7,
      critical = 5,
      defenseMin = 7,
      defenseMax = 10,
      evasion = -13,
    };

    var state = new Battle.State {
      leftData = tino,
      left = new Mon.Info { hp = tino.hp },
      rightData = stringy,
      right = new Mon.Info { hp = stringy.hp }
    };

    var random = new System.Random();
    var actions = Battle.Fight(state, random);
    foreach (var action in actions) Console.WriteLine(action);
  }
}
}
