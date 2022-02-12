using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class Scr_KeyboardInteractable:MonoBehaviour
{
    [SerializeField]
    protected string className;

    public string ClassName { get => className; set => className = value; }



    //public abstract List<string> GetFunctions();

    public abstract void CallFunction(string function);

    public abstract void CallFunction(string function, string parameter);


    public List<string> GetFunctions()
    {
        List<string> functions = new();
        MethodInfo[] methodInfos = typeof(Scr_NPCInteractable).GetMethods();
        for (int i = 0; i < methodInfos.Length; i++)
        {
            string name = methodInfos[i].Name;
            if (name.Contains(("Keyboard_")))
            {
                functions.Add(name);
            }
        }
        return functions;

    }
}
