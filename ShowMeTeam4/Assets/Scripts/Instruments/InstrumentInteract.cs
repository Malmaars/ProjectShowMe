using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentInteract : MonoBehaviour
{
    [SerializeField] private GameObject interactPrompt;
    public bool canInteract;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.SetActive(true);
            canInteract = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
            canInteract = false;
        }
    }

    private void Update()
    {
        if (!canInteract) return;

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log(player + "is trying to play an instrument");
        }
    }
}
