using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    #region Variables
    [SerializeField][Range(0.0f, 10.0f)] private float speedMovment = 5.0f;
    [SerializeField][Range(0.0f, 500.0f)] private float speedZoom = 300.0f;
    private Vector3 startPosition = new Vector3(0, 20, -10);
    #endregion

    #region Unity-API
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace)) transform.position=startPosition;
        Vector3 move = transform.position;
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            move.z += speedMovment * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            move.z -= speedMovment * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move.x += speedMovment * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= speedMovment * Time.deltaTime;
        }

        move.y -= Input.GetAxis("Mouse ScrollWheel") * speedZoom * Time.deltaTime;
        move.y = Mathf.Clamp(move.y, 5, 40);

        transform.position = move; 
    }
    #endregion
}
