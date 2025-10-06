using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color normalColor = Color.white;      // Cor padrão
    public Color hoverColor = Color.grey;        // Cor ao passar o mouse
    public float scaleMultiplier = 1.1f;         // Escala ao passar o mouse

    private Image buttonImage;
    private Vector3 originalScale;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = hoverColor;

        transform.localScale = originalScale * scaleMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.color = normalColor;

        transform.localScale = originalScale;
    }
}