using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Position : MonoBehaviour {
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
