using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldSelector : MonoBehaviour
{
    public void ChooseWorld1()
    {
        SceneManager.LoadScene("WorldHUBScene");
    }
}
