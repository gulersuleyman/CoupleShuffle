using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     GameObject _player;

    

    public Vector3 _offset;
	

    void Start()
    {
		_player=GameObject.Find("Players");
        _offset = transform.position - _player.transform.position ;
    }
    void LateUpdate()
    {
        
    transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _offset.y, _player.transform.position.z + _offset.z);
        
    }
}
