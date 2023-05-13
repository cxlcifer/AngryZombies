using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int _dotsNumber;
    [SerializeField] private GameObject _dotsParent;
    [SerializeField] private GameObject _dotsPrefab;
    [SerializeField] private float dotSpacing;
    
    private Transform[] dotsList;
    private Vector2 pos;

    private float timeStamp;


    private void Start()
    {
        Hide();
        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[_dotsNumber];

        for (int i = 0; i < dotsList.Length; i++)
        {
            dotsList[i] = Instantiate(_dotsPrefab,null).transform;
            dotsList[i].parent = _dotsParent.transform;
        }
    }



    public void UdateDots(Vector3 ballPos, Vector2 force)
    {
        timeStamp = dotSpacing;


        for (int i = 0; i < dotsList.Length; i++)
        {
            pos.x = (ballPos.x + force.x * timeStamp);
            pos.y = (ballPos.y + force.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
        
    }

    public void Show()
    {
        _dotsParent.SetActive(true);
    }

    public void Hide()
    {
        _dotsParent.SetActive(false);
    }
    
}

