using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour
{
    public EditorPath PathToFollow;

    public int currentWayPointID = 0;
    public float speed;
    private float reachDistance = 1;
    public float rotationSpeed = 5;
    public string pathName;

    Vector2 lastPosition;
    Vector2 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        //PathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(PathToFollow.path_objs[currentWayPointID].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, PathToFollow.path_objs[currentWayPointID].position, Time.deltaTime * speed);

        if (distance <= reachDistance)
        {
            currentWayPointID++;
        }

        if(currentWayPointID >= PathToFollow.path_objs.Count)
        {
            Destroy(gameObject);
        }
    }
}
