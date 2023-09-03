using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    private Renderer objectRenderer;
    private float fadeDuration = 0.5f;
    private float currentFadeTime = 0f;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            Color randomColor = RandomHSVColor(100f, 100f);

            objectRenderer.material.color = randomColor;

            InvokeRepeating("DecreaseOpacity", 0.5f, 0.05f);
        }
    }

    private void DecreaseOpacity()
    {
        currentFadeTime += 0.05f;

        if (currentFadeTime <= fadeDuration)
        {
            float newAlpha = 1f - (currentFadeTime / fadeDuration);
            objectRenderer.material.color = new Color(objectRenderer.material.color.r, objectRenderer.material.color.g, objectRenderer.material.color.b, newAlpha);
        }
    }

    private Color RandomHSVColor(float saturation, float value)
    {
        float hue = Random.Range(0f, 1f);
        return Color.HSVToRGB(hue, saturation / 100f, value / 100f);
    }
}