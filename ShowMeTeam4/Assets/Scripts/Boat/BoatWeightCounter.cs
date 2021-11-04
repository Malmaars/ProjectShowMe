using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWeightCounter : MonoBehaviour
{
    [SerializeField] private BoatBalance boatBalance;

    [SerializeField] private bool isLeft;

    public List<Collider> playerInCollider = new List<Collider>();

    private List<Collider> GetColliders() 
    { 
        return playerInCollider; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerInCollider.Contains(other)) playerInCollider.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        playerInCollider.Remove(other);
    }

    private void Update()
    {
        boatBalance.UpdateWeight(playerInCollider.Count, isLeft);
    }
}