using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject FollowObject;
    public Vector3 offset = new Vector3(3, 6, -10);

    private Camera mainCamera;
    private Color targetColor;
    private Color currentColor;
    private float fadeDuration = 10f;
    private float fadeTimer = 0f;

    private void Start()
    {
        FollowObject = GameObject.Find("Player");
        mainCamera = GetComponent<Camera>();
        currentColor = GetRandomHSVColor();
        mainCamera.backgroundColor = currentColor;
        targetColor = GetRandomHSVColor();
        offset = new Vector3(3f, 6f, -10f);
    }

    public void _lookChar()
    {
        offset = new Vector3(0.5f, 0.75f, -1f);
        transform.position = new Vector3(3f, 5.5f, -10f);
        Camera.main.orthographicSize = 3;
    }
    public void _BackChar()
    {
        offset = new Vector3(3f, 8f, -10f);
        transform.position = new Vector3(5f, 7.5f, -18f);
        Camera.main.orthographicSize = 7;
    }

    private void LateUpdate()
    {
        if (FollowObject != null)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, FollowObject.transform.position + offset, Time.deltaTime * 3f);
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
        float v = 0.50f;
        return Color.HSVToRGB(h, s, v);
    }
}