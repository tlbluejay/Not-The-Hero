using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine : MonoBehaviour
{

    public enum PerformAction
    {
        Wait,
        TakeAction,
        PerformAction
    }
    public PerformAction battleStates;

    public List<TurnHandler> PerformList = new List<TurnHandler>();
    public List<GameObject> MinionsInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();

    public void CollectActions(TurnHandler th)
    {
        PerformList.Add(th);
    }

    // Start is called before the first frame update
    void Start()
    {
        battleStates = PerformAction.Wait;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
        MinionsInBattle.AddRange(GameObject.FindGameObjectsWithTag("minion"));
    }

    // Update is called once per frame
    void Update()
    {
        switch(battleStates)
        {
            case PerformAction.Wait:
                break;
            case PerformAction.TakeAction:
                break;
            case PerformAction.PerformAction:
                break;
            default:
                break;
        }
    }
}
