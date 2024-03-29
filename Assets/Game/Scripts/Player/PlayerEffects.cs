﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    #region Fields

    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float motionRotationAngle = 30f;

    private Vector3 targetRotation;
    private Coroutine rotationCoroutine;


    #endregion

    #region Unity Methods

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime);
    }

    #endregion

    #region Public Methods

    public void StartMoveEffect(Direction direction)
    {
        int koef = 1;
        if (direction == Direction.Right)
            koef = -1;
        else if (direction == Direction.None)
            koef = 0;

        if (rotationCoroutine != null)
            StopCoroutine(rotationCoroutine);

        Debug.Log("www");
        rotationCoroutine = StartCoroutine(Rotation(new Vector3(0, motionRotationAngle * koef, 0)));
    }

    public void SetTargetRotation(Vector3 target)
    {
        targetRotation = target;
    }

    private IEnumerator Rotation(Vector3 targetAngles)
    {
        Vector3 initialRotation = transform.eulerAngles;

        while(Vector3.Distance(transform.eulerAngles, targetAngles) > 0.1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetAngles), Time.deltaTime * rotationSpeed);
            yield return null;
        }

        yield return null;
    }

    #endregion
}
