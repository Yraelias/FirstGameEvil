using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    // UI
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

    // Temp values
    private float Luck_Temp;
    private int Hp_Temp;
    private float LifeSteal_Temp;

    // Cost temp
    private float PvExp_Cost_Temp;
    private float LuckExp_Cost_Temp;
    private float LifeStealExp_Cost_Temp;

    // Base values (min)
    private float Luck_Base;
    private int Hp_Base;
    private float LifeSteal_Base;

    void Start()
    {
        Luck_Temp = PlayerData.Instance.CritChance;
        Hp_Temp = PlayerData.Instance.MaxHP;
        LifeSteal_Temp = PlayerData.Instance.LifestealPercent;

        Luck_Base = PlayerData.Instance.CritChance;
        Hp_Base = PlayerData.Instance.MaxHP;
        LifeSteal_Base = PlayerData.Instance.LifestealPercent;

        PvExp_Cost_Temp = PlayerData.Instance.Cost_PV;
        LuckExp_Cost_Temp = PlayerData.Instance.Cost_Luck;
        LifeStealExp_Cost_Temp = PlayerData.Instance.Cost_LifeSteal;

        LevelText.text = PlayerData.Instance.Current_Level.ToString();

        HpText.text = Hp_Temp.ToString();
        LuckText.text = Luck_Temp.ToString();
        lifeStealText.text = LifeSteal_Temp.ToString();

        PvExp_Cost.text = PvExp_Cost_Temp.ToString();
        LuckExp_Cost.text = LuckExp_Cost_Temp.ToString();
        LifeStealExp_Cost.text = LifeStealExp_Cost_Temp.ToString();

        CheckButtons();
    }

    void CheckButtons()
    {
        int points = PlayerData.Instance.Point_For_Up;

        BtnHpUp.enabled = points >= PvExp_Cost_Temp;
        BtnLuckUp.enabled = points >= LuckExp_Cost_Temp;
        BtnLifeStealUp.enabled = points >= LifeStealExp_Cost_Temp;

        BtnHpDown.enabled = Hp_Temp > Hp_Base;
        BtnLuckDown.enabled = Luck_Temp > Luck_Base;
        BtnLifeStealDown.enabled = LifeSteal_Temp > LifeSteal_Base;

        Points_Txt.text = points.ToString();
    }

    public void AddHp()
    {
        Hp_Temp += 1;
        PlayerData.Instance.Point_For_Up -= (int)PvExp_Cost_Temp;
        PvExp_Cost_Temp *= 2;

        HpText.text = Hp_Temp.ToString();
        PvExp_Cost.text = PvExp_Cost_Temp.ToString();

        CheckButtons();
    }

    public void RemoveHp()
    {
        Hp_Temp -= 1;
        PvExp_Cost_Temp /= 2;
        PlayerData.Instance.Point_For_Up += (int)PvExp_Cost_Temp;
        

        HpText.text = Hp_Temp.ToString();
        PvExp_Cost.text = PvExp_Cost_Temp.ToString();

        CheckButtons();
    }

    public void AddLuck()
    {
        Luck_Temp += 1;
        PlayerData.Instance.Point_For_Up -= (int)LuckExp_Cost_Temp;
        LuckExp_Cost_Temp *= 2;

        LuckText.text = Luck_Temp.ToString();
        LuckExp_Cost.text = LuckExp_Cost_Temp.ToString();

        CheckButtons();
    }

    public void RemoveLuck()
    {
        Luck_Temp -= 1;
        LuckExp_Cost_Temp /= 2;
        PlayerData.Instance.Point_For_Up += (int)LuckExp_Cost_Temp;
        

        LuckText.text = Luck_Temp.ToString();
        LuckExp_Cost.text = LuckExp_Cost_Temp.ToString();

        CheckButtons();
    }

    public void AddLifeSteal()
    {
        LifeSteal_Temp += 1;
        PlayerData.Instance.Point_For_Up -= (int)LifeStealExp_Cost_Temp;   // fix
        LifeStealExp_Cost_Temp *= 2;

        lifeStealText.text = LifeSteal_Temp.ToString();
        LifeStealExp_Cost.text = LifeStealExp_Cost_Temp.ToString();

        CheckButtons();
    }

    public void RemoveLifeSteal()
    {
        LifeSteal_Temp -= 1;
        LifeStealExp_Cost_Temp /= 2;
        PlayerData.Instance.Point_For_Up += (int)LifeStealExp_Cost_Temp;
        

        lifeStealText.text = LifeSteal_Temp.ToString();
        LifeStealExp_Cost.text = LifeStealExp_Cost_Temp.ToString();

        CheckButtons();
    }

    public void Confirmation()
    {
        PlayerData.Instance.CritChance = Luck_Temp;
        PlayerData.Instance.LifestealPercent = LifeSteal_Temp;
        PlayerData.Instance.MaxHP = Hp_Temp;

        PlayerData.Instance.Cost_PV = (int)PvExp_Cost_Temp;
        PlayerData.Instance.Cost_Luck = (int)LuckExp_Cost_Temp;
        PlayerData.Instance.Cost_LifeSteal = (int)LifeStealExp_Cost_Temp;
    }

    public void Return()
    {
        SceneManager.LoadScene("WorldHUBScene");
    }
}
