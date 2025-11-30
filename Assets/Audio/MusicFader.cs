using UnityEngine;
using System.Collections;

public class MusicFader : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2f;
    public float targetVolume = 0.5f;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0f;
        audioSource.Play();
        StartCoroutine(FadeInMusic());
    }

    IEnumerator FadeInMusic()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, targetVolume, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    // 🔥 FADE OUT PUBLIC POUR LES AUTRES SCRIPTS
    public IEnumerator FadeOutAndStop()
    {
        float startVolume = audioSource.volume;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }
}
