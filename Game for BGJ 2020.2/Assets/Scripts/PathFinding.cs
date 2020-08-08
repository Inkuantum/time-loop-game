using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathFinding : MonoBehaviour
{
    public List<GameObject> targets;
    public AIPath aiPath;
    public AIDestinationSetter aIDestination;
    public Seeker seeker;
    int current_target_index = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(targets.Count > 0 && targets != null)
        {
            aIDestination.target = targets[current_target_index].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, targets[current_target_index].transform.position);
        if (distance < 0.2f)
        {
            current_target_index++;
            if(current_target_index == targets.Count)
            {
                current_target_index = 0;
            }
            aIDestination.target = targets[current_target_index].transform;

        }
        if(aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-4f, 4f, 4f);
        } else if (aiPath.desiredVelocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(4f, 4f, 4f);
        }
    }
}
