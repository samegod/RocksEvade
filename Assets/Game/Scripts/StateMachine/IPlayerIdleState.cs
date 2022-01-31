using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayerIdleState : CharacterBehavior
{
    public void Enter()
    {
        Debug.Log("Enter idle");
    }

    public void Exit()
    {
        Debug.Log("Exit idle");
    }

    public void Update()
    {
        Debug.Log("Update idle");
    }
}
