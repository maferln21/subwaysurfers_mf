using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private int points;
    [SerializeField]
    private float pointsInterval = 0.5f;
    [SerializeField]
    private UnityEvent<int> onPointsChanged;
    private Coroutine pointsCoroutine;
    [SerializeField]
    private Text[] pointsTexts;
    public void StartCouting()
    {
        points = 0;
        onPointsChanged?.Invoke(points);
        pointsCoroutine = StartCoroutine(CountPoints());
    }
    public void StopCounting()
    {
        if (pointsCoroutine != null)
        {
            StopCoroutine(pointsCoroutine);
            pointsCoroutine = null;
        }
    }
    private IEnumerator CountPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(pointsInterval);
            points++;
            onPointsChanged?.Invoke(points);
        }
    }
    public void CalculateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (points > highScore)
        {
            PlayerPrefs.SetInt("HigScore", points);
            PlayerPrefs.Save();
        }
        else
        {
            points = highScore;
        }
        UpdatePointsTexts();
    }
    private void UpdatePointsTexts()
    {
        foreach (var text in pointsTexts)
        {
            text.text = points.ToString();
        }
    }

    
}
