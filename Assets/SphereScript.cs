using UnityEngine;
using UnityEngine.UI;
public class SphereScript : MonoBehaviour
{
    public Rigidbody rb;
    public Text score;
    public Text totalScoreText;
    public Text highestScoreText;
    public GameObject gameOverPanel;
    int count = 0;
    static int highestScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            respawn();//call the sphere to random location
            count += 5;
            score.text = count + "";
        }

    }
    public void respawn()
    {
        float x = Random.Range(-10, 10);
        float y = Random.Range(2, 7);
        transform.position = new Vector3(x, y, 0);
        float speed = Random.Range(5f, 10f);
        rb.linearVelocity = new Vector3(0, -speed, 0);
        // Changing ball's color on each respawn
        Renderer ballRenderer = GetComponent<Renderer>();
        int ColorChoice = Random.Range(0, 4);
        if (ColorChoice == 0)
        {
            ballRenderer.material.color = Color.blue;
        }
        else if (ColorChoice == 1)
        {
            ballRenderer.material.color = Color.red;
        }
        else if (ColorChoice == 2)
        {
            ballRenderer.material.color = Color.green;
        }
        else
        {
            ballRenderer.material.color = Color.yellow;
        }
    }
    public void GameOver()
    {
        totalScoreText.text = "Total Score: " + count;
        if (count > highestScore)
        {
            highestScore = count;
        }
        highestScoreText.text = "Highest Score: " + highestScore;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
