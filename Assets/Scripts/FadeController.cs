using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    public void TrocarCenaComFade(string nomeCena)
    {
        StartCoroutine(FadeAndLoadScene(nomeCena));
    }

    private IEnumerator FadeAndLoadScene(string cena)
    {
        // Fade Out
        yield return StartCoroutine(Fade(1f));

        // Carregar nova cena
        SceneManager.LoadScene(cena);

        // Esperar um frame pra garantir que a cena carregou
        yield return null;

        // Fade In
        yield return StartCoroutine(Fade(0f));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        Color cor = fadeImage.color;
        float startAlpha = cor.a;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            fadeImage.color = new Color(cor.r, cor.g, cor.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(cor.r, cor.g, cor.b, targetAlpha);
    }
}