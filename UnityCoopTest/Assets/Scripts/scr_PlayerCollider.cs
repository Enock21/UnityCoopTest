using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class scr_PlayerCollider
{

    //Lista de gameobjects que o player entrou no collider trigger. 
    private static List<scr_KeyboardInteractable> colliders = new List<scr_KeyboardInteractable>();


    //Se o objeto não existe dentro da lista de colliders, então ele é adicionado
    public static void AddCollider(scr_KeyboardInteractable obj)
    {

        if (!Contains(obj.GetInstanceID()))
            colliders.Add(obj);

    }

    //InstanceID é como um hashcode. Cada instance tem um ID unico
    public static void RemoveColllider(scr_KeyboardInteractable obj)
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

    //Verifica se existe algum elemento com a instanceId passada como parametro. Se sim, retorna true, caso contrário, retorna falso
    private static bool Contains(int InstanceID)
    {
        bool retorno = false;
        int i = 0;
        while(!retorno && i < colliders.Count)
        {
            if(colliders[i].GetInstanceID() == InstanceID)
            {
                retorno = true;
            }
            i++;
        }
        return retorno;
    }


}

