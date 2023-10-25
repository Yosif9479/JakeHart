using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class AllPoints : MonoBehaviour
{
    public static AllPoints Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
    //Freelance Code
    public List<GameObject> LastPoints = new List<GameObject>(); // Здесь точки, находящиеся в самом конце уже пройденного уровня
    //public List<GameObject> StartPoints; // Здесь точки, находящиеся в самом начале нового уровня
    public List<bool> LevelComplete = new List<bool>();
    //
}
