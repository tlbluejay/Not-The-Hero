using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    private ClickManager cm = new ClickManager();

    public bool inCombat = true;
    private readonly int MIN_BASE_DMG = 5, MAX_BASE_DMG = 15;
    private int currentTurn;

    private bool turnTaken;
    private List<EntityController> entities = new List<EntityController>();
    private EntityController currentEntity;

    // Start is called before the first frame update
    void Start()
    {
        entities.AddRange(GetComponentsInChildren<MinionContoller>());
        entities.AddRange(GetComponentsInChildren<EnemyController>());
        currentTurn = 0;
        currentEntity = entities[currentTurn % entities.Count];
        turnTaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnTaken)
        {
            currentEntity = entities[currentTurn % entities.Count];
            turnTaken = false;
        }
        else
        {
            if(currentEntity is MinionContoller)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject obj = cm.OnMouseDown();
                    if (obj != null)
                    {
                        MinionContoller minionContoller = obj.GetComponent<MinionContoller>();
                        EnemyController enemyController = obj.GetComponent<EnemyController>();
                        if (minionContoller != null || enemyController != null)
                        {
                            if (minionContoller != null)
                            {
                                Debug.Log(minionContoller.name + "\n" + entities[currentTurn % entities.Count].Health + " / " + entities[currentTurn % entities.Count].maxHealth);
                                minionContoller.ChangeHealth(Mathf.RoundToInt(Random.Range(MIN_BASE_DMG, MAX_BASE_DMG) * currentEntity.ActionModifier()));
                                Debug.Log(minionContoller.name + "\n" + entities[currentTurn % entities.Count].Health + " / " + entities[currentTurn % entities.Count].maxHealth);
                            }
                            else
                            {
                                Debug.Log(enemyController.name + "\n" + entities[currentTurn % entities.Count].Health + " / " + entities[currentTurn % entities.Count].maxHealth);
                                enemyController.ChangeHealth(Mathf.RoundToInt(Random.Range(-MAX_BASE_DMG, -MIN_BASE_DMG) * currentEntity.ActionModifier()));
                                Debug.Log(enemyController.name + "\n" + entities[currentTurn % entities.Count].Health + " / " + entities[currentTurn % entities.Count].maxHealth);
                            }
                            turnTaken = true;
                            currentTurn++;
                        }
                    }
                }
            }
            else
            {
                Debug.Log(entities[(currentTurn + 1) % entities.Count].name + "\n" + entities[currentTurn % entities.Count].Health + " / " + entities[currentTurn % entities.Count].maxHealth);
                entities[(currentTurn + 1) % entities.Count].ChangeHealth(Mathf.RoundToInt(Random.Range(-MAX_BASE_DMG, -MIN_BASE_DMG) * currentEntity.ActionModifier()));
                Debug.Log(entities[(currentTurn + 1) % entities.Count].name + "\n" + entities[currentTurn % entities.Count].Health + " / " + entities[currentTurn % entities.Count].maxHealth);
                turnTaken = true;
                currentTurn++;
            }
        }
    }

}
