using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Sprite _whiteSprite;
    [SerializeField] private Sprite[] _possibleBackground;
    [SerializeField] private Sprite[] _reverseBackground;
    private int _selectedBackgroundIndex;
    [SerializeField] private RectTransform _backgroundPiecePrefab;
    private List<Image> _chessBoardPiecesImages = new List<Image>();
    private bool _isReversed;
    [SerializeField] private float _reverseBackgroundProbability = 0.5f;
    [SerializeField] private float _chessBackgroundProbability = 0.5f;
    [SerializeField] private float _changeTime = 5f;

    private void Start()
    {
        _backgroundImage.sprite = _possibleBackground[2];
        InvokeRepeating("CreateBackground", 5, 5f);
    }

    private void CreateBackground()
    {
        _backgroundImage.color = Color.white;
        if (Random.Range(0f, 1f) > _reverseBackgroundProbability)
            CreateLayout();
        else
        {
            ReverseColors();
        }
    }

    private void ReverseColors()
    {
        if (_chessBoardPiecesImages.Count > 0)
        {
            ReverseChessBoardColors();
        }
        else
        {
            ReverseBackgroundImageLayout();
        }
        _isReversed = !_isReversed;
    }

    private void CreateLayout()
    {
        if (Random.Range(0f, 1f) > _chessBackgroundProbability)
        {
            CreateBackgroundImageLayout();
        }
        else
        {
            CreateChessLayout();
        }
        _isReversed = false;
    }

    private void CreateBackgroundImageLayout()
    {
        DeleteChessBoardPieces();
        _selectedBackgroundIndex = Random.Range(0, _possibleBackground.Length);
        _backgroundImage.sprite = _possibleBackground[_selectedBackgroundIndex];
    }

    private void ReverseBackgroundImageLayout()
    {
        _backgroundImage.sprite = _isReversed ? _possibleBackground[_selectedBackgroundIndex] : _reverseBackground[_selectedBackgroundIndex];
    }

    private void CreateChessLayout()
    {
        DeleteChessBoardPieces();
        _backgroundImage.sprite = _whiteSprite;
        _backgroundImage.color = new Color(1,1,1,1);
        var boardScale = Random.Range(0, 12);
        if (boardScale == 0) return;
        var pieceLength = Screen.width / boardScale;
        var numberOfRows = Screen.height / pieceLength;
        for (var j = 0; j <= numberOfRows * 2 + 1; j++)
        {
            var offset = j % 2 == 0 ? pieceLength : 0;
            for (var i = offset + pieceLength / 2; i - pieceLength * 2 < Screen.width * 2; i += pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, j * pieceLength + pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
                _chessBoardPiecesImages.Add(backgroundPiece.GetComponent<Image>());
            }
            for (var i = offset + -pieceLength * 1.5f; i + pieceLength * 2 > -Screen.width * 2; i -= pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, j * pieceLength + pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
                _chessBoardPiecesImages.Add(backgroundPiece.GetComponent<Image>());
            }
            offset = j % 2 == 0 ? 0 : pieceLength;
            for (var i = offset + pieceLength / 2; i - pieceLength * 2 < Screen.width * 2; i += pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, -j * pieceLength - pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
                _chessBoardPiecesImages.Add(backgroundPiece.GetComponent<Image>());
            }
            for (var i = offset + -pieceLength * 1.5f; i + pieceLength * 2 > -Screen.width * 2; i -= pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, -j * pieceLength - pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
                _chessBoardPiecesImages.Add(backgroundPiece.GetComponent<Image>());
            }
        }
    }

    private void ReverseChessBoardColors()
    {
        _backgroundImage.color = !_isReversed ? Color.black : Color.white;
        foreach (var chessBoardPiecesImage in _chessBoardPiecesImages)
        {
            chessBoardPiecesImage.color = !_isReversed ? Color.white : Color.black;
        }
    }

    private void DeleteChessBoardPieces()
    {
        foreach (var chessBoardPiecesImage in _chessBoardPiecesImages)
        {
            Destroy(chessBoardPiecesImage.gameObject);
        }
        _chessBoardPiecesImages = new List<Image>();
    }
}