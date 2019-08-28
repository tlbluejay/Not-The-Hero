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
    private Vector3 startPosition;
    private bool actionStarted = false;
    public GameObject target;
    private float animSpeed = 5f;

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
        attack.Type = "Enemy";
        attack.AttackersName = enemy.name;
        attack.Attacker = this.gameObject;
        attack.Target = bsm.MinionsInBattle[Random.Range(0, bsm.MinionsInBattle.Count)];
        bsm.CollectActions(attack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        Vector3 targetPosition = new Vector3(target.transform.position.x - 1.5f, target.transform.position.y, target.transform.position.z);
        while(MoveTowardsTarget(targetPosition))
        {
            yield return null;
        }

        actionStarted = false;

        currentCooldown = 0f;
        currentState = TurnState.Processing;
    }

    private bool MoveTowardsTarget(Vector3 targetLocation)
    {
        return targetLocation != (transform.position = Vector3.MoveTowards(transform.position, targetLocation, animSpeed * Time.deltaTime)); ;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.Processing;
        bsm = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startPosition = transform.position;
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
                ChooseAction();
                currentState = TurnState.Waiting;
                break;
            case TurnState.Waiting:
                break;
            case TurnState.Action:
                StartCoroutine(TimeForAction());
                break;
            case TurnState.Dead:
                break;
            default:
                break;
        }
    }
}
