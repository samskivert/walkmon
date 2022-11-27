namespace walkmon {

using System;

public static class Mon {

  public class Info {
    /// <summary>This Mon's current HP.</summary>
    public int hp;

    public void Damage (int amount) {
      hp = Math.Max(0, hp-amount);
    }
  }
}
}
