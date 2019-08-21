using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptController : MonoBehaviour
{

    public List<GameObject> Upgrades;

    public UserController CurrentUser;

    public List<MinionController> ToHire;

    public bool Buyable(GameObject buying)
    {
        return buying.GetComponent<MinionController>().hireCost < CurrentUser.Gold;
    }

    public void BuyMinion(GameObject buying)
    {
        if(Buyable(buying)) { CurrentUser.Hired.Add(buying);  } else { /*relay to user or just notify that they lack the funds*/ }
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
