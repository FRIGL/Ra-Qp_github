using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Query : MonoBehaviour
{
    public virtual void ApplyQuiry(){ }

    public virtual TupleList QueryList()
    {
        return null;
    }
}
