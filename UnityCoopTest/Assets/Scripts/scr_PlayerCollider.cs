using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class scr_PlayerCollider
{

    private static List<GameObject> colliders = new List<GameObject>();


    //Se o objeto não existe dentro da lista de colliders, então ele é adicionado
    public static void AddCollider(GameObject obj)
    {

        if (!Contains(obj.GetInstanceID()))
            colliders.Add(obj);

    }

    //InstanceID é como um hashcode. Cada instance tem um ID unico
    public static void RemoveColllider(GameObject obj)
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

    public static int Count()
    {
        return colliders.Count;
    }


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

