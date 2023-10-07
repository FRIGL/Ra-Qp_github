using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TupleListElementVariableManager : MonoBehaviour
{
    public TupleVariableSaveObject tupleVariableSaveObject;

    public InputField variableValueInputField;

    public void initialize(TupleVariableSaveObject tupleVariableSaveObject) 
    {
        this.tupleVariableSaveObject = tupleVariableSaveObject;

        variableValueInputField.text = tupleVariableSaveObject.GetVariableValue();
    }

    public void updateVariableValue(string input)
    {
        tupleVariableSaveObject.variableValue = input;
    }
}
