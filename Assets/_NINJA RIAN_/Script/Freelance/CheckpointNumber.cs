using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointNumber : MonoBehaviour
{
    public static CheckpointNumber Instance;
    public int checkpointIndex;
    public GameObject thisCheckpoint;
    public void Start()
    {
        Instance = this;
        thisCheckpoint = gameObject;
    }
}
