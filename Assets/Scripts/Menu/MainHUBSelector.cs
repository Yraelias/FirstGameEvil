using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUBSelector : MonoBehaviour
{
    public void ChooseTarget()
    {
        SceneManager.LoadScene("TargetSelector");
    }
    public void ChooseWorld()
    {
        SceneManager.LoadScene("WorldSelector");
    }
}
