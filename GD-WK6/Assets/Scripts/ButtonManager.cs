using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class ButtonManager : MonoBehaviour
{
    //list of buttons 
    public enum ButtonType
    {
        Combo,
        Shake
    }

    //Add buttons in inspector, access via the enum
    public Button[] buttons;

    private void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is missing! Make sure it persists from GameStart.");
            return;
        }

        buttons[(int)ButtonType.Combo].onClick.AddListener(GameManager.Instance.ToggleCombo);
        buttons[(int)ButtonType.Shake].onClick.AddListener(GameManager.Instance.ToggleShake);




        Debug.Log("Buttons successfully linked to GameManager.");
    }
}