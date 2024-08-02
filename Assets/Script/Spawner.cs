using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minThres;
    [SerializeField] float MaxThres;
    private void Start()
    {
        StartCoroutine(ObjectSpawn());
    }
    IEnumerator ObjectSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minThres, MaxThres);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(objects[Random.Range(0, objects.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }

}
