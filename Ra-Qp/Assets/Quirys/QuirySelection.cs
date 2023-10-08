using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class QuirySelection : Query
{
    
    public string inputList;
    public string outputList;
    public string dynamicOperandName;
    public Dropdown operatorDropdown;
    public string staticOperand;

    public TupleList testList;

    public void UpdateInputList(string input) { inputList = input; }
    public void UpdateOutputList(string input) { outputList = input; }
    public void UpdateDynamicOperandName(string input){ dynamicOperandName = input; }
    public void UpdateStaticOperand(string input) { staticOperand = input; }

    //return componentRefrenceDatabase.Find(c => c.GetHashCode() == hashcodeWeAreLookingFor);

    public override void ApplyQuiry() 
    {
        //Get List of inputList name
        TupleList inputTupleList = TupleListsOrganizer.singleton.GetTupleList(inputList);
        if(inputTupleList == null){ return; }

        
        //Find all of the Tuple's that fit our query
        List<TupleSaveObject> filteredTupleList = inputTupleList.GetTuples().FindAll(t => evaluate(t.GetValue(dynamicOperandName), staticOperand));

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

    private bool evaluate(string a, string b) 
    {
        int operatorDropdownIndex = operatorDropdown.value;
        string operatr = operatorDropdown.options[operatorDropdownIndex].text;

        switch (operatr)
        {
            case "==":
                return (String.Compare(a, b) == 0);
            case ">=":
                return (String.Compare(a, b) > 0) || (String.Compare(a, b) == 0);
            case ">":
                return (String.Compare(a, b) > 0);
            case "<":
                return (String.Compare(a, b) < 0);
            case "<=":
                return (String.Compare(a, b) < 0) || (String.Compare(a, b) == 0);
        }

        return false;
    }
}
