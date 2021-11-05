using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private NoteInfo noteInfo;
    private Transform boat;
    private bool moved = false;
    private float newHight = 0f;
    private float randomNumber;

    private void Start()
    {
        boat = GameObject.Find("Boat").transform;
        randomNumber = Random.Range(0, 3);
        if (randomNumber < 1)
            newHight = 3f;
    }

    private void Update()
    {
        if (moved) return;
        if(Vector3.Distance(transform.position, boat.position) <= noteInfo.rangeToMoveUp)
        {
            moved = true;
            StartCoroutine(LerpPosition(new Vector3(transform.position.x, transform.position.y + noteInfo.amountToMoveUp + newHight, transform.position.z), noteInfo.animationLength));
        }
    }

    private IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * noteInfo.moveAmount) * noteInfo.moveIntensity * Time.deltaTime, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            Destroy(gameObject);
        }
    }
}