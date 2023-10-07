using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TupleVariableManager : MonoBehaviour
{
    public TupleVariableSaveObject tupleVariableSaveObject;

    public InputField variableNameInputField;
    public InputField variableTypeInputField;
    public InputField variableValueInputField;

    public void Start()
    {
        variableNameInputField.text = tupleVariableSaveObject.GetVariableName();
        variableTypeInputField.text = tupleVariableSaveObject.GetVariableType().ToString();
        variableValueInputField.text = tupleVariableSaveObject.GetVariableValue();
    }

    public void SetTupleVariableSaveObject(TupleVariableSaveObject tupleVariableSaveObject) 
    {
        this.tupleVariableSaveObject = tupleVariableSaveObject;
    }

    public void updateVariableName(string input)
    {
        tupleVariableSaveObject.variableName = input;
    }

    public void updateVariableType(string input)
    {
        tupleVariableSaveObject.variableType = int.Parse(input);
    }

    public void updateVariableValue(string input)
    {
        tupleVariableSaveObject.variableValue = input;
    }

}
