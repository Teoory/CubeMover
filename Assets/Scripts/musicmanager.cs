using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour
{
    public AudioClip[] soundClips;  // Sahnede kullanılacak ses dosyaları
    public float fadeDuration = 1.0f;  // Geçiş süresi
    private AudioSource audioSource;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSoundWithFade());
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("musicupdate", 0) == 0)
        {
            StartCoroutine(PlayRandomSoundWithFade());
            PlayerPrefs.SetInt($"musicupdate", 1);
        }
    }

    IEnumerator PlayRandomSoundWithFade()
    {
        while (true)
        {
            // Rastgele bir ses dosyası seç
            AudioClip selectedClip = soundClips[Random.Range(0, soundClips.Length)];

            // Şu anki sesi durdur
            audioSource.Stop();

            // Yeni ses dosyasını atayıp oynatmaya başla
            audioSource.clip = selectedClip;
            audioSource.Play();

            // Fade in efekti uygulama
            float startVolume = 0.0f;
            float startTime = Time.time;
            while (Time.time < startTime + fadeDuration)
            {
                audioSource.volume = Mathf.Lerp(startVolume, 1.0f, (Time.time - startTime) / fadeDuration);
                yield return null;
            }
            audioSource.volume = 1.0f;

            // Sesin bitmesini bekle
            yield return new WaitForSeconds(selectedClip.length);

            // Fade out efekti uygulama
            startVolume = 1.0f;
            startTime = Time.time;
            while (Time.time < startTime + fadeDuration)
            {
                audioSource.volume = Mathf.Lerp(startVolume, 0.0f, (Time.time - startTime) / fadeDuration);
                yield return null;
            }
            audioSource.volume = 0.0f;

            yield return null;
        }
    }
}