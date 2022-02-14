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


        isFocused = keyboard.isFocused; //Conjfirma se o teclado est� focado ou n�o. 
        //Isso � importante principalmente para ativar ou desativar o teclado quando o jogador aperta o bot�o enter

        //Se o player apertar o bot�o enter, � chamada a classe input function, e a classe que muda o foco do teclado
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            InputFunction();
            ToggleActivationKeyBoard();
        }
        //Chama a classe respons�vel por definir se o player pode se mover ou n�o
        SetPlayerMove();

    }


    //Faz uma verifica��o simples para confirmar se h� pelo menos um . e os parenteses no texto digitado no teclado.
    //Caso positivo, envia o texto para a classe InputController.
    //Caso negativo, mostra uma mensagem de erro no console
    void InputFunction()
    { 
        string text = keyboard.text;
        if (CheckText(text))
            Scr_InputController.NewInput(text);
        else if(text != "")
            print("Texto digitado n�o compativel");
        keyboard.text = "";
        return;
        
        
    }

    //Se o teclado estiver no foco para digita��o, o player n�o pode se mover
    //Essa classe desabilida ou habilita a funcionalidade do jogador andar dependendo se o teclado est� em foco ou n�o
    void SetPlayerMove()
    {
        bool canPlayerMove = true;
        if (keyboard.isFocused)
        {
            canPlayerMove = false;
        }
        Scr_PlayerSettings.CanPlayerMove = canPlayerMove;
    }

    //Troca o status do foco do teclado. Se estiver sem foco, passa a ter, e se tiver passa a n�o ter
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

    //Faz uma checagem simples. Se o player digitou um ponto e os parenteses, ent�o o texto digitado � valido.
    //Vale a pena notar que n�o foi conferido se h� mais de um parenteses ou a ordem dos mesmos. Isso � algo que pode ser aprimorado
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

    public void SetSelected()
    {
        isSelected = true;
    }

    public void SetDeselected()
    {
        isSelected = false;
    }

    //Fun��o que � executada quando o jogador aperta o bot�o virtual enter do teclado.
    //Deve ser a mesma coisa quando o jogador aperta o bot�o enter de seu teclado f�sico
    public void OnClickEnterButton()
    {
        InputFunction();
        ToggleActivationKeyBoard();
    }

    //Fun��o que � executada quando o jogador aperta o bot�o virtual ESC do teclado.
    //Deve ser a mesma coisa quando o jogador aperta o bot�o ESC de seu teclado f�sico
    public void OnClickCancelButton()
    {
        keyboard.text = "";
        DesactiveKeyboard();
    }

    
}
