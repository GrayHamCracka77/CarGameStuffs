using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarParts : MonoBehaviour
{

    public Transform _carRoot;
    public Transform _defaultCarBody;
    public Transform _defaultWeapon;

    public List<Transform> _possibleWeapons;
    public List<Transform> _possibleCarBody;

    private Transform currentBody;
    private int bodyIndex;

    void Start()
    {
        bodyIndex = 0;
        currentBody = Instantiate(_defaultCarBody, _carRoot);
        Instantiate(_defaultWeapon, _carRoot);
    }

    void Update()
    {
        Transform nextBody = null;
        if (Input.GetKeyDown("right"))
        {
            nextBody = _possibleCarBody[bodyIndex++ % _possibleCarBody.Count];
            if(bodyIndex == int.MaxValue)
            {
                bodyIndex = bodyIndex % _possibleCarBody.Count;
            }
        }

        if (Input.GetKeyDown("left"))
        {
            if (bodyIndex == 0)
            {
                bodyIndex = _possibleCarBody.Count;
            }
            nextBody = _possibleCarBody[bodyIndex-- % _possibleCarBody.Count];
        }

        if (nextBody != null)
        {
            Destroy(currentBody.gameObject);
            currentBody = Instantiate(nextBody, currentBody.position, currentBody.rotation, _carRoot);
        }
    }
}
