using UnityEngine;

public class Villager : EnemyBase
{
    public Villager()
    {
        Name = "Villageois";
        MaxHP = 10;
        MinDamage = 1;
        MaxDamage = 5;
    }
}