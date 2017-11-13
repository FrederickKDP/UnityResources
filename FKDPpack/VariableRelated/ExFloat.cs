[System.Serializable]
public class ExFloat
{
    public float baseValue = 0;
    public float varValue = 0;

    public ExFloat()
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

    public static ExFloat operator +(ExFloat a, float b)
    {
        a.varValue += b;
        return a;
    }

    public static ExFloat operator ++(ExFloat a)
    {
        a.varValue++;
        return a;
    }

    public static ExFloat operator --(ExFloat a)
    {
        a.varValue--;
        return a;
    }

    public static ExFloat operator -(ExFloat a, float b)
    {
        a.varValue -= b;
        return a;
    }

    public static ExFloat operator *(ExFloat a, float b)
    {
        a.varValue *= b;
        return a;
    }

    public static ExFloat operator /(ExFloat a, float b)
    {
        a.varValue /= b;
        return a;
    }
}