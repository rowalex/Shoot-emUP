using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float edgeX;
    [SerializeField] float edgeY;
    [SerializeField] float y_Offset;
    [SerializeField] float shootsGap;
    [SerializeField] Transform shootPos;
    [SerializeField] GameObject bullet;

    private void Start()
    {
        

        StartCoroutine(Shooting());
    }


    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootsGap);

            GameObject bul = Instantiate(bullet , shootPos.position , Quaternion.identity);

            bul.GetComponent<Bullet>().SetParams(tag, Vector2.up, 15);

            yield return null;
        }

    }

    private void Update()
    {

        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");


        float deltaX = hor * speed * Time.deltaTime;

        if (edgeX > Mathf.Abs(transform.position.x + deltaX))
        {
            transform.Translate(Vector2.right * deltaX);
        }

        float deltaY = vert * speed * Time.deltaTime;

        if(edgeY > Mathf.Abs(transform.position.y - y_Offset + deltaY))
        {
            transform.Translate(Vector2.up * deltaY);
        }

    }



}
