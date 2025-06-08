using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelector : MonoBehaviour
{
    public void ChooseVampire()
    {
        GameData.Archetype = "Vampire";
        SceneManager.LoadScene("TargetSelection");
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

    void GoToNextScene()
    {
        // Plus tard tu remplaceras "NextScene" par ta scène de choix de cibles
        SceneManager.LoadScene("NextScene");
    }
}
