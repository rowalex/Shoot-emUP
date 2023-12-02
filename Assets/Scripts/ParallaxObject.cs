using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour
{
    float speed;
    float bot;

    public void SetSpeed(float speed, float bot)
    {
        this.speed = speed;
        this.bot = bot;
    }

    Vector2 dir;

    private void Start()
    {
        dir = Vector3.down; 
    }

    private void Update()
    {

        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.position.y <= bot)
        {
            Destroy(gameObject);
        }
    }
}
