namespace walkmon {

using UnityEngine;

[CreateAssetMenu(menuName = "Walkmon/Mon", fileName = "Mon")]
public class MonData : ScriptableObject {

  public enum Stage { Egg, Hatchling, Juvenile, Adult }

  public Sprite image;
  public Stage stage;
  public Stage nextStage;

  public int hp;
  public int attack;
  public int defense;
  public int evasion;
  public int accuracy;
  public int speed;
  public int critical;
  public int regeneration;

  public override string ToString () => name;
}
}
