using UnityEngine;
using System.Collections;

public class ExtendedAtrib : MonoBehaviour {
    public int a;
    public ExInt HP, SP, MP;
    public ExFloat speed;

    void Start()
    {
        HP -= 5;
        print(HP.baseValue + " " + HP.varValue);
    }

    [BitStrap.Button]
    public void ResetHP()
    {
        HP.Refresh();
    }
}