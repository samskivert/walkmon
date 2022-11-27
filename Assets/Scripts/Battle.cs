namespace walkmon {

using Samskivert.React;

public static class Battle {

  public class State {
    public MonData leftData;
    public IMutable<Mon.Info> left;

    public MonData rightData;
    public IMutable<Mon.Info> right;
  }
}
}
