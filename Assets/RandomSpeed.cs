using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeed : MonoBehaviour
{
    public float rs, rs1, rs2;
    private void Awake()
    {
        rs = Random.Range(rs1, rs2);
    }
}
