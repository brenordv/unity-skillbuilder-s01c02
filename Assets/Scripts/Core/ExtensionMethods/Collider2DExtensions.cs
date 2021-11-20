using System;
using UnityEngine;

namespace Core.ExtensionMethods
{
    public static class Collider2DExtensions
    {
        public static bool IsSameColor(this Collider2D other, ColorChanger myColorChanger)
        {
            var otherColorChanger = other.GetComponent<ColorChanger>();

            if (otherColorChanger == null)
                throw new ApplicationException($"To compare sprite colors, the object must have ColorChanger component. Please, fix that for '{other.gameObject.name}'");

            return otherColorChanger.spriteColor == myColorChanger.spriteColor;
        }
        
    }
}