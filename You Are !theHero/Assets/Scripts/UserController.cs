using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{

    private new string name;
    public string Name
    {
        get
        {
            return name;
        }
    }

    private long gold;
    public long Gold
    {
        get
        {
            return gold;
        }
    }

    public const int PARTY_CAP_SIZE = 4;

    public List<GameObject> Party;

    public List<GameObject> Hired;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
