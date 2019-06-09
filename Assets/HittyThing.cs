using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittyThing : MonoBehaviour
{
    public Ball target;
    public SpriteRenderer sprite;

    public float minStrength = 0f;
    public float maxStrength = 20f;
    public float chargeTime = 1f;
    public float minDistance = 0.5f;
    public float maxDistance = 2f;

    private bool charging;
    private float timeCharged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            charging = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            charging = false;
            target.rigidbody.AddForce(GetDirection().normalized * GetStrength());
            timeCharged = 0f;
        }
        if (charging)
        {
            timeCharged += Time.deltaTime;
        }
        transform.position = target.transform.position - (Vector3)(GetDirection().normalized * GetDistance());
        float angle = Vector2.Angle(Vector2.right, GetDirection());
        transform.eulerAngles = new Vector3(0f, 0f, (GetDirection().y > 0f ? angle : 360f - angle));


        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private Vector2 GetDirection()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(pz.x - target.transform.position.x, pz.y - target.transform.position.y);
    }

    private float GetStrength()
    {
        return Mathf.Lerp(minStrength, maxStrength, timeCharged / chargeTime);
    }

    private float GetDistance()
    {
        return Mathf.Lerp(minDistance, maxDistance, timeCharged / chargeTime);
    }


}
