using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class YouWin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private UnityEvent _event;

    void Update()
    {
        if (Convert.ToInt32(_text.text) == 0)
        {
            _event?.Invoke();
        }
    }
}
