using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float shakeDur;
    public float shakeMag;
    public float dampSpd;
    private Transform trans;
    private Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {

        trans = transform;
        initPos = transform.localPosition;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        initPos = transform.localPosition;

        if (shakeDur > 0)
        {
            transform.localPosition = initPos + Random.insideUnitSphere * shakeMag;
            shakeDur -= Time.deltaTime * dampSpd;
        }
        else
        {
            shakeDur = 0f;
            transform.position = player.transform.position + offset;
        }
    }

    public void Shake()
    {
        shakeDur = 1.5f;
    }
}
