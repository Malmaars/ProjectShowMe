using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentInteract : MonoBehaviour
{
    [SerializeField] private InstrumentAbilities instrumentAbilities;

    [SerializeField] private float cooldownTime;

    private bool canInteract;
    public bool isPlaying = false;
    private GameObject player;

    [SerializeField] private Instrument instrument;
    private enum Instrument
    {
        Jump,
        Slomo,
        Speedup,
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (!canInteract) return;

        if (Input.GetKey(KeyCode.E) && !isPlaying)
        {
            if(instrument == Instrument.Jump)
                instrumentAbilities.JumpAbility();
            if (instrument == Instrument.Slomo)
                instrumentAbilities.SlomoAbility();
            if (instrument == Instrument.Speedup)
                instrumentAbilities.SpeedupAbility();

            isPlaying = true;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isPlaying = false;
    }
}
