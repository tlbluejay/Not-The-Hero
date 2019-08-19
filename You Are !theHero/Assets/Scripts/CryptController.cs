using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptController : MonoBehaviour
{

    public List<GameObject> Upgrades;


    public List<GameObject> ToHire;

    public bool Buyable(GameObject buying)
    {
        return /*buying.cost < User.gold*/ true;
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
