using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI LuckText;
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI lifeStealText;
    public TextMeshProUGUI PvExp_Cost;
    public TextMeshProUGUI LuckExp_Cost;
    public TextMeshProUGUI LifeStealExp_Cost;
    public TextMeshProUGUI Points_Txt;
    public UnityEngine.UI.Button BtnHpUp;
    public UnityEngine.UI.Button BtnHpDown;
    public UnityEngine.UI.Button BtnLuckUp;
    public UnityEngine.UI.Button BtnLuckDown;
    public UnityEngine.UI.Button BtnLifeStealUp;
    public UnityEngine.UI.Button BtnLifeStealDown;
    private float Luck_Temp;
    private int Hp_Temp;
    private float LifeSteal_Temp;
    private float PvExp_Cost_Temp;
    private float LuckExp_Cost_Temp;
    private float LifeStealExp_Cost_Temp;
    void Start()
    {
        BtnHpDown.enabled = false;
        BtnLuckDown.enabled = false;
        BtnLifeStealDown.enabled = false;
        BtnHpUp.enabled = false;
        BtnLuckUp.enabled = false;
        BtnLifeStealUp.enabled = false;
        Luck_Temp = PlayerData.Instance.CritChance;
        Hp_Temp = PlayerData.Instance.MaxHP;
        LifeSteal_Temp = PlayerData.Instance.LifestealPercent;
        PvExp_Cost_Temp = PlayerData.Instance.Cost_PV;
        LuckExp_Cost_Temp = PlayerData.Instance.Cost_Luck;
        LifeStealExp_Cost_Temp = PlayerData.Instance.Cost_LifeSteal;
        PvExp_Cost.text = PlayerData.Instance.Cost_PV.ToString();
        LuckExp_Cost.text = PlayerData.Instance.Cost_Luck.ToString();
        LifeStealExp_Cost.text = PlayerData.Instance.Cost_LifeSteal.ToString();
        LevelText.text = PlayerData.Instance.Current_Level.ToString();
        HpText.text =  Hp_Temp.ToString() ;
        LuckText.text = Luck_Temp.ToString();
        lifeStealText.text = LifeSteal_Temp.ToString();
        Checkpoints();
    }
    void Checkpoints ()
    {
        if (PlayerData.Instance.Point_For_Up < PvExp_Cost_Temp) { BtnHpUp.enabled = false; } else BtnHpUp.enabled = true;
        if (PlayerData.Instance.Point_For_Up < LuckExp_Cost_Temp) { BtnLuckUp.enabled = false; } else BtnLuckUp.enabled = true;
        if (PlayerData.Instance.Point_For_Up < LifeStealExp_Cost_Temp) { BtnLifeStealUp.enabled = false; } else BtnLifeStealUp.enabled = true;
        Points_Txt.text = PlayerData.Instance.Point_For_Up.ToString();
    }
    public void AddHp()
    {
        Hp_Temp += 1;
        PlayerData.Instance.Point_For_Up = PlayerData.Instance.Point_For_Up - (int)PvExp_Cost_Temp;
        PvExp_Cost_Temp = PvExp_Cost_Temp * 2;
        PvExp_Cost.text = PvExp_Cost_Temp.ToString();        
        Checkpoints();
    }
    public void RemoveHp()
    {
        Hp_Temp -= 1;
        PlayerData.Instance.Point_For_Up = PlayerData.Instance.Point_For_Up + (int)PvExp_Cost_Temp;
        PvExp_Cost_Temp = PvExp_Cost_Temp / 2;
        PvExp_Cost.text = PvExp_Cost_Temp.ToString();        
        Checkpoints();
    }
    public void AddLuck()
    {
        Luck_Temp += 1;
        PlayerData.Instance.Point_For_Up = PlayerData.Instance.Point_For_Up - (int)LuckExp_Cost_Temp;
        LuckExp_Cost_Temp = LuckExp_Cost_Temp * 2;
        LuckExp_Cost.text = LuckExp_Cost_Temp.ToString();        
        Checkpoints();
    }
    public void RemoveLuck()
    {
        Luck_Temp -= 1;
        PlayerData.Instance.Point_For_Up = PlayerData.Instance.Point_For_Up + (int)LuckExp_Cost_Temp;
        LuckExp_Cost_Temp = LuckExp_Cost_Temp / 2;
        LuckExp_Cost.text = LuckExp_Cost_Temp.ToString();
        Checkpoints();
    }
    public void AddLifeSteal()
    {
        LifeSteal_Temp += 1;
        PlayerData.Instance.Point_For_Up = PlayerData.Instance.Point_For_Up + (int)LifeStealExp_Cost_Temp;
        LifeStealExp_Cost_Temp = LifeStealExp_Cost_Temp * 2;
        LifeStealExp_Cost.text = LifeStealExp_Cost_Temp.ToString();
        Checkpoints();
    }
    public void RemoveLifeSteal()
    {
        LifeSteal_Temp -= 1;
        PlayerData.Instance.Point_For_Up = PlayerData.Instance.Point_For_Up + (int)LifeStealExp_Cost_Temp;
        LifeStealExp_Cost_Temp = LifeStealExp_Cost_Temp / 2;
        LifeStealExp_Cost.text = LifeStealExp_Cost_Temp.ToString();
        Checkpoints();
    }
    public void Confirmation()
    {
        PlayerData.Instance.CritChance = Luck_Temp;
        PlayerData.Instance.LifestealPercent = LifeSteal_Temp;
        PlayerData.Instance.MaxHP = Hp_Temp;
        PlayerData.Instance.Cost_PV = (int)PvExp_Cost_Temp;
        PlayerData.Instance.Cost_Luck = (int) LuckExp_Cost_Temp;
        PlayerData.Instance.Cost_LifeSteal = (int) LifeStealExp_Cost_Temp;
    }
    public void Return()
    {
        SceneManager.LoadScene("WorldHUBScene");
    }
}

