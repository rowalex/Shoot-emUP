using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private string owner;
    private Vector2 dir;
    private float speed;

    

    public void SetParams(string owner, Vector2 dir, float speed)
    {
        this.owner = owner;
        this.dir = dir;
        this.speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != owner && collision.transform.GetComponent<Unit>())
        {
            collision.transform.GetComponent<Unit>().GetDamage(1);
            Destroy(gameObject);
            
        }
    }

    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

}
