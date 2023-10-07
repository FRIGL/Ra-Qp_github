[System.Serializable]
public class TupleVariableSaveObject
{
    public string variableName;
    public int variableType;//0->int, 1->float, 2->string
    public string variableValue; 

    public TupleVariableSaveObject() 
    {
        this.variableName = "";
        this.variableType = 0;
        this.variableValue = "0";
    }

    public TupleVariableSaveObject(TupleVariableSaveObject tupleVariableSaveObject)
    {
        this.variableName = tupleVariableSaveObject.variableName;
        this.variableType = tupleVariableSaveObject.variableType;
        this.variableValue = tupleVariableSaveObject.variableValue;
    }

    public string GetVariableName(){ return variableName; }
    public int GetVariableType() { return variableType; }
    public string GetVariableValue() { return variableValue; }
}
