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
    private List<Transform>.Enumerator carBodyEnumerator;

    void Start()
    {
        carBodyEnumerator = _possibleCarBody.GetEnumerator();
        carBodyEnumerator.MoveNext();

        currentBody = Instantiate(_defaultCarBody, _carRoot);
        Instantiate(_defaultWeapon, _carRoot);
    }

    void Update()
    {
        Transform nextBody = null;
        if (Input.GetKeyDown("right"))
        {
            var hasNext = carBodyEnumerator.MoveNext();
            if (!hasNext)
            {
                carBodyEnumerator = _possibleCarBody.GetEnumerator();
                carBodyEnumerator.MoveNext();
            }
            nextBody = carBodyEnumerator.Current;
        }

        if (nextBody != null)
        {
            Destroy(currentBody.gameObject);
            currentBody = Instantiate(nextBody, currentBody.position, currentBody.rotation, _carRoot);
        }
    }
}
