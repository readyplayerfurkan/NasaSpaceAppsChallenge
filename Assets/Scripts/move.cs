using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText; 
    public float speed = 8f;
    public static int score;
    private Vector3 direction = Vector3.right;
    private SpriteRenderer spriteRenderer;
    private float timer = 301f; // Set the timer to 5 minutes (300 seconds)

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Başlangıçta metni belirle
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + FormatTime(timer); // Update timer text with formatted time

            if (Input.GetMouseButtonDown(0))
            {
                if (direction == Vector3.right)
                {
                    direction = Vector3.left;
                    spriteRenderer.flipX = false;
                }
                else
                {
                    direction = Vector3.right;
                    spriteRenderer.flipX = true;
                }
            }

            transform.Translate(direction * Time.deltaTime * speed);
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            // Game Over logic
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SolDuvar")
        {
            direction = Vector3.right;
            spriteRenderer.flipX = true;
        }
        if (collision.gameObject.tag == "Duvar")
        {
            direction = Vector3.left;
            spriteRenderer.flipX = false;
        }

        if (collision.gameObject.tag == "tezek")
        {
            score -= 5;
        }
        if (collision.gameObject.tag == "TRASH")
        {
            score++;
        }
        if (collision.gameObject.tag == "gold")
        {
            score += 10;
        }
    }

    // Helper function to format time as minutes:seconds
    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
