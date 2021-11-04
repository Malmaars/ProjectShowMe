using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [Header("Level info")]
    [SerializeField] private int lengthMap;
    [SerializeField] private float distanceBetweenNotes;
    [Range(0, 100)]
    [SerializeField] private float noteSpawnChance;
    [SerializeField] private float widthMap;

    [Header("Notes")]
    [SerializeField] private List<GameObject> notes = new List<GameObject>();
    private Vector3 newNotePos;
    private Vector3 lastNotePos;

    private void Start()
    {
        InitiateNotes();
    }

    private void InitiateNotes()
    {
        for (int i = 0; i <= lengthMap; i++)
        {
            newNotePos = GetNewPos();

            if(Random.Range(0, 100) < noteSpawnChance)
            {
                InstantiateNote();
            }
        }
    }

    private Vector3 GetNewPos()
    {
        int randomX = Random.Range(-1, 2);
        Vector3 currentNotePos = new Vector3(randomX * widthMap, 0f, lastNotePos.z + distanceBetweenNotes);
        lastNotePos = currentNotePos;
        return currentNotePos;
    }

    private void InstantiateNote()
    {
        Instantiate(notes[Random.Range(0, notes.Count)], new Vector3(newNotePos.x, -4f, newNotePos.z), Quaternion.identity);
    }
}