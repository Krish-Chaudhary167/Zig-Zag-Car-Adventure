using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject starBlast, diamondBlast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Star")
            {
                GameManager.Instance.GetStar();
                Instantiate(starBlast, transform.position, Quaternion.identity);
            }
            if (gameObject.tag == "Diamond")
            {
                GameManager.Instance.GetDiamond();
                Instantiate(diamondBlast, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

}
