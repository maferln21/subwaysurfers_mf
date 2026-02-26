using UnityEngine;
using UnityEngine.UI;
public class PointsUI : MonoBehaviour
{
    [SerializeField]
    private Text text;
    public void UpdatePoints(int points)
    {
        text.text = points.ToString();
    }
}
