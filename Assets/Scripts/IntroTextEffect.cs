using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroTextEffect : MonoBehaviour
{
    public Text introText; // Reference to the IntroText
    public float fadeDuration = 2f; // Duration of fade-in and fade-out
    public float displayDuration = 3f; // Duration to display text after fade-in

    void Start()
    {
        StartCoroutine(PlayIntroText());
    }

    private IEnumerator PlayIntroText()
    {
        introText.color = new Color(introText.color.r, introText.color.g, introText.color.b, 0);

        yield return StartCoroutine(FadeText(0f, 1f, fadeDuration));

        yield return new WaitForSeconds(displayDuration);

        yield return StartCoroutine(FadeText(1f, 0f, fadeDuration));

        introText.gameObject.SetActive(false);
    }

    private IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color currentColor = introText.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            introText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        introText.color = new Color(currentColor.r, currentColor.g, currentColor.b, endAlpha);
    }
}
