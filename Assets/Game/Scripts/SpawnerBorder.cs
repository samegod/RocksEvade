using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBorder : MonoBehaviour
{
    [SerializeField] private float maxAngle;

    public float MaxAngle
    {
        get { return maxAngle; }
        private set { maxAngle = value; }
    }
}
