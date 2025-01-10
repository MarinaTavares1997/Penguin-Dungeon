using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;
using PenguinDungeon;

namespace PenguinDungeon.Interaction
{
    public class Collision : MonoBehaviour
    {
        public Objects @object;
        
        public enum Objects
        {
            Alavanca, Armadilha
        }
        
        public UnityEvent @event;
        
        public enum Tags
        {
            Player
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var objectTag = other.gameObject.tag;
            var playerCollider = objectTag == Tags.Player.ToString();
            
            switch (@object)
            {
                case Objects.Alavanca:
                    if (playerCollider)
                    {
                        var component = gameObject.GetComponent<Alavanca>();
                        
                        component.alavanca = true;
                        component.tempo = component.tempototal;
                    }
                    break;
                
                case Objects.Armadilha:
                    if (!playerCollider)
                    Destroy(other.gameObject);
                    break;
                
                default:
                    break;
            }
            
            // play the event
            @event.Invoke();
        }
    }
}
