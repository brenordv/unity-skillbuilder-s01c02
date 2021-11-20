// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameHandler _gameHandler;
    private ColorChanger _colorChanger;

    private void Start()
    {
        _gameHandler = FindObjectOfType<GameHandler>();
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Block")) return;

        var blockColorChanger = collision.gameObject.GetComponent<ColorChanger>();

        if (blockColorChanger == null)
            throw new ApplicationException(
                $"Blocks should have a ColorChanger component. (Obj name: '{collision.gameObject.name}')");

        if (blockColorChanger.spriteColor == _colorChanger.spriteColor) return;

        if (collision.gameObject.GetComponent<BlockMovement>().isActiveBool)
        {
            _gameHandler.AllPlayerBlocksArrayUpdate();
            _gameHandler.DestroyedBlockUpdate();
        }

        Destroy(collision.gameObject);
    }
}