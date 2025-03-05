using TMPro;
using UnityEngine;

public class health : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Health: " + GameManager.Instance.health.ToString();
    }

    void Update()
    {
        text.text = "Health: " + GameManager.Instance.health.ToString();
    }
}
