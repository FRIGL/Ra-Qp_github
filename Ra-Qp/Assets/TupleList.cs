using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TupleList
{
    public string name = "";
    public List<TupleSaveObject> tuples = new List<TupleSaveObject>();

    public string GetName(){ return name; }
    public List<TupleSaveObject> GetTuples(){ return tuples; }

    //copy constructor 
    public TupleList(TupleList otherTupleList) 
    {
        foreach (TupleSaveObject tuple in otherTupleList.GetTuples())
        {
            AddElement(tuple);
        }
    }

    //copy constructor 
    public TupleList(List<TupleSaveObject> tuples)
    {
        foreach (TupleSaveObject tuple in tuples)
        {
            this.AddElement(tuple);
        }
    }

    public void AddElement(TupleSaveObject tupleSaveObjectToAdd)
    {
        //deep copy the tupleSaveObjectToAdd, and add it to the tuples list
        TupleSaveObject newTupleSaveObject = new TupleSaveObject(tupleSaveObjectToAdd);
        this.tuples.Add(newTupleSaveObject);
    }

    public void SubtractElement()
    {
        if (tuples.Count > 0)
        {
            tuples.RemoveAt(tuples.Count - 1);
        }
    }
}
