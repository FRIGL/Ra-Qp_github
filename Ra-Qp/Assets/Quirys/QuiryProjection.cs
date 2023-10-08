using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class QuiryProjection : Query
{

    public string inputList;
    public string outputList;
    public string dynamicOperandName;

    public TupleList testList;

    public void UpdateInputList(string input) { inputList = input; }
    public void UpdateOutputList(string input) { outputList = input; }
    public void UpdateDynamicOperandName(string input) { dynamicOperandName = input; }

    //return componentRefrenceDatabase.Find(c => c.GetHashCode() == hashcodeWeAreLookingFor);

    public override void ApplyQuiry()
    {
        //Get List of inputList name
        TupleList inputTupleList = TupleListsOrganizer.singleton.GetTupleList(inputList);
        if (inputTupleList == null) { return; }



        //Find all of the TupleVariableSaveObject's that fit our query
        List<TupleSaveObject> filteredTupleList = new List<TupleSaveObject>();
        foreach (TupleSaveObject thisTupleSaveObject in inputTupleList.GetTuples())
        {
            TupleSaveObject newEntry = new TupleSaveObject();
            newEntry.AddVariable(thisTupleSaveObject.GetVariables().Find(v => v.GetVariableName() == dynamicOperandName));
            filteredTupleList.Add(newEntry);
        }


        //make a deepCopy, of the filteredTupleList
        TupleList tempTupleList = new TupleList(filteredTupleList);
        testList = tempTupleList;

        //find the output List, if it dose not exist GetTupleListManager makes a new one and returns that instead
        TupleListManager tupleListManager = TupleListsOrganizer.singleton.GetTupleListManager(outputList);
        tupleListManager.Set(outputList, tempTupleList);
    }

    public override TupleList QueryList()
    {
        return null;
    }

}
