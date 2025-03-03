using UnityEngine;
using UnityEngine.UI;

public class ButtonColorToggle : MonoBehaviour
{
    private Image buttonImage;
    private Color defaultColor;
    private Color pressedColor = Color.red;
    private bool isPressed = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        defaultColor = buttonImage.color; // Store the original color
    }

    public void ToggleColor()
    {
        isPressed = !isPressed;
        buttonImage.color = isPressed ? pressedColor : defaultColor;
    }
}
