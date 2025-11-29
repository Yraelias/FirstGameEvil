using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelector : MonoBehaviour
{

    public void ChooseNewGame()
    {
        SceneManager.LoadScene("ChooseCharacter");
    }
    public void ChooseExit()
    {
        Application.Quit();
    }
}
