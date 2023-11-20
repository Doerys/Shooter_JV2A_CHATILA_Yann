using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float timer;

    private FunctionLibrary functionLibrary;

    // Start is called before the first frame update
    void Start()
    {
        functionLibrary = FindAnyObjectByType<FunctionLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        functionLibrary.CheckTrigger(collision);
    }
}
