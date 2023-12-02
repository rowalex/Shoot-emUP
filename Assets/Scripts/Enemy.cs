using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    List<Transform> patrolPoints;
    private GameObject player;

    int patrolIndex = 0;

    [SerializeField] float speed;
    [SerializeField] private float shootingGap;
    [SerializeField] GameObject bullet;

    private void Awake()
    {
        patrolPoints = new List<Transform>();

        var parent = GameObject.Find("EnemyPatrolPoints").transform;

        foreach(Transform child in parent)
        {
            patrolPoints.Add(child);
        }


        player = GameObject.Find("Player");

        patrolIndex = Random.Range(0, patrolPoints.Count);

        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {

        while (true)
        {
            yield return new WaitForSeconds(shootingGap);
            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
            bul.GetComponent<Bullet>().SetParams(tag, (player.transform.position - transform.position).normalized, 12);
            bul.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        }
    }

    private void Update()
    {
        Vector2 dir = patrolPoints[patrolIndex].position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (dir.magnitude <= 0.2f )
        {
            patrolIndex = Random.Range(0, patrolPoints.Count);
        }
    }


}
