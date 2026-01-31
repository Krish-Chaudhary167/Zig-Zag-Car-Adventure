using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnner : MonoBehaviour
{
    public GameObject platform;
    public Transform lastPlatform;
    Vector3 lastPos;
    Vector3 newPos;
    public bool stop;
    public float spawnTime = 0.08f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = lastPlatform.position;
        StartCoroutine(PlatformSpawn());
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GeneratePosition()
    {
        newPos = lastPos;
        int rand = Random.Range(0, 2);
        if (rand > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
        
    }
    IEnumerator PlatformSpawn()
    {
        while (!stop)
        {
            GeneratePosition();
            Instantiate(platform, newPos, Quaternion.identity);
            lastPos = newPos;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
