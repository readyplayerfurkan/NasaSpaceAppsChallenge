using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MOVE : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float moveSpeed = 5f; // Hareket h�z�
    [SerializeField] private Joystick joystick;   // Unity'deki Joystick bile�eni referans�
    [SerializeField] private TMP_Text timerText;  // Zamanlay�c� UI bile�eni

    public static int score = 0; // score public ve static olmal�

    private Rigidbody2D rb;
    private Vector2 movement;
    private float timer = 15f;  // Ba�lang�� zaman� (�rnek olarak 60 saniye)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Timer s�f�rlanana kadar �al��t�r
        if (timer > 0)
        {
            // Zamanlay�c�y� g�ncelle
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
            }
            timerText.text = "Time: " + FormatTime(timer);
        }
        else
        {
            // Game Over logic
            
        }

        scoreText.text = "Score: " + score.ToString();

        // Joystick y�nlerini almak
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        // Karakterin rotasyonunu joystick y�n�ne g�re ayarla
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg; // A�� hesapla
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f)); // Rotasyonu uygula
        }
    }

    private void FixedUpdate()
    {
        // Karakterin hareketi fizik tabanl� olarak uyguland�
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Zaman� dakika:saniye olarak formatlamak i�in yard�mc� fonksiyon
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yildiz")
        {
            score += 10;
        }
        if (collision.gameObject.tag == "art�")
        {
            score++;
        }
        if (collision.gameObject.tag == "eksi")
        {
            score -= 5;
        }
    }
}
