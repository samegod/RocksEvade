using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right,
    Up,
    Down,
}

public class StaticMethods : MonoBehaviour
{


    public static Vector2 GenerateSpeedbyAngle(float angle)
    {
        Vector2 direction = new Vector2((float)Mathf.Cos(angle * Mathf.PI / 180), (float)Mathf.Sin(angle * Mathf.PI / 180));
        return direction;
    }
}
