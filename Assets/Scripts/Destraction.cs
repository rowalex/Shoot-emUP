using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destraction : MonoBehaviour
{
    [SerializeField] private float time;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            Destroy(gameObject);
        }
    }
}
