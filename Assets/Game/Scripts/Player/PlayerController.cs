using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerMotionController motionController;
    [SerializeField] private PlayerEffects playerEffects;

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
        playerEffects.StartMoveEffect(direction);
    }

    public void StopMotion()
    {
        motionController.StopMotion();
        playerEffects.StartMoveEffect(Direction.None);
    }

    #endregion

    #region Private Methods


    #endregion
}
