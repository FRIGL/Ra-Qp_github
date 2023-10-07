using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TupleList
{
    public List<TupleSaveObject> tuples;

    public List<TupleSaveObject> GetTuples(){ return tuples; }

    public void AddElement(TupleSaveObject tupleSaveObjectToAdd)
    {
        //deep copy the tupleSaveObjectToAdd, and add it to the tuples list
        tuples.Add(new TupleSaveObject(tupleSaveObjectToAdd));
    }

    public void SubtractElement()
    {
        if (tuples.Count > 0)
        {
            tuples.RemoveAt(tuples.Count - 1);
        }
    }
}
