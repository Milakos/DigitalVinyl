using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPrompt : MonoBehaviour
{
    public enum InstructionUI
    {
        CrossPlatformFindAPlane,
        FindAFace,
        FindABody,
        FindAnImage,
        FindARecord,
        FindAnObject,
        ARKitCoachingOverlay,
        TapToPlace,
        None
    }

    [SerializeField] InstructionUI instruction;
    [SerializeField] ARUXAnimationManager animationManager;

    bool isStarted;

    private void Start() 
    {
        isStarted = true;
        ShowInstructions();    
    }

    private void OnEnable() 
    {
        if(isStarted)
            ShowInstructions();    
    }

    private void OnDisable() 
    {
        animationManager.FadeOffCurrentUI();    
    }

        private void ShowInstructions()
        {
            switch (instruction)
            {
                case InstructionUI.CrossPlatformFindAPlane:
                animationManager.
                ShowCrossPlatformFindAPlane();
                break;
                case InstructionUI.FindAFace:
                animationManager.ShowFindFace();
                break;
                case InstructionUI.FindABody:
                animationManager.ShowFindBody();
                break;
                case InstructionUI.FindAnImage:
                animationManager.ShowFindImage();
                break;
                case InstructionUI.FindARecord:
                animationManager.ShowFindImageNew();
                break;
                case InstructionUI.FindAnObject:
                animationManager.ShowFindObject();
                break;
                case InstructionUI.TapToPlace:
                animationManager.ShowTapToPlace();
                break;
                default:
                Debug.LogError("instruction switch missing, please edit AnimatedPrompt.cs " + instruction);
                break;
            }
    }
}

