using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.framework.api;
using System;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;

public class InstanceProvider : IInstanceProvider
{
    //The GameObject instantiated from the prefab
    GameObject prototype;

    //The name of the resource in Unity's resources folder
    private string resourceName;
    //The render layer to which the GameObjects will be assigned

    //This provider is instantiated multiple times in GameContext.
    //Each time, we provide the name of the prefab we're loading from
    //a resources folder, and the layer to which the resulting instance
    public InstanceProvider(string name)
    {
        resourceName = name;
    }

    #region IInstanceProvider implementation

    //Generate a typed instance
    public T GetInstance<T>()
    {
        object instance = GetInstance(typeof(T));
        T retv = (T)instance;
        return retv;
    }

    //Generate an untyped instance
    public object GetInstance(Type key)
    {
        if (prototype == null)
        {
            //Get the resource from Unity
            prototype = Resources.Load<GameObject>(resourceName);
            prototype.transform.localScale = Vector3.one;
        }

        //Copy the prototype
        GameObject go = GameObject.Instantiate(prototype) as GameObject;

        return go;
    }

    #endregion
}
