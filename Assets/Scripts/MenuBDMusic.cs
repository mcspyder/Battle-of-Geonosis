using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBDMusic : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Play music when the scene starts
    }

    public void StopMusic()
    {
        audioSource.Stop(); // Stop the music
    }

    public void FadeOutMusic(float duration)
    {
        StartCoroutine(FadeOut(duration));
    }

    private IEnumerator FadeOut(float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // Reset volume
    }
}

