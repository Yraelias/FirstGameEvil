using UnityEngine;

public static class GameData
{
    public static string Archetype;
    public static string ChosenTarget;

    public static EnemyBase CreateEnemy()
    {
        switch (ChosenTarget)
        {
            case "Paysan": return new Villager();
            case "Garde": return new Guard();
            case "SDF": return new Poorman();
            default: return new Villager(); // fallback
        }
    }
}
