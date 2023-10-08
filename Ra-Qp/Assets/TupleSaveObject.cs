using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TupleSaveObject
{
    public List<TupleVariableSaveObject> variables = new List<TupleVariableSaveObject>();

    public TupleSaveObject()
    {

    }

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

    public bool HasVariable(string variableName)
    {
        foreach (TupleVariableSaveObject variable in variables)
        {
            if (variable.GetVariableName() == variableName)
            {
                return true;
            }
        }

        return false;
    }

    public string GetValue(string variableName) 
    {
        string value = "";
        foreach (TupleVariableSaveObject variable in variables)
        {
            if(variable.GetVariableName() == variableName) 
            {
                value = variable.GetVariableValue();
            }
        }
        return value;
    }

    public List<TupleVariableSaveObject> GetVariables() 
    {
        return this.variables;
    }

    public void AddVariable() 
    {
        variables.Add(new TupleVariableSaveObject());
    }

    public void AddVariable(TupleVariableSaveObject tupleVariableSaveObject)
    {
        variables.Add(new TupleVariableSaveObject(tupleVariableSaveObject));
    }

    public void SubtractVariable() 
    {
        if(variables.Count > 0)
        {
            variables.RemoveAt(variables.Count - 1);
        }
    }
}

