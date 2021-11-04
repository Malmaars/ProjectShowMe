using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NoteInfo", menuName = "Scripts/Notes/NotesInfo")]
public class NoteInfo : ScriptableObject
{
    [Header("Wave Effect")]
    public float moveAmount;
    public float moveIntensity;

    [Header("Move Up")]
    public float rangeToMoveUp;
    public float amountToMoveUp;
    public float animationLength;
}