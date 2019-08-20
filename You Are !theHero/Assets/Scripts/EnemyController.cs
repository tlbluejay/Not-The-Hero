using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityController
{
    private const int MIN_POWER = 5, MAX_POWER = 30, ACTION_MODIFIER_DIVIDER = 35;

    public int power;

    public int gold;

    public override float ActionModifier()
    {
        return base.ActionModifier() + power / ACTION_MODIFIER_DIVIDER;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
