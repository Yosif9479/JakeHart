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
    public List<GameObject> LastPoints = new List<GameObject>(); // ����� �����, ����������� � ����� ����� ��� ����������� ������
    //public List<GameObject> StartPoints; // ����� �����, ����������� � ����� ������ ������ ������
    public List<bool> LevelComplete = new List<bool>();
    //
}
