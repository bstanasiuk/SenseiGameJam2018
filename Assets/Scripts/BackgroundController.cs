using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private RectTransform _backgroundPiecePrefab;
    [Range(0, 12)]
    [SerializeField] private int _boardScale = 1;
    private int _boardScaleOldValue;
    private Vector2 _oldResolution;

    private void Start()
    {
        _boardScaleOldValue = _boardScale;
        _oldResolution = new Vector2(Screen.width, Screen.height);
        CreateBackgroundPieces();
    }

    private void CreateBackgroundPieces()
    {
        if (_boardScale == 0) return;
        var pieceLength = Screen.width / _boardScale;
        var numberOfRows = Screen.height / pieceLength;
        for (var j = 0; j <= numberOfRows * 2 + 1; j++)
        {
            var offset = j % 2 == 0 ? pieceLength : 0;
            for (var i = offset + pieceLength / 2; i - pieceLength * 2 < Screen.width * 2; i += pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, j * pieceLength + pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
            }
            for (var i = offset + -pieceLength * 1.5f; i + pieceLength * 2 > -Screen.width * 2; i -= pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, j * pieceLength + pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
            }
            offset = j % 2 == 0 ? 0 : pieceLength;
            for (var i = offset + pieceLength / 2; i - pieceLength * 2 < Screen.width * 2; i += pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, -j * pieceLength - pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
            }
            for (var i = offset + -pieceLength * 1.5f; i + pieceLength * 2 > -Screen.width* 2; i -= pieceLength * 2)
            {
                var backgroundPiece = Instantiate(_backgroundPiecePrefab, transform, false);
                backgroundPiece.anchoredPosition = new Vector2(i, -j * pieceLength - pieceLength / 2);
                backgroundPiece.sizeDelta = new Vector2(pieceLength, pieceLength);
            }
        }
    }

    private void Update()
    {
        if (_boardScaleOldValue != _boardScale || _oldResolution.x != Screen.width || _oldResolution.y != Screen.height)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            CreateBackgroundPieces();
            _boardScaleOldValue = _boardScale;
            _oldResolution = new Vector2(Screen.width, Screen.height);
        }
    }
}