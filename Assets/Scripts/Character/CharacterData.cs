using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int maxHP = 20;
    public int maxPA = 3;
    public int armor = 0;
    public float lifestealPercent = 0f;
    public float dodgePercent = 0f;
    public float critChance = 0f;
    public float critMultiplier = 1.5f;
    
}
