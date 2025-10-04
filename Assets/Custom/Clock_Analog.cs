using System;
using UnityEngine;

public class ClockAnalog : MonoBehaviour
{
    [SerializeField] private Transform clockHandHours;
    [SerializeField] private Transform clockHandMinutes;
    [SerializeField] private Transform clockHandSeconds;

    private Quaternion hoursRotationOffset;
    private Quaternion minutesRotationOffset;
    private Quaternion secondsRotationOffset;

    // Constants to avoid division operations in update loop
    private const float HourSegment = 360.0f / 12.0f;
    private const float MinSecondSegment = 360.0f / 60.0f;
    private const float MinutePartialSegment = 360.0f / 3600.0f; // (60.0f * 60.0f);
    private const float SecondPartialSegment = 360.0f / 43200.0f; // (12.0f * 60.0f * 60.0f);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtain local rotation offset
        hoursRotationOffset = clockHandHours.localRotation;
        minutesRotationOffset = clockHandMinutes.localRotation;
        secondsRotationOffset = clockHandSeconds.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        
        // Calculate clock hand rotations based on current time
        clockHandHours.localRotation = hoursRotationOffset * Quaternion.Euler( 0.0f, currentTime.Second * SecondPartialSegment + currentTime.Minute * MinutePartialSegment + currentTime.Hour * HourSegment, 0.0f );
        clockHandMinutes.localRotation = minutesRotationOffset * Quaternion.Euler( 0.0f, currentTime.Second * MinutePartialSegment + currentTime.Minute * MinSecondSegment, 0.0f );
        clockHandSeconds.localRotation = secondsRotationOffset * Quaternion.Euler( 0.0f, currentTime.Second * MinSecondSegment, 0.0f );
    }
}
