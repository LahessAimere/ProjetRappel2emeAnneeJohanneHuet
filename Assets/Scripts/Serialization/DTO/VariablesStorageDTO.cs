using System.Collections.Generic;

public class VariablesStorageDTO : DataTransferObject
{
    public Dictionary<string, float> FloatVariables;
    public Dictionary<string, string> StringVariables;
    public Dictionary<string, bool> BoolVariables;
}
