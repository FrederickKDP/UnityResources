[System.Serializable]
public class ExInt
{
    public int baseValue = 0;
    public int varValue = 0;

    public ExInt()
    {
        baseValue = 0;
        varValue = 0;
    }

    /// <summary>
    /// Makes var value back to it`s default
    /// </summary>
    public void Refresh()
    {
        varValue = baseValue;
    }

    /// <summary>
    /// If var value is bigger than the base, make them equal.
    /// If is less than 0, make it 0
    /// </summary>
    public void TrimValue()
    {
        if (varValue > baseValue)
        {
            varValue = baseValue;
        }
        if (varValue < 0)
        {
            varValue = 0;
        }
    }

    public static ExInt operator +(ExInt a, int b)
    {
        a.varValue += b;
        return a;
    }

    public static ExInt operator ++(ExInt a)
    {
        a.varValue ++;
        return a;
    }

    public static ExInt operator --(ExInt a)
    {
        a.varValue--;
        return a;
    }

    public static ExInt operator -(ExInt a, int b)
    {
        a.varValue -= b;
        return a;
    }

    public static ExInt operator *(ExInt a, int b)
    {
        a.varValue *= b;
        return a;
    }

    public static ExInt operator /(ExInt a, int b)
    {
        a.varValue /= b;
        return a;
    }
}

