using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Events & Delegates

    public delegate void VoidDelegate();
    public static VoidDelegate OnStopMotion;

    public delegate void SideDelegate(Direction side);
    public static SideDelegate OnMove;

    #endregion

    #region Fields

    [SerializeField] private PlayerController player;

    #endregion

    #region Unity Methods

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                MotionButton motionButton = hit.collider.gameObject.GetComponent<MotionButton>();
                if (motionButton != null)
                {
                    Move(motionButton.Direction);
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            StopMotion();
        }
    }

    #endregion

    #region Public Methods


    #endregion

    #region Private Methods

    private void Move(Direction direction)
    {
        OnMove?.Invoke(direction);
    }

    private void StopMotion()
    {
        OnStopMotion?.Invoke();
    }

    #endregion

}
