using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text _remainingBackgroundTimeText;
    [SerializeField] private Image _firstPlayerScoreImage;
    [SerializeField] private Sprite[] _firstPlayerScoreSprites;
    [SerializeField] private Image _secondPlayerScoreImage;
    [SerializeField] private Sprite[] _secondPlayerScoreSprites;
    [SerializeField] private Image _playerDiedImage;
    [SerializeField] private Sprite _whitePlayerDiedSprite;
    [SerializeField] private Sprite _blackPlayerDiedSprite;
    private int _firstPlayerScore;
    private int _secondPlayerScore;
    public static UiController Instance { get; private set; }
    private bool _alreadyScored = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        InitializeSingletonInstance();
    }

    private void Start()
    {
        LoadScores();
        //SetScoresToZero();
    }

    private void Update()
    {
        if (_playerDiedImage.gameObject.activeInHierarchy && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void InitializeSingletonInstance()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void LoadScores()
    {
        _firstPlayerScore = PlayerPrefs.GetInt("BlackPlayerScore", 0);
        _secondPlayerScore = PlayerPrefs.GetInt("WhitePlayerScore", 0);
        _firstPlayerScoreImage.sprite = _firstPlayerScoreSprites[_firstPlayerScore];
        _secondPlayerScoreImage.sprite = _secondPlayerScoreSprites[_secondPlayerScore];
    }

    private void SetScoresToZero()
    {
        _firstPlayerScore = 0;
        _secondPlayerScore = 0;
        PlayerPrefs.SetFloat("BlackPlayerScore", _firstPlayerScore);
        PlayerPrefs.SetFloat("WhitePlayerScore", _secondPlayerScore);
    }

    public void AddPointForFirstPlayer()
    {
        if (_alreadyScored) return;
        Invoke("DelayedStopTime", 0.3f);
        _firstPlayerScore++;
        PlayerPrefs.SetInt("BlackPlayerScore", _firstPlayerScore);
        _firstPlayerScoreImage.sprite = _firstPlayerScoreSprites[_firstPlayerScore];
        _playerDiedImage.gameObject.SetActive(true);
        _playerDiedImage.sprite = _whitePlayerDiedSprite;
        _alreadyScored = true;
        if (_firstPlayerScore >= 3) 
            SetScoresToZero();

    }

    public void AddPointForSecondPlayer()
    {
        if (_alreadyScored) return;
        Invoke("DelayedStopTime", 0.3f);
        _secondPlayerScore++;
        PlayerPrefs.SetInt("WhitePlayerScore", _secondPlayerScore);
        _secondPlayerScoreImage.sprite = _secondPlayerScoreSprites[_secondPlayerScore];
        _playerDiedImage.gameObject.SetActive(true);
        _playerDiedImage.sprite = _blackPlayerDiedSprite;
        _alreadyScored = true;
        if (_secondPlayerScore >= 3)
            SetScoresToZero();
    }

    private void DelayedStopTime()
    {
        Time.timeScale = 0f;
    }

    public void SetRemainingBackgroundTimeText(int remainingSeconds)
    {
        _remainingBackgroundTimeText.text = "" + remainingSeconds;
    }
}