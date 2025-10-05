using UnityEngine;
using Random = UnityEngine.Random;

public class AnimatedReticle : MonoBehaviour
{
    [SerializeField] private Vector2 scaleRange;
    [SerializeField] private float scaleInterval;
    [SerializeField] private float rotationSpeed;

    private Transform reticle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reticle = transform;
    }

    // Update is called once per frame
    void Update()
    {
        reticle.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);

        float scaleFactor = Mathf.Lerp(scaleRange[0], scaleRange[1], Mathf.Sin(Mathf.PI * (Time.time % scaleInterval)));
        reticle.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
}
