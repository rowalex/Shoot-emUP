using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text hp;
    [SerializeField] Button restart;

    private Unit player;
    private float time;

    private void Awake()
    {
        restart.onClick.AddListener(Restart); 
        player = GameObject.Find("Player").GetComponent<Unit>();
    }


    private void Update()
    {
        if (player.HP > 0)
        {
            score.text = "Score: " + (int)time;
            time += Time.deltaTime;
            hp.text = "HP: " + player.HP;
        }
        else 
        {
            hp.text = "Dead";
        }
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
