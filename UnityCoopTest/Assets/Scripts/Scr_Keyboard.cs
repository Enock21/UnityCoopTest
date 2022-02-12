using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Keyboard : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField keyboard;
    [SerializeField]
    private Button enterButton;
    [SerializeField]
    private Button cancelButton;
    private bool isFocused;
    private bool isSelected;


    void Update()
    {

        isFocused = keyboard.isFocused;
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            InputFunction();
            ToggleActivationKeyBoard();
        }
        SetPlayerMove();

    }


    void InputFunction()
    { 
        string text = keyboard.text;
        if (CheckText(text))
            Scr_InputController.NewInput(text);
        else if(text != "")
            print("Texto digitado não compativel");
        keyboard.text = "";
        return;
        
        
    }

    //Se o teclado estiver no foco para digitação, o player não pode se mover
    void SetPlayerMove()
    {
        bool canPlayerMove = true;
        if (keyboard.isFocused)
        {
            canPlayerMove = false;
        }
        Scr_PlayerSettings.CanPlayerMove = canPlayerMove;
    }

    void ToggleActivationKeyBoard()
    {
        if (!isSelected && !isFocused)
        {
            ActiveKeyboard();
        }
        if (!isFocused && isSelected)
        {
            DesactiveKeyboard();
        }
    }

    void ActiveKeyboard()
    {
        keyboard.ActivateInputField();
    }
    public void DesactiveKeyboard()
    {
        /*keyboard.interactable = false;
        keyboard.interactable = true;*/
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    public void IsSelected()
    {
        isSelected = true;
    }

    public void IsDeselected()
    {
        isSelected = false;
    }

    public void OnClickEnterButton()
    {
        InputFunction();
    }

    public void OnClickCancelButton()
    {
        keyboard.text = "";
        DesactiveKeyboard();
    }

    private bool CheckText(string text)
    {
        string[] textSplited = text.Split('.');
        if (textSplited.Length != 2 || textSplited[0].Length == 0 || textSplited[1].Length == 0)
            return false;

        if (textSplited[1].Contains("(") && textSplited[1].Contains(")"))
            return true;
        else
            return false;
    }
}
