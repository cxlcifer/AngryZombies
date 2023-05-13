using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public LineRenderer[] LineRenderers;
    public Transform[] stripPositions;
    public Transform Center;
    public Transform IdlePosition;

    public Vector3 currentPosition;
    public float maxLength;

    public bool isMouseDown;

    [SerializeField] private Trajectory _trajectory;

    [SerializeField] private Skull _skullPrefab;
    private Skull _skull;

    [SerializeField] private float pushForce;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    public Vector2 force;
    private float distance;


    void Start()
    {
        CreateSkull();
        LineRenderers[0].positionCount = 2;
        LineRenderers[1].positionCount = 2;

        LineRenderers[0].SetPosition(0, stripPositions[0].position);
        LineRenderers[1].SetPosition(0, stripPositions[1].position);
    }

    void Update()
    {
        if (isMouseDown)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;
            
            currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition = Center.position + Vector3.ClampMagnitude(currentPosition - Center.position, maxLength);
            _skull.transform.position = currentPosition;
            SetStrips(currentPosition);
            _trajectory.UdateDots(_skull.pos, force);
        }
        else
        {
            ResetStrips();
        }
    }

    void CreateSkull()
    {
       
        _skull = Instantiate(_skullPrefab,IdlePosition);
        _skull.DeactiveRb();
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        _skull.DeactiveRb();
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _trajectory.Show();
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        _skull.ActiveRb();
        _skull.Push(force);
        _trajectory.Hide();
    }

    void ResetStrips()
    {
        currentPosition = IdlePosition.position;
            SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        LineRenderers[0].SetPosition(1, position);
        LineRenderers[1].SetPosition(1, position);
    }
}