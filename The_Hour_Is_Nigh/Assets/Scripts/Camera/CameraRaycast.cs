using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject lastObjectHit;

    [Header("Reference To The Enemy")]
    [SerializeField] private BlobBehavior referenceToBlob;
    [SerializeField] private EnemyHealthManager enemyHealthManager;

    [Header("Floats")]
    [SerializeField] private float interactDistance;
    [SerializeField] private float raycastDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, raycastDistance))
        {
            string objectHitTag = hitInfo.collider.gameObject.tag;

            GameObject objectHit = hitInfo.collider.gameObject;

            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);

            if (hitInfo.distance < interactDistance)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (objectHit.tag == "Enemy")
                    {
                        referenceToBlob = objectHit.GetComponent<BlobBehavior>();
                        enemyHealthManager = objectHit.GetComponent<EnemyHealthManager>();
                        referenceToBlob.TakeDamage(5);
                        referenceToBlob.BlobDies();
                        
                        GameManager.Instance.SpawnBlobAfterDeath();

                    }
                }
            }
        }
    }

    public BlobBehavior ReferenceToBlob
    {
        get
        {
            return referenceToBlob;
        }
        set
        {
            referenceToBlob = value;
        }
    }
}
