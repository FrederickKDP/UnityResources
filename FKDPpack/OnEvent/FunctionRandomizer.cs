using UnityEngine;
using UnityEngine.Events;

public sealed class FunctionRandomizer : MonoBehaviour
{
    public ChanceCall[] onChanceFunctions;
    #if UNITY_EDITOR
    public bool debugLogs = false;
    public bool enableAutoBalance = false;
    #endif

    [BitStrap.Button]
    public void ChanceCall()
    {
        float rng = Random.Range(0,101);
        int selected = 0;
        float sumChance = 0;
        float lastChance = 0;
        for (int i = 0; i < onChanceFunctions.Length; i++)
        {
            sumChance += onChanceFunctions[i].chanceRange;
            if (rng <= sumChance &&
                rng >= lastChance)
            {
                selected = i;                
            }
            lastChance += sumChance;
        }
        if (onChanceFunctions[selected].onChanceCall.GetPersistentEventCount() > 0)
        {
            onChanceFunctions[selected].onChanceCall.Invoke();
            #if UNITY_EDITOR
            if(debugLogs)
            Debug.Log("Called "+ onChanceFunctions[selected].methodName+" number "+selected+" by chance "+rng);
            #endif
        }
        else
        {

            Debug.LogError("Selected function was not assign");
        }
    }

    [BitStrap.Button]
    public void Rebalance()
    {
        float sum = 0;
        for (int i = 0; i < onChanceFunctions.Length; i++)
        {
            sum += onChanceFunctions[i].chanceRange;
        }
        for (int i = 0; i < onChanceFunctions.Length; i++)
        {
            if(onChanceFunctions[i].chanceRange!=0)
            onChanceFunctions[i].chanceRange = 100/(sum/onChanceFunctions[i].chanceRange);
            #if UNITY_EDITOR
                onChanceFunctions[i].lastValue = onChanceFunctions[i].chanceRange;
            #endif
        }
        #if UNITY_EDITOR
            if (debugLogs)
                Debug.Log("Probabilities rebalanced!");
        #endif
    }

    [BitStrap.Button]
    public void ResetAll()
    {
        for (int i = 0; i < onChanceFunctions.Length; i++)
        {
           onChanceFunctions[i].chanceRange = 1;
        }
        Rebalance();
        Debug.Log("Probabilities reseted!");
    }

    private void OnValidate()
    {
    #if UNITY_EDITOR
        float deltaChance = 0;
        for (int i = 0; i < onChanceFunctions.Length; i++)
        {
            //Rename on inspector
            if (onChanceFunctions[i].onChanceCall.GetPersistentEventCount() > 0)
            {
                onChanceFunctions[i].methodName = onChanceFunctions[i].onChanceCall.GetPersistentMethodName(0);
            }
            else
            {
                onChanceFunctions[i].methodName = "Not assigned";
            }
            //Balance chances
                if (onChanceFunctions[i].lastValue != onChanceFunctions[i].chanceRange)
                {
                    if(onChanceFunctions.Length>=2)
                    deltaChance = (onChanceFunctions[i].lastValue - onChanceFunctions[i].chanceRange)/(onChanceFunctions.Length-1);
                    onChanceFunctions[i].lastValue = onChanceFunctions[i].chanceRange;
                    if (enableAutoBalance)
                    {
                        for (int k = 0; k < onChanceFunctions.Length; k++)
                        {
                            if (k != i)
                            {
                                onChanceFunctions[k].chanceRange += deltaChance;
                                onChanceFunctions[k].chanceRange = Mathf.Clamp(onChanceFunctions[k].chanceRange, 0, 100);
                                onChanceFunctions[k].lastValue = onChanceFunctions[k].chanceRange;
                            }
                        }
                  }
            }
        }
        #endif
    }
}

[System.Serializable, ExecuteInEditMode]
public class ChanceCall
{
    #if UNITY_EDITOR
        [HideInInspector]
        public string methodName = "Not assigned";

        [HideInInspector]
        public float lastValue = 1;
    #endif
    /// <summary>
    /// When ChanceCall is called, it rolls a random number. Then it selects the function that it's inside that range of numbers.
    /// </summary>
    [Range(1,99)]
    public float chanceRange = 1;
    public UnityEvent onChanceCall;
}