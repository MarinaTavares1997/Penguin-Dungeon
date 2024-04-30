using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace PenguinDungeon.Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textUGUI;
        [SerializeField] private string dialogueFile ;

        [SerializeField] private bool startOnAwake;
        [SerializeField] private UnityEvent onDialogueEnds;

        private static readonly string FilePath = Application.streamingAssetsPath + "/Dialogues/";

        private int currentTextIndex;
        private string[] texts;

        private void Start()
        {
            if (startOnAwake)
            {
                WriteText();
            }
        }
        
        /// <summary>
        /// Pass to Next Dialogue
        /// </summary>
        public void Button()
        {
            WriteText();
        }

        private void WriteText()
        {
            if (texts is null)
            {
                var filePath = FilePath + dialogueFile + ".json";
                
                if (!File.Exists(filePath))
                {
                    throw new Exception($"The file {dialogueFile}.json not exists.\n Path: {filePath}");
                }
                
                var file = File.ReadAllText(filePath);
                texts = JsonUtility.FromJson<DialogueFile>(file).text;
            }
            
            var endDialogue = currentTextIndex >= texts.Length;
            if (endDialogue)
            {
                onDialogueEnds.Invoke();
                Destroy(gameObject);
                return;
            }
            
            // write the text in screen
            textUGUI.text = texts[currentTextIndex];
            currentTextIndex++;
        }
        
        [Serializable]
        private class DialogueFile
        {
            public string[] text;
        }
    }
}