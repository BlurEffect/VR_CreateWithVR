using UnityEngine;

public class CustomReticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform rotationTransform;
    [SerializeField] private Transform scaleTransform;

    [Header("Rotate")]
    [SerializeField] private float rotationSpeed;
    
    [Header("Scale")]
    [SerializeField] private Vector2 scaleRange;
    [SerializeField] private AnimationCurve scaleAnimationCurve;
    [SerializeField] private float scaleInterval;

    private float animationTimeCount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationTimeCount += Time.deltaTime;
        
        rotationTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        float progress = (animationTimeCount % scaleInterval) / scaleInterval;
        float scaleFactor = Mathf.Lerp(scaleRange[0], scaleRange[1], scaleAnimationCurve.Evaluate(progress));
        scaleTransform.localScale = new Vector3(scaleFactor, 1.0f, scaleFactor);
    }
}
