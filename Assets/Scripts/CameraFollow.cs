using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed;
    [SerializeField]
    [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float change = 0f;
    int len;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
        len = myColors.Length;
    }

    // Update is called once per frame
     void Update()
    {
       if(target.position.y >= 0)
        {
            Follow();
        }

        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, myColors[colorIndex], lerpTime * Time.deltaTime);
        change = Mathf.Lerp(change, 1f, lerpTime * Time.deltaTime);
        if(change > 0.9f)
        {
            change = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
    private void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - offset;
        transform.position = Vector3.Lerp(currentPos, targetPos, followSpeed * Time.deltaTime);
    }
}
