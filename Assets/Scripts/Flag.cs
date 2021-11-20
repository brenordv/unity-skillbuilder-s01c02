using Core.ExtensionMethods;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject winObj;
    private ColorChanger _colorChanger;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Block")
            || !other.IsSameColor(_colorChanger)) return;

        winObj.SetActive(true);
    }
}