using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float gap;
    [SerializeField] List<Transform> points;
    private void Start()
    {
        StartCoroutine(Summon());   
    }

    IEnumerator Summon()
    {
        while (true)
        {
            yield return new WaitForSeconds(gap);
            Instantiate(enemy, points[Random.Range(0, points.Count)].position, Quaternion.identity);

        }
    }

}
