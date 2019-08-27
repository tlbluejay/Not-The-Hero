using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionStateMachine : MonoBehaviour
{

    public MinionController minion;

    public enum TurnState
    {
        Processing,
        AddToList,
        Waiting,
        Selecting,
        Action,
        Dead
    }

    public TurnState currentState;

    private float currentCooldown = 0f;
    private float maxCooldown = 5f;
    public Image ProgressBar;

    void updateProgressBar()
    {
        currentCooldown = currentCooldown + Time.deltaTime;
        float calculateCooldown = currentCooldown / maxCooldown;
        ProgressBar.transform.localScale = 
            new Vector3(Mathf.Clamp(calculateCooldown, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        if (currentCooldown >= maxCooldown)
        {
            currentState = TurnState.AddToList;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.Processing;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case TurnState.Processing:
                updateProgressBar();
                break;
            case TurnState.AddToList:
                break;
            case TurnState.Waiting:
                break;
            case TurnState.Selecting:
                break;
            case TurnState.Action:
                break;
            case TurnState.Dead:
                break;
            default:
                break;
        }
    }
}
