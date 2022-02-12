using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_InputController : MonoBehaviour
{
    public static Scr_InputController inputController;


    private void Start()
    {
        Scr_InputController.inputController = this;
    }

    public static void NewInput(string input)
    {
        print(input);
        string[] inputWord = input.ToUpper().Split(".");
        string className = inputWord[0];
        Scr_KeyboardInteractable obj = Scr_KeyboardInteractableRepository.Get(className);
        List<string> function = inputController.GetFunction(inputWord[1]);
        if (obj == null)
        {
            print("Objeto não encontrado");
            return;
        }
        if(function[0] == null)
        {
            print("Function nao encontrada");
            return;
        }

        print("Calling function: " + function[0]);
        inputController.CallFunction(obj, function[0], function[1]);

    }

    //Falta implementar
    public void CallFunction(Scr_KeyboardInteractable obj, string functionString, string parameter)
    {
        if (parameter == "")
            obj.CallFunction("Keyboard_".ToUpper() + functionString);
        else
            obj.CallFunction("Keyboard_".ToUpper() + functionString, parameter);
    }

    private List<string> GetFunction(string functionString)
    {
        List<string> retorno = new List<string>();
        string function = "";
        string parameter = "";
        bool functionEnded = false;
        for(int i = 0; i < functionString.Length; i++)
        {
            bool isParenteses = functionString[i] == '(' || functionString[i] == ')';
            if (isParenteses)
                functionEnded = true;

            if (functionEnded && !isParenteses)
                parameter += functionString[i];
            else if (!functionEnded && !isParenteses)
                function += functionString[i];
        }
        print("Function found: " + function);
        print("Parameter found: " + parameter);
        retorno.Add(function);
        retorno.Add(parameter);
        return retorno;
    }
}
