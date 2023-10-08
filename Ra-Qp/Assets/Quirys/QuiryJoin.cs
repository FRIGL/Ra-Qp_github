using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuiryJoin : Query
{

    public string inputListLeft;
    public string inputListRight;
    public string outputList;

    public TupleList testList;

    public void UpdateInputListLeft(string input) { inputListLeft = input; }
    public void UpdateInputListRight(string input) { inputListRight = input; }
    public void UpdateOutputList(string input) { outputList = input; }

    public override void ApplyQuiry()
    {
        //Get List of inputList name
        TupleList inputTupleListLeft = TupleListsOrganizer.singleton.GetTupleList(inputListLeft);
        if (inputTupleListLeft == null) { return; }

        TupleList inputTupleListRight = TupleListsOrganizer.singleton.GetTupleList(inputListRight);
        if (inputListRight == null) { return; }

        /*
        //Find all of the TupleVariableSaveObject's that fit our query
        List<TupleSaveObject> filteredTupleList = new List<TupleSaveObject>();
        foreach (TupleSaveObject thisTupleSaveObject in inputTupleList.GetTuples())
        {
            TupleSaveObject newEntry = new TupleSaveObject();
            newEntry.AddVariable(thisTupleSaveObject.GetVariables().Find(v => v.GetVariableName() == dynamicOperandName));
            filteredTupleList.Add(newEntry);
        }
        */


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
