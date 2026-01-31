using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platformBlast;
    public GameObject diamond, star;
    // Start is called before the first frame update
    void Start()
    {
        int randNumber = Random.Range(1, 21);
        Vector3 tempPos = transform.position;
        tempPos.y += 1f;
        if(randNumber < 4)
        {
            Instantiate(star, tempPos, star.transform.rotation);
        }
        if(randNumber == 7)
        {
            Instantiate(diamond, tempPos, diamond.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Invoke("FallDown", 0.3f);
        }
    }
    
    private void FallDown()
    {
        Instantiate(platformBlast, transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 0.5f);
    }
}
