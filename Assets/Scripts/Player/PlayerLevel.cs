using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public static bool AddExp(int Exp)
    {
        PlayerData.Instance.Exp += Exp;
        if (PlayerData.Instance.Exp >= PlayerData.Instance.Next_Level)
        {
            LevelUp();
            return true;
        }
        return false;
    }

    public static void LevelUp()
    {
        PlayerData.Instance.Current_Level++;
        PlayerData.Instance.Next_Level = PlayerData.Instance.Next_Level * 5/4;
        PlayerData.Instance.Point_For_Up += 3;
    }
}