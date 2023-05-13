using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private AudioClip _deathSound;

    [SerializeField] private TextMeshProUGUI _text;
    private Rigidbody2D _rb;
    
    public int score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Напишите логику уничтожения зомби тут

        if (collision.gameObject.CompareTag(GlobalConstants.SKULL_TAG) || collision.relativeVelocity.y > 5)
        {
            Die();
            DecreaseScore();
        }
    }

    private void Awake()
    {
        score = Convert.ToInt32(_text.text);
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rb.rotation > 30 || _rb.rotation < -30)
        {
            Die();
            DecreaseScore();
        }
        
    }

    private void Die()
    {
        // Создаем эффект "взрыв" на месте убитого зомби.
        CreateExplosion();
        // ПРоигрываем звук смерти зомби.
        PlayDeathSound();
        // Разрушаем объект зомби.
        Destroy(gameObject);
    }

    private void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(_deathSound, transform.position);
    }

    private void CreateExplosion()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }

    private void DecreaseScore()
    {
        score = Convert.ToInt32(_text.text);
        score--;
        _text.text = score.ToString();
    }
}