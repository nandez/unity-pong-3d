using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float lifeSpan = 2f;

    private float remaining;

    void Start()
    {
        remaining = lifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        remaining -= Time.deltaTime;
        if (remaining <= 0)
            Destroy(gameObject);
    }
}
