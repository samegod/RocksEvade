using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    #region Fields

    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;

    private Rigidbody2D _rigidbody;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    #endregion

    #region Public Methods

    public void SetSpeedByAngle(float angle)
    {
        Vector2 direcrion = StaticMethods.GenerateSpeedbyAngle(angle);
        SetSpeed(direcrion);
    }

    public void SetSpeed(Vector2 direction)
    {
        _rigidbody.velocity = direction * GetRandomSpeed();
    }

    #endregion

    #region Private Methods

    private float GetRandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }

    #endregion
}
