using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterDistance : MonoBehaviour {
    public Transform target;
    public float distance = 3;
    [Tooltip("Should it use an alternative update method for optimization or as soon as possible?")]
    public bool isSlowUpdate = true;
    public float slowUpdateRate = 3f;

    private void Awake()
    {
        if(isSlowUpdate)
            StartCoroutine("RepeatCheck");
    }

    private void OnEnable()
    {
        if (isSlowUpdate)
            StartCoroutine("RepeatCheck");
    }

    private void OnDisable()
    {
        if (isSlowUpdate)
            StopAllCoroutines();
    }

    private void Update()
    {
        if (!isSlowUpdate)
        {
            CheckDistance();
        }
    }

    void CheckDistance()
    {
        if(Vector3.Distance(transform.position, target.position)>distance){
            gameObject.SetActive(false);
        }
    }

    IEnumerator RepeatCheck()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            CheckDistance();
            yield return new WaitForSeconds(2f);
        }
    }
}
