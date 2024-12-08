using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace MeetAndTalk.Demo
{
    public class DemoInteraction : MonoBehaviour
    {
        public string InteractionText;
        public UnityEvent OnInteraction;
        public GameManager gameManager;
        public void Interaction()
        {
            gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager?.tasks != null && gameManager.tasks.Any())
            {
                gameManager.tasks[0].isCompleted = true;
            }
            //Debug.Log("sdafdf");
            OnInteraction.Invoke();
        }
    }
}
