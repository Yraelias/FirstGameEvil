using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMenu : MonoBehaviour
{
    public void LevelUp()
    {
        SceneManager.LoadScene("CharacterLevelUp");
    }
}
