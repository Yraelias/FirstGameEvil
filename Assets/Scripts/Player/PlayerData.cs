using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public string CharacterName;
    public string Archetype;
    public int CurrentHP;
    public int MaxHP;
    public int Luck;
    public int Armor;
    public float LifestealPercent;
    public float DodgePercent;
    public float CritChance;
    public float CritMultiplier;
    public int MaxPA;
    public int CurrentPA;
    public int Exp;
    public int Current_Level;
    public int Next_Level;
    public int Cost_PV;
    public int Cost_Luck;
    public int Cost_LifeSteal;
    public int Point_For_Up;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
