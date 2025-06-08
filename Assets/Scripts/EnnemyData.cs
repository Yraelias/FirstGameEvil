using UnityEngine;

public class EnemyData
{
    public string name;
    public int maxHP;
    public int minDamage;
    public int maxDamage;

    public EnemyData(string name, int maxHP, int minDamage, int maxDamage)
    {
        this.name = name;
        this.maxHP = maxHP;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
    }
}
