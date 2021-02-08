using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollision : MonoBehaviour
{
    private PlayerController parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        parent.IsJumping = false;
        //Debug.Log("The player has landed!");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        parent.IsJumping = true;
    }
}
