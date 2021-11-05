using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentAbilities : MonoBehaviour
{
    [SerializeField] private BoatMovement boatMovement;

    [Header("JUMP")]
    [SerializeField] private float jumpForce;

    [Header("SLOMO")]
    [Range(0, 1)]
    [SerializeField] private float slomoAmount;

    [Header("SPEEDUP")]
    [Range(1, 5)]
    [SerializeField] private float speedupAmount;

    public void JumpAbility()
    {
        boatMovement.Jump(jumpForce);
    }

    public void SlomoAbility()
    {
        boatMovement.Slomo(slomoAmount);
    }

    public void SpeedupAbility()
    {
        boatMovement.Speedup(speedupAmount);
    }
}
