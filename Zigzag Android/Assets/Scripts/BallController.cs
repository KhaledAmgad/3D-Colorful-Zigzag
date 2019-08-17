using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject particle;
    public float speed;
    bool started;
    bool gameOver;
    Rigidbody rig;
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        
    }
    void Start()
    {
        started = false;
        gameOver = false;
        Application.targetFrameRate = 300;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rig.velocity = new Vector3(speed, 0, 0);
                GameManger.instance.GameStart();
            }
        }
        if(!Physics.Raycast(transform.position,Vector3.down,1f))
        {
            gameOver = true;
            rig.velocity=new Vector3(0,-25f,0);
            GetComponent<SphereCollider>().isTrigger = true;
            GameManger.instance.gameOver = true;
            Destroy(gameObject, 2f);
            GameManger.instance.GameStop();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver && !GameManger.instance.pause)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                switchDirection();
            }
        }
    }
    public void switchDirection()
    {
        if(rig.velocity.z>0)
        {
            rig.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rig.velocity = new Vector3(0, 0, speed);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part=Instantiate(particle, new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y+1, col.gameObject.transform.position.z), Quaternion.identity) as GameObject;
            ScoreManger.instance.score += 20;
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }

    }
    public void incrementSpeed()
    {
        speed += 0.25f;
    }
}
