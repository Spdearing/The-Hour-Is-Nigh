using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu(fileName = "Weak Blob", menuName = "Weak Blob")]
public class WeakBlob : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private string description;
    [SerializeField] private GameObject weakBlobEnemy;
    [SerializeField] private int weakBlobAttack;
    [SerializeField] private int weakBlobHealth;
}
