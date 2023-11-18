using UnityEngine;
using UnityEngine.SceneManagement;

public class PointSystem : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] GUIStyle _pointStyle;

    int _coinCount = 0;

    void Start()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        _coinCount = coins.Length;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), _score.ToString(), _pointStyle);
    }

    public void AddPoint()
    {
        _score++;

        if (_score >= _coinCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}