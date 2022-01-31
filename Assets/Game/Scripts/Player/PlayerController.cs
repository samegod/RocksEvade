using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerMotionController motionController;

    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        PlayerInput.OnMove += Move;
        PlayerInput.OnStopMotion += StopMotion;
    }

    private void OnDisable()
    {
        PlayerInput.OnMove -= Move;
        PlayerInput.OnStopMotion -= StopMotion;
    }

    #endregion

    #region Public Methods

    public void Move(Direction direction)
    {
        motionController.Move(direction);
    }

    public void StopMotion()
    {
        motionController.StopMotion();
    }

    #endregion

    #region Private Methods


    #endregion
}
