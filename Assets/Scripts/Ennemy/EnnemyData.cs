using UnityEngine;

public class EnemyData
{
    public string name;
    public int maxHP;
    public int minDamage;
    public int maxDamage;
    public int Exp;

    public EnemyData(string name, int maxHP, int minDamage, int maxDamage, int exp)
    {
        this.name = name;
        this.maxHP = maxHP;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.Exp = exp;
    }
}
