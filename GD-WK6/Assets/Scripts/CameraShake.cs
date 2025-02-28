using UnityEngine;


public class CameraShake : MonoBehaviour
{
    // initial position of the camera -- used to reset the camera after shake
    private Vector3 initialPosition;
    
    // inspector variables for testing -- can be deleted later when we do function calls
    [SerializeField] private float defaultShakeTimer;
    [SerializeField] private float defaultShakeMagnitude;
    [SerializeField] private float shakeIntervalTimerMax;
    
    // shake variables 
    private float shakeTimer;
    private float shakeMagnitude;
    private float shakeIntervalTimer;
    private Vector3 shakeDirection;
    private bool shakeDirectionForward = true;
    
    void Start()
    {
        initialPosition = transform.localPosition;
    }
    
    void Update()
    {
        // keyboard input for testing -- can be deleted later 
        if (Input.GetKeyDown(KeyCode.Space)) BeginShake(defaultShakeTimer, defaultShakeMagnitude, shakeIntervalTimerMax, Vector3.zero);
        Shake();
    }
    
    /*
     * @brief: Begins the camera shake by setting all it's starting values
     *
     * @param timer: The length of the camera shake
     * @param magnitude: The intensity of the camera shake
     * @param interval: In a directional camera shake, the amount of time between its back and forth motion
     * @param direction: The general direction of the camera shake, put in Vector3.zero if you want it to be completely random
     */
    public void BeginShake(float timer, float magnitude, float interval, Vector3 direction)
    {
        shakeTimer = timer;
        shakeMagnitude = magnitude;
        shakeIntervalTimer = interval / 2;
        shakeDirection = direction.normalized;
    }

    private void Shake()
    {
        // shake while the timer is active
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            
            // no direction given, do random shake
            if (shakeDirection == Vector3.zero)
            {
                transform.localPosition = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            }
            else
            {
                // directional shake -- do back and forth movement
                transform.localPosition = initialPosition + 
                                          (shakeDirection * (shakeMagnitude * (shakeDirectionForward ? 1 : -1)));
                shakeIntervalTimer -= Time.deltaTime;
                if (shakeIntervalTimer <= 0)
                {
                    shakeDirectionForward = !shakeDirectionForward;
                    shakeIntervalTimer = shakeIntervalTimerMax;
                }
            }
            
            // reset camera after shake
            if (shakeTimer <= 0) transform.localPosition = initialPosition;
        }
    }
}
