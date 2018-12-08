using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Image _firstPlayerScoreImage;
    [SerializeField] private Sprite[] _firstPlayerScoreSprites;
    [SerializeField] private Image _secondPlayerScoreImage;
    [SerializeField] private Sprite[] _secondPlayerScoreSprites;
    private int _firstPlayerScore;
    private int _secondPlayerScore;
    public static UiController Instance { get; private set; }

    private void Awake()
    {
        InitializeSingletonInstance();
    }

    private void Start()
    {
        SetScoresToZero();
    }

    private void InitializeSingletonInstance()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void SetScoresToZero()
    {
        _firstPlayerScore = 0;
        _secondPlayerScore = 0;
        _firstPlayerScoreImage.sprite = _firstPlayerScoreSprites[_firstPlayerScore];
        _secondPlayerScoreImage.sprite = _secondPlayerScoreSprites[_secondPlayerScore];
    }

    public void AddPointForFirstPlayer()
    {
        _firstPlayerScore++;
        _firstPlayerScoreImage.sprite = _firstPlayerScoreSprites[_firstPlayerScore];
    }

    public void AddPointForSecondPlayer()
    {
        _secondPlayerScore++;
        _secondPlayerScoreImage.sprite = _secondPlayerScoreSprites[_secondPlayerScore];
    }
}