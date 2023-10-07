using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TupleSaveObject
{
    public List<TupleVariableSaveObject> variables;

    //copy consuctor 
    public TupleSaveObject(List<TupleVariableSaveObject> variables) 
    {
        //i could use this to migrate the date form differnt versions of the TupleVariableSaveObject

        this.variables = variables;
    }

    public List<TupleVariableSaveObject> GetVariables() 
    {
        return variables;
    }

    public void AddVariable() 
    {
        variables.Add(new TupleVariableSaveObject());
    }

    public void SubtractVariable() 
    {
        if(variables.Count > 0)
        {
            variables.RemoveAt(variables.Count - 1);
        }
    }
}

