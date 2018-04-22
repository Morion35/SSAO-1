using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{


    public float speed;
    private float size = 0;
    private float maxsize;
    private Transform trans;

    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
        maxsize = trans.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (size < maxsize)
        {
            size += speed;
            trans.localScale = new Vector3(size, size, size);
        }
        else
        {
            GameObject.Destroy(trans.gameObject);
        }

    }
}