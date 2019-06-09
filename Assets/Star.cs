using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    private float scale;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(0.3f, 1f);
        transform.localScale *= scale;
        transform.position = new Vector3(Random.Range(-40f, 40f), Random.Range(-20f, 20f), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * scale * Time.deltaTime;
        if (transform.position.x < -40f)
        {
            transform.position += Vector3.right * 80f;
        }
    }
}
