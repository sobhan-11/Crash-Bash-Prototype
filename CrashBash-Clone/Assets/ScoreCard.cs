using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private Image image;


    public void SetScore(int _score)
    {
        scoreTxt.text = _score.ToString();
    }

    public void SetColorImage(Color color)
    {
        image.color = color;
    }
}
