using System;
using System.Collections;
using System.Collections.Generic;
using Core.ExtensionMethods;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Animator _animator;
    private ColorChanger _colorChanger;
    private static readonly int CantPickup = Animator.StringToHash("cantPickup");
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _colorChanger = GetComponent<ColorChanger>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Block")) return;

        if (!other.IsSameColor(_colorChanger))
        {
            _animator.SetTrigger(CantPickup);
            return;            
        }

        _scoreManager.CoinPickedUp();
        Destroy(gameObject);
    }
}
