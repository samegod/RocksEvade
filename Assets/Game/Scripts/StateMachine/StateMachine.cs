using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum States
{
    Idle, 
    Aggresive, 
}

public class StateMachine : MonoBehaviour
{
    [SerializeField] private States currentSatate;

    private Dictionary<States, CharacterBehavior> behaviorsMap;
    private CharacterBehavior currentBehavior;
    private int statesNumber;

    private void Start()
    {
        statesNumber = Enum.GetNames(typeof(States)).Length;

        InitBehaviors();
    }

    private void Update()
    {
        if (currentBehavior != null)
            currentBehavior.Update();
    }

    public void SetBehavior(States newState)
    {
        if (currentBehavior != null)
            currentBehavior.Exit();

        currentBehavior = behaviorsMap[newState];
        currentBehavior.Enter();
    }

    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<States, CharacterBehavior>();

        behaviorsMap[States.Idle] = new IPlayerIdleState();
        behaviorsMap[States.Aggresive] = new IPlayerAggresiveState();
    }


}
