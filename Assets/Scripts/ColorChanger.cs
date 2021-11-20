// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System;
using Core.Enums;
using Core.Helpers;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public ColorOption spriteColor;
    public bool randomColor;
    private SpriteRenderer _spriteRenderer;
    private bool _hasAnimation;
    private Color _cachedColor;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
            throw new ApplicationException($"This script requires a SpriteRenderer to '{gameObject.name}'...");
        
        if (randomColor)
            ChangeColor(null);
        else
            ChangeColor(spriteColor);
    }

    private void Start()
    {
        _hasAnimation = GetComponent<Animator>() != null;
    }

    private void LateUpdate()
    {
        if (!_hasAnimation) return;
        UpdateSpriteColor(_cachedColor);
    }

    public void ChangeColor(ColorOption? newColor)
    {
        var color = newColor ?? ColorOptionsHelper.GetRandom();
        spriteColor = color;
        _cachedColor = ColorOptionsHelper.ToColor(color);
        UpdateSpriteColor(_cachedColor);
    }

    private void UpdateSpriteColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}