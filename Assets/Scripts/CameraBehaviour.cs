using System;
using System.Collections;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private float timeToMove = 1f;
    private Vector3 _initialCameraPos;
    private Vector3 _newPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        _initialCameraPos = camera.transform.position;
        _newPos = _initialCameraPos;
        _newPos.x = transform.position.x;
        StartCoroutine(MoveCamera());
    }
    
    IEnumerator MoveCamera()
    {
        var ellapsedTime = 0f;

        while (ellapsedTime <= timeToMove)
        {
            camera.position = Vector3.Lerp(_initialCameraPos, _newPos, ellapsedTime / timeToMove);
            ellapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        
        Destroy(gameObject);
    }
}
