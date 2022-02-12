using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_KeyboardInteractableRepository:MonoBehaviour
{

    //Lista de gameobjects que o player entrou no collider trigger. 
    private static List<Scr_KeyboardInteractable> colliders = new();


    //Se o objeto n�o existe dentro da lista de colliders, ent�o ele � adicionado
    public static void AddCollider(Scr_KeyboardInteractable obj)
    {

        if (!Contains(obj.ClassName))
            colliders.Add(obj);

    }

    //InstanceID � como um hashcode. Cada instance tem um ID unico
    public static void RemoveColllider(Scr_KeyboardInteractable obj)
    {
        bool found = false;
        int i = 0;
        int instanceID = obj.GetInstanceID();
        while(!found && i < colliders.Count)
        {
            if(colliders[i].GetInstanceID() == instanceID)
            {
                colliders.Remove(obj);
                found = true;
            }
            i++;
        }
    }

    //Conta quantos elementos existem dentro da lista
    public static int Count()
    {
        return colliders.Count;
    }

    //Verifica se existe algum elemento com a instanceId passada como parametro. Se sim, retorna true, caso contr�rio, retorna falso
    public static bool Contains(string className)
    {
        bool retorno = false;
        int i = 0;
        while(!retorno && i < colliders.Count)
        {
            if(colliders[i].ClassName.ToUpper() == className.ToUpper())
            {
                retorno = true;
            }
            i++;
        }
        return retorno;
    }

    public static Scr_KeyboardInteractable Get(string className)
    {
        Scr_KeyboardInteractable retorno = null;
        if (!Contains(className))
            return retorno;

        int i = 0;
        while (!retorno && i < colliders.Count)
        {
            if (colliders[i].ClassName.ToUpper() == className.ToUpper())
            {
                retorno = colliders[i];
            }
            i++;
        }
        return retorno;


    }


}

