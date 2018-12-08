using UnityEngine;
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

    private void Awake()
    {
        InitializeSingletonInstance();
    }

    private void Start()
    {
        LoadScores();
        //SetScoresToZero();
    }

    private void Update()
    {
        //if (_playerDiedImage.gameObject.activeInHierarchy)
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
        _firstPlayerScoreImage.sprite = _firstPlayerScoreSprites[PlayerPrefs.GetInt("BlackPlayerScore", 0)];
        _secondPlayerScoreImage.sprite = _secondPlayerScoreSprites[PlayerPrefs.GetInt("WhitePlayerScore", 0)];
    }

    private void SetScoresToZero()
    {
        _firstPlayerScore = 0;
        _secondPlayerScore = 0;
        PlayerPrefs.SetFloat("BlackPlayerScore", _firstPlayerScore);
        PlayerPrefs.SetFloat("WhitePlayerScore", _secondPlayerScore);
        _firstPlayerScoreImage.sprite = _firstPlayerScoreSprites[_firstPlayerScore];
        _secondPlayerScoreImage.sprite = _secondPlayerScoreSprites[_secondPlayerScore];
    }

    public void AddPointForFirstPlayer()
    {
        Time.timeScale = 0f;
        _firstPlayerScore++;
        PlayerPrefs.SetInt("BlackPlayerScore", _firstPlayerScore);
        _firstPlayerScoreImage.sprite = _firstPlayerScoreSprites[_firstPlayerScore];
        _playerDiedImage.gameObject.SetActive(true);
        _playerDiedImage.sprite = _whitePlayerDiedSprite;
    }

    public void AddPointForSecondPlayer()
    {
        Time.timeScale = 0f;
        _secondPlayerScore++;
        PlayerPrefs.SetInt("WhitePlayerScore", _secondPlayerScore);
        _secondPlayerScoreImage.sprite = _secondPlayerScoreSprites[_secondPlayerScore];
        _playerDiedImage.gameObject.SetActive(true);
        _playerDiedImage.sprite = _blackPlayerDiedSprite;
    }

    public void SetRemainingBackgroundTimeText(int remainingSeconds)
    {
        _remainingBackgroundTimeText.text = "" + remainingSeconds;
    }
}