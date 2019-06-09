using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float grabRadius = 3f;
    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Ball b in Ball.gravitySources)
        {
            if (Vector3.Distance(transform.position, b.transform.position) <= grabRadius)
            {
                if (b.color == Ball.Color.YELLOW || b.color == Ball.Color.RED)
                {
                    b.toDelete = true;
                } else if (b.color == Ball.Color.WHITE)
                {
                    b.transform.position = b.startPos;
                    b.rigidbody.velocity = Vector2.zero;
                } else
                {
                    //Black
                    int reds = 0;
                    int yellows = 0;
                    foreach(Ball c in Ball.gravitySources)
                    {
                        if (c.color == Ball.Color.YELLOW)
                        {
                            yellows++;
                        }
                        else if (c.color == Ball.Color.RED)
                        {
                            reds++;
                        }
                    }
                    if (reds == 0 || yellows == 0)
                    {
                        b.winObj.SetActive(true);
                    } else
                    {
                        b.loseObj.SetActive(true);
                    }
                    b.toDelete = true;
                }
            }
        }
    }
}
