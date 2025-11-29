using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelector : MonoBehaviour
{
    public void ChooseFirstChararacter()
    {
        PlayerData.Instance.Archetype = "CharacterOne";
        PlayerData.Instance.Armor = 0;
        PlayerData.Instance.MaxHP = 15;
        PlayerData.Instance.DodgePercent = 0f;
        PlayerData.Instance.CurrentHP = 15;
        PlayerData.Instance.LifestealPercent = 0f;
        PlayerData.Instance.CritMultiplier = 0f;
        PlayerData.Instance.MaxHP = 15;
        PlayerData.Instance.CurrentPA = 3;
        PlayerData.Instance.MaxPA = 3;
        PlayerData.Instance.Cost_LifeSteal = 1;
        PlayerData.Instance.Cost_Luck = 1;
        PlayerData.Instance.Cost_PV = 1;
        PlayerData.Instance.Point_For_Up = 0;
        SceneManager.LoadScene("MainHUBSelector");
    }
    public void ChooseVampire()
    {
        PlayerData.Instance.Archetype = "Vampire";
        PlayerData.Instance.Armor = 0;
        PlayerData.Instance.MaxHP = 10;
        PlayerData.Instance.DodgePercent = 0.1f;
        PlayerData.Instance.CurrentHP = 10;
        PlayerData.Instance.LifestealPercent = 0f;
        PlayerData.Instance.CritMultiplier = 0f;
        PlayerData.Instance.MaxHP = 10;       
        PlayerData.Instance.CurrentPA = 3;
        PlayerData.Instance.MaxPA = 3;
        SceneManager.LoadScene("MainHUBSelector");
    }

    public void ChooseLiche()
    {
        GameData.Archetype = "Liche";
        SceneManager.LoadScene("TargetSelection");
    }

    public void ChooseDemon()
    {
        GameData.Archetype = "Demon";
        SceneManager.LoadScene("TargetSelection");
    }

}
