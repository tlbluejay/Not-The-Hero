using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public const int MIN_RANK = 0, MAX_RANK = 5;

    public int maxHealth;

    public new string name;

    public int speed;
    public int accuracy;
    public int defense;

    public int experience;
    public int rank;

    private int currentHealth;
    public int Health
    {
        get
        {
            return currentHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual float DefenseModifier()
    {
        return 1.0f;
    }

    public virtual float ActionModifier()
    {
        return 1.0f;
    }

    public void ChangeHealth(int diff)
    {
        currentHealth = Mathf.Clamp(currentHealth + diff, 0, maxHealth);
    }
}
