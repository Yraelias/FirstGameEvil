using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldHUBSelector : MonoBehaviour
{
    public TextMeshProUGUI PvText;
    public TextMeshProUGUI ExpText;

    private void Start()
    {
        PvText.text = $"{PlayerData.Instance.CurrentHP} PV";
        ExpText.text = $"{PlayerData.Instance.Exp} Exp";
    }
    public void ChooseTarget()
    {
        SceneManager.LoadScene("TargetSelector");
    }
    public void GoToHUB()
    {
        SceneManager.LoadScene("MainHUBSelector");
    }
}
