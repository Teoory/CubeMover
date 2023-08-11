using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    Moving,
    Lost,
    ReadyForInput,
}

public class GameManager : MonoBehaviour
{
    [Header("PlayerMove")]
    [SerializeField] private Transform Player;
    private Vector3 targetDest = Vector3.zero;
    private GameState CurrentState;
    private bool _isLive = true;
    private bool isTouched = false;
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private bool isGameStarted = false;


    [Header("Platforms")]
    public Transform GlassPlatform;
    public Transform StartPlatform;
    private Transform CurrentPlatform = null;

    [Header("MoveDist")]
    private float playerMoveDist = 2f;

    [Header("Timer")]
    public Text timerText;
    private float timer;
    private bool isTimerRunning = false;

    [Header("highScore")]
    public GameObject highScorePanel;
    public Text highScoreTextPrefab;

    [Header("Panels")]
    public GameObject StartPanel;
    public GameObject DiePanel;

    [Header("CoinManager")]
    private CoinManager coinManager; // CoinManager referansı
    public Text EarnedCoinText;
    


    private void Start()
    {
        Time.timeScale = 0;
        StartPanel.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        CurrentPlatform = StartPlatform;
        StartCoroutine(SpawnPlatform());
        StartTimer();
        LoadHighScores();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        coinManager = FindObjectOfType<CoinManager>();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2");
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouched = true;
                touchStartPosition = touch.position;
                touchEndPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                touchEndPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouched = false;
                Vector2 touchDelta = touchEndPosition - touchStartPosition;

                if (isGameStarted)
                {
                    if (Mathf.Abs(touchDelta.x) > Mathf.Abs(touchDelta.y))
                    {
                        if (touchDelta.x > 0)
                        {
                            targetDest = Player.position + new Vector3(playerMoveDist, 0, 0);
                            CurrentState = GameState.Moving;
                            
                            Player.rotation = Quaternion.Euler(0, 0, 0);
                        }
                        else
                        {
                            targetDest = Player.position + new Vector3(-playerMoveDist, 0, 0);
                            CurrentState = GameState.Moving;
                            
                            Player.rotation = Quaternion.Euler(0, 180, 0);
                        }
                    }
                    else
                    {
                        if (touchDelta.y > 0)
                        {
                            targetDest = Player.position + new Vector3(0, 0, playerMoveDist);
                            CurrentState = GameState.Moving;
                            
                            Player.rotation = Quaternion.Euler(0, -90, 0);
                        }
                        else
                        {
                            targetDest = Player.position + new Vector3(0, 0, -playerMoveDist);
                            CurrentState = GameState.Moving;
                            
                            Player.rotation = Quaternion.Euler(0, 90, 0);
                        }
                    }
                }
                else
                {
                    isGameStarted = true;
                }
            }
        }
        else
        {
            isTouched = false;
        }
    }

    private void FixedUpdate()
    {
        if (CurrentState == GameState.Moving)
        {
            Player.position = Vector3.MoveTowards(Player.position, new Vector3(targetDest.x, Player.position.y, targetDest.z), 0.2f);

            if(Vector2.Distance(new Vector2(Player.position.x, Player.position.z), new Vector2(targetDest.x, targetDest.z)) < 0.1f)
            {
                Player.position = targetDest;
                CurrentState = GameState.ReadyForInput;
            }
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        StartPanel.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            DiePanel.gameObject.SetActive(false);
    }

    private void CreatePlatform(Transform _Platform, int _InValue)
    {
        if (_InValue == 0)
        {
            CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x, 0f, _Platform.position.z + 2), Quaternion.identity);
        }
        else if (_InValue == 1)
        {
            CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x, 0f, _Platform.position.z - 2), Quaternion.identity);
        }
        else if (_InValue == 2)
        {
            CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x + 2, 0, _Platform.position.z), Quaternion.identity);
        }
        else
        {
            CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x + 2, 0f, _Platform.position.z), Quaternion.identity);
        }
    }

    private IEnumerator SpawnPlatform()
    {
        float spawnInterval = 0.75f;
        float destroyDelay = 0.75f;
        float minInterval = 0.25f;

        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (destroyDelay > minInterval)
            {
                destroyDelay -= 0.003f;
                spawnInterval -= 0.003f;
            }

            Destroy(CurrentPlatform.gameObject, destroyDelay);

            if (CurrentState != GameState.Lost)
            {
                int newValue = Random.Range(0, 4);
                CreatePlatform(CurrentPlatform, newValue);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isLive && other.CompareTag("Player"))
        {
            StopTimer();
            CalculateAndAddCoins(timer);
            DiePanel.gameObject.SetActive(true);
            _isLive = false;
            Time.timeScale = 0;
        }
    }
    
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        SaveHighScore(timer);
    }
    
    private void SaveHighScore(float score)
    {
        int highScoreCount = PlayerPrefs.GetInt("HighScoreCount", 0);
        highScoreCount++;
        PlayerPrefs.SetInt("HighScoreCount", highScoreCount);

        PlayerPrefs.SetFloat($"HighScore_{highScoreCount}", score);
        PlayerPrefs.Save();

        UpdateHighScorePanel();
    }

    private void UpdateHighScorePanel()
    {
        ClearHighScorePanel();
        LoadHighScores();
    }

    private void ClearHighScorePanel()
    {
        foreach (Transform child in highScorePanel.transform)
        {
            Destroy(child.gameObject);
        }
    }


    private void LoadHighScores()
    {
        int highScoreCount = PlayerPrefs.GetInt("HighScoreCount", 0);

        // Bir liste oluşturarak yüksek skorları sıralayın
        List<float> highScores = new List<float>();
        for (int i = 1; i <= highScoreCount; i++)
        {
            float score = PlayerPrefs.GetFloat($"HighScore_{i}", 0f);
            highScores.Add(score);
        }
        highScores.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < highScores.Count; i++)
        {
            Text scoreText = Instantiate(highScoreTextPrefab, highScorePanel.transform);
            scoreText.text = $"{i + 1}. {highScores[i].ToString("F2")}";
        }
    }

    
    private void CalculateAndAddCoins(float time)
    {
        int earnedCoins = 0;

        if (time >= 0 && time < 9)
        {
            earnedCoins = 0;
        }
        else if (time < 15)
        {
            earnedCoins = 5;
        }
        else if (time < 30)
        {
            earnedCoins = 20;
        }
        else if (time < 60)
        {
            earnedCoins = 60;
        }
        else if (time < 75)
        {
            earnedCoins = 90;
        }
        else if (time < 90)
        {
            earnedCoins = 120;
        }
        else if (time < 120)
        {
            earnedCoins = 160;
        }
        else if (time < 150)
        {
            earnedCoins = 200;
        }
        else if (time < 180)
        {
            earnedCoins = 240;
        }
        else if (time < 240)
        {
            earnedCoins = 300;
        }
        else if (time < 300)
        {
            earnedCoins = 500;
        }
        else
        {
            earnedCoins = Mathf.FloorToInt(time) * 2;
        }

        // CoinManager'a kazanılan coin miktarını ekle
        CoinManager.instance.AddCoins(earnedCoins);
        EarnedCoinText.text = "Earned: " + earnedCoins.ToString() + " coin";
    }
}