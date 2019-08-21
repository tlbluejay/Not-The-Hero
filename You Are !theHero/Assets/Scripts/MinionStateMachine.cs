using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionStateMachine : MonoBehaviour
{

    public MinionController minion;

    public enum TurnState
    {
        Waiting,
        Selecting,
        Action,
        Dead
    }

    public TurnState currentState;

    void updateProgress()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case TurnState.Waiting:
                break;
            case TurnState.Selecting:
                break;
            case TurnState.Action:
                break;
            case TurnState.Dead:
                break;
        }
    }
}
