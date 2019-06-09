using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum Color
    {
        WHITE, BLACK, YELLOW, RED
    }

    public Rigidbody2D rigidbody;
    public Color color;
    public bool toDelete;

    private const float G = 3f;
    public static List<Ball> gravitySources;

    public Vector3 startPos;
    public GameObject winObj;
    public GameObject loseObj;
    public GameObject kid;

    private void Awake()
    {
        startPos = transform.position;
        if (gravitySources == null)
        {
            gravitySources = new List<Ball>();
        }
        gravitySources.Add(this);
    }

    private void Update()
    {
        if (toDelete)
        {
            if (kid != null)
            {
                kid.transform.parent = null;
                kid.transform.position = transform.position;
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        gravitySources.Remove(this);
    }

    private void FixedUpdate()
    {
        foreach(Ball g in gravitySources)
        {
            if (g != this)
            {
                Vector2 direction = new Vector2(transform.position.x, transform.position.y) - new Vector2(g.transform.position.x, g.transform.position.y);
                float distance = Vector2.Distance(Vector2.zero, direction);
                float intensity = G * rigidbody.mass * g.rigidbody.mass / (distance * distance);

                rigidbody.AddForce(direction.normalized * -intensity);
            }
        }
    }
}
