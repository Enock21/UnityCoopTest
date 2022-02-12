using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Scr_NPCInteractable : Scr_KeyboardInteractable
{
    private const string KEYBOARD = "KEYBOARD_";
    private const string TURN = "TURN";
    private const string MOVE_X = "MOVEX";

    public void Keyboard_Turn()
    {
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
    }

    public void Keyboard_MoveX(int value)
    {
        Vector3 position = transform.position;
        transform.position = position + new Vector3(value, 0, 0);
    }
    

    public override void CallFunction(string function)
    {
        print("Fun��o digitada: " + function);
        switch (function)
        {
            case KEYBOARD + TURN:
                Keyboard_Turn();
                break;
            default:
                print("Fun��o n�o encontrada");
                break;
        }
           
    }

    public override void CallFunction(string function, string parameter)
    {
        print("Fun��o digitada: " + function);
        print("With parameters: " + parameter);
        switch (function)
        {
            case KEYBOARD + MOVE_X:
                int value = int.Parse(parameter);
                Keyboard_MoveX(value);
                break;
            default:
                print("Fun��o n�o encontrada");
                break;
        }
    }

}
