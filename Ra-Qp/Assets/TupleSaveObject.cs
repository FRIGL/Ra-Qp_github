using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TupleSaveObject
{
    public List<TupleVariableSaveObject> variables = new List<TupleVariableSaveObject>();

    //copy consuctor 
    public TupleSaveObject(TupleSaveObject tupleSaveObject) 
    {
        //deepcopy the tupleSaveObject
        foreach (TupleVariableSaveObject thisTupleVariable in tupleSaveObject.GetVariables())
        {
            TupleVariableSaveObject newTupleVariable = new TupleVariableSaveObject(thisTupleVariable);
            variables.Add(newTupleVariable);
        }

        //i could use this to migrate the date form differnt versions of the TupleVariableSaveObject

        //this.variables = tupleSaveObject.GetVariables();
    }

    public List<TupleVariableSaveObject> GetVariables() 
    {
        return this.variables;
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

