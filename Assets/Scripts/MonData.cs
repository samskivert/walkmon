namespace walkmon {

using UnityEngine;

[CreateAssetMenu(menuName = "Walkmon/Mon", fileName = "Mon")]
public class MonData : ScriptableObject {

  public enum Stage { Egg, Hatchling, Juvenile, Adult }

  public Sprite image;
  public Stage stage;
  public Stage nextStage;

  public int hp;
  public int speed;
  public int attack;
  public int accuracy; // %
  public int critical; // %
  public int defenseMin;
  public int defenseMax;
  public int evasion;  // %
  public int regen;

  public override string ToString () => name;
}
}
