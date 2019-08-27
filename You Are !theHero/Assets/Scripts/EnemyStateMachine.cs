using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyController enemy;

    private BattleStateMachine bsm;

    public enum TurnState
    {
        Processing,
        ChooseAction,
        Waiting,
        Action,
        Dead
    }

    public TurnState currentState;

    private float currentCooldown = 0f;
    private float maxCooldown = 7f;

    void updateProgressBar()
    {
        currentCooldown = currentCooldown + Time.deltaTime;
        if (currentCooldown >= maxCooldown)
        {
            currentState = TurnState.ChooseAction;
        }
    }

    void ChooseAction()
    {
        TurnHandler attack = new TurnHandler();
        attack.AttackersName = enemy.name;
        attack.Attacker = this.gameObject;
        attack.Target = bsm.MinionsInBattle[Random.Range(0, bsm.MinionsInBattle.Count)];
        bsm.CollectActions(attack);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.Processing;
        bsm = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case TurnState.Processing:
                updateProgressBar();
                break;
            case TurnState.ChooseAction:
                break;
            case TurnState.Waiting:
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
