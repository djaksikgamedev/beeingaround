using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text pointsText;
    public Text HSText;
    public int points;
    public int highScore;
    public GameObject endGamePanel;
    public float enemySpeed;
    public static GameController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1;
    }
    private void OnEnable()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        HSText.text = "High Score : " + highScore;
    }

    public void AddPoint(int amount)
    {
        points += amount;
        pointsText.text = "Points : " + points;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        if (highScore < points)
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (points >= highScore)
        {
            HSText.text = "High Score : " + points;
        }

        switch (GameController.instance.points)
        {
            case 10:
            case 15:
                enemySpeed = 3f;
                break;
            case 20:
            case 30:
                enemySpeed = 4f;
                break;
            case 35:
            case 40:
                enemySpeed = 5f;
                break;
            case 45:
            case 50:
                enemySpeed = 6f;
                break;
            case 55:
            case 60:
                enemySpeed = 7f;
                break;
            case 65:
            case 70:
                enemySpeed = 8f;
                break;
            case 75:
            case 80:
                enemySpeed = 9f;
                break;
            case 85:
            case 90:
                enemySpeed = 10f;
                break;
            default:
                break;
        }
    }
}