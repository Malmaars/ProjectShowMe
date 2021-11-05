using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public string horizontalNumber;
    public string verticalNumber;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + Input.GetAxis(horizontalNumber) * Time.deltaTime * moveSpeed, transform.localPosition.y, transform.localPosition.z + -Input.GetAxis(verticalNumber) * Time.deltaTime * moveSpeed);
    }
}
