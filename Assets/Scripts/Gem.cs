using UnityEngine;

public class Gem : MonoBehaviour
{
    private ColorChanger _colorChanger;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherColorChanger = other.GetComponent<ColorChanger>();
        if (otherColorChanger == null || !other.CompareTag("Block")) return;
        otherColorChanger.ChangeColor(_colorChanger.spriteColor);
    }
}