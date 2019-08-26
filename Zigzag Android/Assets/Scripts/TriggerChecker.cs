using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public GameObject selfDiamend=null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag =="Ball")
        {
            Invoke("FallDown", 1f);
            ScoreManger.instance.score++;
            
        }

    }
    void FallDown()
    {
        GetComponentInParent<Rigidbody>().isKinematic = false;
        GetComponentInParent<Rigidbody>().useGravity = true;
        Destroy(transform.parent.gameObject, 1f);
        if (selfDiamend!=null)
        {
            selfDiamend.GetComponentInParent<Rigidbody>().isKinematic = false;
            selfDiamend.GetComponentInParent<Rigidbody>().useGravity = true;
            Destroy(selfDiamend.gameObject, 1f);
        }
        


    }
}
