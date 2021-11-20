using Core.ExtensionMethods;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject winObj;
    public GameObject perfectScoreObj;
    
    private ColorChanger _colorChanger;
    private ScoreManager _scoreManager;
    
    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Block")
            || !other.IsSameColor(_colorChanger)) return;

        winObj.SetActive(true);
        
        if (_scoreManager.IsPerfectScore)
            perfectScoreObj.SetActive(true);
    }
}