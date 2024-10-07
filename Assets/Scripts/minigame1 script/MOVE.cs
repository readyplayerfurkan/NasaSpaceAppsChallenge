using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MOVE : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float moveSpeed = 5f; // Hareket hýzý
    [SerializeField] private Joystick joystick;   // Unity'deki Joystick bileþeni referansý
    [SerializeField] private TMP_Text timerText;  // Zamanlayýcý UI bileþeni

    public static int score = 0; // score public ve static olmalý

    private Rigidbody2D rb;
    private Vector2 movement;
    private float timer = 15f;  // Baþlangýç zamaný (örnek olarak 60 saniye)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Timer sýfýrlanana kadar çalýþtýr
        if (timer > 0)
        {
            // Zamanlayýcýyý güncelle
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

        // Joystick yönlerini almak
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        // Karakterin rotasyonunu joystick yönüne göre ayarla
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg; // Açý hesapla
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f)); // Rotasyonu uygula
        }
    }

    private void FixedUpdate()
    {
        // Karakterin hareketi fizik tabanlý olarak uygulandý
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Zamaný dakika:saniye olarak formatlamak için yardýmcý fonksiyon
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
        if (collision.gameObject.tag == "artý")
        {
            score++;
        }
        if (collision.gameObject.tag == "eksi")
        {
            score -= 5;
        }
    }
}
