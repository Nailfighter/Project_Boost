using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

[DisallowMultipleComponent]
public class Moving_Object : MonoBehaviour
{
    [SerializeField] Vector3 mov_vector;
    private float mov_factor;
    private Vector3 offset;
    private Vector3 Start_pos;
    [SerializeField] float period = 2f;

    void Start()
    {
        Start_pos = transform.position;
    }

    void Update()
    {
        if (period <=Mathf.Epsilon) { return; }
        float cycle = Time.time / period;
        const float tue = Mathf.PI * 2f;
        float rawSin = Mathf.Sin(cycle * tue);
        mov_factor = rawSin / 2f + 0.5f;
        offset = mov_vector * mov_factor;
        transform.position = Start_pos + offset;
    }
}
