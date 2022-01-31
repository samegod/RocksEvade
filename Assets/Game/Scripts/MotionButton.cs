using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Right,
    Left,
}
public class MotionButton : MonoBehaviour
{

    [SerializeField] private Direction side;

    public Direction Direction { 
        get
        {
            return side;
        } 
        private set { side = value; } 
    }
}
