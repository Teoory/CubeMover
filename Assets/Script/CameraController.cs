using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform FollowObject;
    public Vector3 offset;

    private Camera mainCamera;
    private Color targetColor;
    private Color currentColor;
    private float fadeDuration = 10f;
    private float fadeTimer = 0f;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        currentColor = GetRandomHSVColor();
        mainCamera.backgroundColor = currentColor;
        targetColor = GetRandomHSVColor();
    }

    private void LateUpdate()
    {
        if (FollowObject != null)
        {
            transform.position = Vector3.Lerp(transform.position, FollowObject.position + offset, Time.deltaTime * 3f);
        }

        fadeTimer += Time.deltaTime;
        float t = fadeTimer / fadeDuration;

        if (fadeTimer >= fadeDuration)
        {
            fadeTimer = 0f;
            currentColor = mainCamera.backgroundColor;
            targetColor = GetRandomHSVColor();
        }

        mainCamera.backgroundColor = Color.Lerp(currentColor, targetColor, t);
    }

    private Color GetRandomHSVColor()
    {
        float h = Random.value;
        float s = 1f;
        float v = 0.35f;
        return Color.HSVToRGB(h, s, v);
    }
}