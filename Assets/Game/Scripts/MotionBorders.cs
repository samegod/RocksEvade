using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionBorders : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;

    #endregion

    #region Unity Methods

    private void Start()
    {
        SetBordersToScreen();
    }

    #endregion

    #region Public Methods

    public bool CheckBounds(Transform player, float direction, float offset)
    {
        if (direction < 0 && player.position.x - offset < leftBorder.position.x)
            return false;

        if (direction > 0 && player.position.x + offset > rightBorder.position.x)
            return false;

        return true;
    }

    #endregion

    #region Private Methods

    private void SetBordersToScreen()
    {
        leftBorder.position = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        rightBorder.position = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0));
    }

    #endregion
}
