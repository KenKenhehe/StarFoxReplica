using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [SerializeField]float speed = 20;
    [Header("screen Position")]
    [SerializeField] float limitX;
    [SerializeField] float limitY;
    [Header("Control based")]
    [SerializeField] float pitchFactor;
    [SerializeField] float yawFactor;
    [SerializeField] float rollFactor;
    [SerializeField] GameObject[] guns;
   

    [SerializeField] float controlFactor;
    float xOffset;
    float yOffset;
    float horizontalThrow;
    float YThrow;

    bool controlEnabled = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (controlEnabled)
        {
            ProcessInput();
            Movement();
            Rotation();
            ProcessFiring();
        }
	}
    
    void ProcessInput()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        YThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xOffset = horizontalThrow * speed * Time.deltaTime;
        yOffset = YThrow * speed * Time.deltaTime;
    }

    void Movement()
    {
        float newPositionX = transform.localPosition.x + xOffset;
        float newPositionY = transform.localPosition.y - yOffset;
        transform.localPosition = new Vector3(
            Mathf.Clamp(newPositionX, -limitX, limitX),
            Mathf.Clamp(newPositionY, -limitY, limitY),
            transform.localPosition.z
            );
    }

    void Rotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + YThrow * controlFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = horizontalThrow * rollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void OnPlayerDeath()
    {
        controlEnabled = false;
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActiveGun(true);
        }
        else
        {
            ActiveGun(false);
        }
    }

    void ActiveGun(bool active)
    {
        foreach(GameObject gun in guns)
        {
            var gunParticleEmission = gun.GetComponent<ParticleSystem>().emission;
            gunParticleEmission.enabled = active;
        }
    }

   
}
