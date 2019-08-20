using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionContoller : EntityController
{
    private const int RANK_0 = 0, RANK_1 = 40, RANK_2 = 80, RANK_3 = 160, RANK_4 = 320, RANK_5 = 640, ACTION_MODIFIER_DIVIDER = 6;

    private const int MIN_HEALTH_UPGRADE = 2, MAX_HEALTH_UPGRADE = 7,
    MIN_ACCURACY_UPGRADE = 1, MAX_ACCURACY_UPGRADE = 4,
    MIN_SPEED_UPGRADE = 0, MAX_SPEED_UPGRADE = 3,
    MIN_DEFENSE_UPGRADE = 0, MAX_DEFENSE_UPGRADE = 4;

    public int hireCost;

    private bool rankedUp = false;
    public bool RankedUp
    {
        get
        {
            return rankedUp;
        }
    }

    private int weaponRank = 0;
    public int WeaponRank
    {
        get
        {
            return weaponRank;
        }
    }

    private int armorRank = 0;
    public int ArmorRank
    {
        get
        {
            return armorRank;
        }
    }

    public override float DefenseModifier()
    {
        return base.DefenseModifier() + armorRank / ACTION_MODIFIER_DIVIDER;
    }

    public override float ActionModifier()
    {
        return base.ActionModifier() + weaponRank / ACTION_MODIFIER_DIVIDER;
    }

    public void UpgradeArmor()
    {
        armorRank = Mathf.Clamp(armorRank + 1, MIN_RANK, MAX_RANK);
    }

    public void UpgradeWeapon()
    {
        weaponRank = Mathf.Clamp(weaponRank + 1, MIN_RANK, MAX_RANK);
    }

    public void ChangeExperience(int diff)
    {
        experience = Mathf.Clamp(experience + diff, experience, RANK_5);
    }

    public void RankUp()
    {
        rankedUp = false;
        rank = Mathf.Clamp(rank + 1, MIN_RANK, MAX_RANK);
        maxHealth = Mathf.Clamp(maxHealth + Random.Range(MIN_HEALTH_UPGRADE, MAX_HEALTH_UPGRADE), 0, int.MaxValue);
        accuracy = Mathf.Clamp(accuracy + Random.Range(MIN_ACCURACY_UPGRADE, MAX_ACCURACY_UPGRADE), 0, int.MaxValue);
        speed = Mathf.Clamp(speed + Random.Range(MIN_SPEED_UPGRADE, MAX_SPEED_UPGRADE), 0, int.MaxValue);
        defense = Mathf.Clamp(defense + Random.Range(MIN_DEFENSE_UPGRADE, MAX_DEFENSE_UPGRADE), 0, int.MaxValue);
    }

    private bool CheckForRankUp()
    {
        if (experience >= RANK_1 && rank < 1)
        {
            return true;
        }
        else if (experience >= RANK_2 && rank < 2)
        {
            return true;
        }
        else if (experience >= RANK_3 && rank < 3)
        {
            return true;
        }
        else if (experience >= RANK_4 && rank < 4)
        {
            return true;
        }
        else if (experience >= RANK_5 && rank < MAX_RANK)
        {
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
