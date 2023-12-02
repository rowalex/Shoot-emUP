using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int hp;



    public int HP
    {
        get
        {
            return hp;
        }
    }
    
    [SerializeField] private GameObject Explosion;


    public void GetDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            StartCoroutine(Destraction());
        }
    }


    IEnumerator Destraction()
    {   
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        yield return null;
    }
}
