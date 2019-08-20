using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptController : MonoBehaviour
{

    public List<GameObject> Upgrades;

    public GameObject CurrentUser;

    public List<GameObject> ToHire;

    public bool Buyable(GameObject buying)
    {
        return buying.GetComponent<MinionContoller>().hireCost < CurrentUser.GetComponent<UserController>().Gold;
    }

    public void BuyMinion(GameObject buying)
    {
        if(Buyable(buying)) { CurrentUser.GetComponent<UserController>().Hired.Add(buying);  } else { /*relay to user or just notify that they lack the funds*/ }
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
