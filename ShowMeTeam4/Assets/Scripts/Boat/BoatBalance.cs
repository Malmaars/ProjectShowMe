using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBalance : MonoBehaviour
{
    [SerializeField] private BoatMovement boatMovement;

    [SerializeField] private float minWeightToMoveBoat;

    private int leftWeight;
    private int rightWeight;

    private int totalWeight;
    private float force;

    private void Update()
    {
        totalWeight = leftWeight + rightWeight;

        if(leftWeight > rightWeight)
        {
            force = leftWeight - rightWeight;
        }
        else
        {
            force = rightWeight - leftWeight;
        }
            

        if (totalWeight < minWeightToMoveBoat)
        {
            boatMovement.ChangeDirection(0, force);
            return;
        }

        if(leftWeight > rightWeight)
        {
            boatMovement.ChangeDirection(-1, force);
            return;
        }

        if(rightWeight > leftWeight)
        {
            boatMovement.ChangeDirection(1, force);
            return;
        }

        if (rightWeight == leftWeight)
        {
            boatMovement.ChangeDirection(0, force);
        }
    }

    public void UpdateWeight(int amount, bool isLeftSide)
    {
        if (isLeftSide)
            leftWeight = amount;
        else
            rightWeight = amount;
    }
}