using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] Party;

    public static Player instance;

    public Vector2[] positions;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        if(Party == null)
        {
            Party = new GameObject[4];
            for(int i = 0; i < Party.Length; i++)
            {
                GameObject minion = Instantiate(Party[i], positions[i], Quaternion.identity);
                minion.name = $"Minion {i}";
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
