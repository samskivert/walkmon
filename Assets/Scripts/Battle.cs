namespace walkmon {

using System;
using System.Collections.Generic;

public static class Battle {

  public class State {
    public MonData leftData;
    public Mon.Info left;

    public MonData rightData;
    public Mon.Info right;

    // 0 = left, 1 = right
    public MonData Data (int index) => index == 0 ? leftData : rightData;
    public Mon.Info Info (int index) => index == 0 ? left : right;
  }

  public enum ActionType { Miss = 0, Hit, Crit }

  public struct Action {
    public int actorIndex;
    public int targetIndex;
    public ActionType action;
    public int amount;
  }

  private static int[] LeftRight = new [] { 0, 1 };
  private static int[] RightLeft = new [] { 1, 0 };

  public static List<Action> Fight (State state, Random random) {
    var actions = new List<Action>();

    // first determine the attack order
    var order = state.leftData.speed > state.rightData.speed ? LeftRight :
      state.leftData.speed < state.rightData.speed ? RightLeft :
      random.Next(100) < 50 ? LeftRight : RightLeft;

    void Attack (int actorIndex, int targetIndex) {
      var adata = state.Data(actorIndex);
      var tdata = state.Data(targetIndex);
      var hitChance = 50 + adata.accuracy + tdata.evasion;
      // start with a miss, and fill in a hit if they hit
      var action = new Action { actorIndex = actorIndex, targetIndex = targetIndex };
      if (random.Next(100) < hitChance) {
        var blocked = random.Next(tdata.defenseMax-tdata.defenseMin+1) + tdata.defenseMin;
        action.action = ActionType.Hit;
        action.amount = adata.attack - blocked;
        // check for a critical hit (2x damage)
        if (random.Next(100) < adata.critical) {
          action.amount *= 2;
          action.action = ActionType.Crit;
        }
        state.Info(targetIndex).Damage(action.amount);
      }
      actions.Add(action);
    }

    // now repeatedly take turns until someone is KOed
    var pos = 0;
    while (state.left.hp > 0 && state.right.hp > 0) {
      var aidx = order[pos % order.Length];
      Attack(aidx, 1-aidx);
      pos = pos + 1;
    }

    return actions;
  }
}
}
