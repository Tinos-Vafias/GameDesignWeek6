using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Final Score: " + GameManager.Instance.score.ToString();
    }
}
