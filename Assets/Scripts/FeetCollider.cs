using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour
{
    public GameObject player;
    PlayerControlling parPlayer;

    // Start is called before the first frame update
    void Start()
    {
        parPlayer = GetComponentInParent<PlayerControlling>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") && parPlayer.IsJumping)
        {
            parPlayer.IsJumping = false;
        }
        if (other.gameObject.CompareTag("Platform") && parPlayer.IsJumping)
        {
            parPlayer.IsJumping = false;
            player.transform.parent = other.gameObject.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        parPlayer.IsJumping = true;
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
}
