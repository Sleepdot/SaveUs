using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    // Start is called before the first frame update
    public bool largeNow = false;
    public bool smallNow = false;
    public bool normalNow = true;

    void Start()
    {
        transform.localScale = new Vector3 (1, 1, 1);
    }

    public void largerPlayer()
    {
        if(largeNow == false)
        {
            transform.localScale = new Vector3 (1.25f, 1.25f, 1);
            largeNow = true;
            normalNow = false;
        }
    }

    public void smallerPlayer()
    {
        if(smallNow == false)
        {
            transform.localScale = new Vector3 (0.8f, 0.8f, 1);
            smallNow = true;
            normalNow = false;
        }
    }

    public void normalPlayer()
    {
        if(normalNow == false)
        {
            transform.localScale = new Vector3 (1, 1, 1);
            normalNow = true;
            largeNow = false;
            smallNow = false;
        }
    }
}
