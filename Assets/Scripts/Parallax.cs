using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ListWrapper
{
    public List<GameObject> myList;

    public int Count
    {
        get { return myList.Count; }
    }

    public GameObject GetItem(int index)
    {
        return myList[index];
    }
}

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;
    [SerializeField] float edgeX;

    [SerializeField] List<ListWrapper> parallaxGameObjects;

    [SerializeField] List<float> parallaxSpeed;

    [SerializeField] List<float> parallaxSpawnGap;

    


    private void Start()
    {

       foreach (var parallax in parallaxGameObjects)
        {
          StartCoroutine(ParallaxSpawn(parallaxGameObjects.IndexOf(parallax)));
        }
    }

    IEnumerator ParallaxSpawn(int layer)
    {
        while (true)
        {
            yield return new WaitForSeconds(parallaxSpawnGap[layer]);
            GameObject parall = Instantiate(parallaxGameObjects[layer].GetItem(Random.Range(0, parallaxGameObjects[layer].Count )),
                new Vector2(Random.Range(-edgeX, edgeX), top.position.y),
                Quaternion.identity);


            parall.GetComponent<ParallaxObject>().SetSpeed(parallaxSpeed[layer], bottom.position.y);
        }
        
    }


}
