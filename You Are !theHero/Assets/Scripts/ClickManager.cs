using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager
{ 
    public GameObject OnMouseDown()
    {
        GameObject clicked = null;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider != null) { clicked = hit.collider.attachedRigidbody.gameObject; }
        Debug.Log(clicked);
        return clicked;//I think I know what to do          
    }
}
