using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayerAggresiveState : CharacterBehavior
{
    public void Enter()
    {
        Debug.Log("Enter aggresive");
    }

    public void Exit()
    {
        Debug.Log("Exit aggresive");
    }

    public void Update()
    {
        Debug.Log("Update aggresive");
    }
}
