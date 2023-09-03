using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public enum GameState
    {
        Moving,
        Lost,
        ReadyForInput,
    }

    
    [Header("PlayerMove")]
    [SerializeField] private Transform Player;
    [SerializeField]private GameObject Playerm;
    [SerializeField]private Rigidbody rb;
    private Vector3 targetDest = Vector3.zero;
    private GameState CurrentState;
    private bool _isLive = true;
    private bool isTouched = false;
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private bool isGameStarted = false;
    public bool _isMoving = false;

    
    public playerManager PlayerManager;
    public bool _moveTrue;

    [Header("Platforms")]
    public Transform GlassPlatform;
    public Transform StartPlatform;
    private Transform CurrentPlatform = null;
    private bool _gameStart = false;

    [Header("MoveDist")]
    private float playerMoveDist = 2f;

    [Header("Timer")]
    public Text timerText;
    private float timer;
    private bool isTimerRunning = false;

    [Header("Panels")]
    public GameObject DiePanel;

    [Space]
    public GameObject upSwipe;
    public GameObject rightSwipe;
    public GameObject leftSwipe;
    public GameObject downSwipe;

    [Header("Tutorial")]
    [SerializeField]private bool firstmove;
    [SerializeField]private bool secondmove;
    [SerializeField]private bool thirdmove;
    [SerializeField]private bool fourthmove;
    [SerializeField]bool SpawnerEnabled = false;
    bool tutorialEnd = false;
    
    float destroyDelay = 0.75f;


    private void Awake()
    {
        Playerm = GameObject.Find("Player");
        Player = Playerm.transform;
        rb = Playerm.GetComponent<Rigidbody>(); 
    }

    private void Start()
    {
        CurrentPlatform = StartPlatform;
        _gameStart = false;
        rightSwipe.SetActive(true);
        firstmove = true;
        StartTimer();
    }

    private void Update()
    {
        _moveTrue = PlayerManager._isMoveEnable;
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
                                
                                if(firstmove)
                                {
                                    secondmove = true;
                                    SpawnerEnabled = true;
                                }
                            }
                            else
                            {
                                targetDest = Player.position + new Vector3(-playerMoveDist, 0, 0);
                                CurrentState = GameState.Moving;

                                Player.rotation = Quaternion.Euler(0, 180, 0);

                                if(thirdmove)
                                {
                                    fourthmove = true;
                                    SpawnerEnabled = true;
                                }
                            }
                        }
                        else
                        {
                            if (touchDelta.y > 0)
                            {
                                targetDest = Player.position + new Vector3(0, 0, playerMoveDist);
                                CurrentState = GameState.Moving;

                                Player.rotation = Quaternion.Euler(0, -90, 0);

                                if(secondmove)
                                {
                                    thirdmove = true;
                                    SpawnerEnabled = true;
                                }
                            }
                            else
                            {
                                targetDest = Player.position + new Vector3(0, 0, -playerMoveDist);
                                CurrentState = GameState.Moving;

                                Player.rotation = Quaternion.Euler(0, 90, 0);

                                if(fourthmove)
                                {
                                    fourthmove = true;
                                    SpawnerEnabled = true;
                                }
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

        if(firstmove && SpawnerEnabled)
        {
            Destroy(CurrentPlatform.gameObject, destroyDelay);
            rightSpawner(CurrentPlatform);
            SpawnerEnabled = false;
            firstmove = false;
        }
        if(secondmove && SpawnerEnabled)
        {
            Destroy(CurrentPlatform.gameObject, destroyDelay);
            upperSpawner(CurrentPlatform);
            SpawnerEnabled = false;
            secondmove = false;
        }
        if(thirdmove && SpawnerEnabled)
        {
            Destroy(CurrentPlatform.gameObject, destroyDelay);
            leftSpawner(CurrentPlatform);
            SpawnerEnabled = false;
            thirdmove = false;
        }
        if(fourthmove && SpawnerEnabled)
        {
            Destroy(CurrentPlatform.gameObject, destroyDelay);
            downSpawner(CurrentPlatform);
            SpawnerEnabled = false;
            fourthmove = false;
            tutorialEnd = true;
        }

        if(tutorialEnd)
        {
            PlayerPrefs.SetInt($"TutorialEnd", 1);
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        if(_moveTrue)
        {
            if (CurrentState == GameState.Moving)
            {
                Player.position = Vector3.MoveTowards(Player.position, new Vector3(targetDest.x, Player.position.y, targetDest.z), 0.2f);
                rb.velocity = new Vector3(rb.velocity.x, 0f , rb.velocity.z);
                rb.AddForce(transform.up * 1.5f, ForceMode.Impulse);
                if(Vector2.Distance(new Vector2(Player.position.x, Player.position.z), new Vector2(targetDest.x, targetDest.z)) < 0.1f)
                {
                    Player.position = targetDest;
                    CurrentState = GameState.ReadyForInput;
                }
            }
        }
    }

    private void rightSpawner(Transform _Platform)
    {
        rightSwipe.SetActive(false); // DeactivaterightSwipe
        upSwipe.SetActive(true); // Activate upSwipe
        leftSwipe.SetActive(false); //Deactivate rightSwipe
        downSwipe.SetActive(false); //Deactivate rightSwipe
        // Create a platform in the right direction
        CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x + 2, 0, _Platform.position.z), Quaternion.identity);
    }
    private void upperSpawner(Transform _Platform)
    {
        leftSwipe.SetActive(true); // Activate rightSwipe
        upSwipe.SetActive(false); // Deactivate upSwipe
        downSwipe.SetActive(false); // Deactivate upSwipe
        rightSwipe.SetActive(false); // Deactivate upSwipe
        // Create a platform in the right direction
        CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x, 0, _Platform.position.z + 2), Quaternion.identity);
    }
    private void leftSpawner(Transform _Platform)
    {
        downSwipe.SetActive(true); // Activate rightSwipe
        leftSwipe.SetActive(false); // Deactivate upSwipe
        upSwipe.SetActive(false); // Deactivate upSwipe
        rightSwipe.SetActive(false); // Deactivate upSwipe
        // Create a platform in the right direction
        CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x - 2, 0, _Platform.position.z), Quaternion.identity);
    }
    private void downSpawner(Transform _Platform)
    {
        downSwipe.SetActive(false); // Deactivate upSwipe
        upSwipe.SetActive(false); // Deactivate upSwipe
        rightSwipe.SetActive(false); // Deactivate upSwipe
        leftSwipe.SetActive(false); // Deactivate upSwipe
        // Create a platform in the right direction
        CurrentPlatform = Instantiate(GlassPlatform, new Vector3(_Platform.position.x, 0, _Platform.position.z - 2), Quaternion.identity);
    }


    public void StartGame()
    {
        Time.timeScale = 1;
        timerText.gameObject.SetActive(true);
        _isMoving = true;
        _gameStart = true;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("_Main");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (_isLive && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
