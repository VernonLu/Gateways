using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Vector2 margin;
    public float smooth = 2f;

    public Vector2 minXAndY;
    public Vector2 maxXAndY;
    public float offsetHeight = 4.5f;

    private Transform player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        TrackPlayer();
    }
    private void TrackPlayer()
    {
        Vector2 target = new Vector2(transform.position.x, transform.position.y);
        if (CheckMargin())
        {
            target = Vector2.Lerp(transform.position, player.position + new Vector3(0, offsetHeight), smooth * Time.deltaTime);
        }
        target.x = Mathf.Clamp(target.x, minXAndY.x, maxXAndY.x);
        target.y = Mathf.Clamp(target.y, minXAndY.y, maxXAndY.y);
        
        transform.position = new Vector3(target.x, target.y, transform.position.z);
    }
    private bool CheckMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > margin.x || Mathf.Abs(transform.position.y - player.position.y - offsetHeight) > margin.y;
    }
}
