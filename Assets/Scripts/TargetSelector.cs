using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSelector : MonoBehaviour
{
    public void ChoosePaysan()
    {
        GameData.ChosenTarget = "Paysan";
        SceneManager.LoadScene("CombatScene");
    }

    public void ChooseSDF()
    {
        GameData.ChosenTarget = "SDF";
        SceneManager.LoadScene("CombatScene");
    }

    public void ChooseGarde()
    {
        GameData.ChosenTarget = "Garde";
        SceneManager.LoadScene("CombatScene");
    }
}
