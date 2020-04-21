using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class Controller : MonoBehaviour
{

    public InstantTracker Tracker;
    public Button StateButton;
    public Text StateButtonText;
    public Text MessageBox;

    GridRenderer grid;
    InstantTrackable trackable;

    InstantTrackingState trackerState = InstantTrackingState.Initializing;
    bool isChanging = false;
    
    void Awake()
    {
        grid = GetComponent<GridRenderer>();
        grid.enabled = true;

        trackable = Tracker.GetComponentInChildren<InstantTrackable>();
    }

    public void StateButtonPressed()
    {
        if (!isChanging)
        {
            if(trackerState == InstantTrackingState.Initializing)
            {
                if (Tracker.CanStartTracking())
                {
                    StateButtonText.text = "Switching State...";
                    isChanging = true;
                    Tracker.SetState(InstantTrackingState.Tracking);
                }
                else
                {
                    StateButtonText.text = "Switcing State...";
                    isChanging = false;
                    Tracker.SetState(InstantTrackingState.Tracking);
                }
            }
        }
        
    }

    void Start()
    {
        MessageBox.text = "Starting the SDK";
    }

    
    void Update()
    {
        
    }
}
