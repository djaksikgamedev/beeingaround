using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScore : MonoBehaviour
{
    public Text score;
    public Text highScore;

    public void OnEnable()
    {
        score.text = "Score : " + GameController.instance.points;
        highScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}