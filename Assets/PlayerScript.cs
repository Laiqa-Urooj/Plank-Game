using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int speed = 10;
    public SphereScript sphereScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        // Move only on X-axis
        transform.position += new Vector3(x, 0, 0) * Time.deltaTime * speed;

        // Keep player inside the screen
        float clampedX = Mathf.Clamp(transform.position.x, -9f, 9f);

        transform.position = new Vector3(
            clampedX,
            transform.position.y,
            transform.position.z
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reload scene when collision occurs
        sphereScript.GameOver();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}