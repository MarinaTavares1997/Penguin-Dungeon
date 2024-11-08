using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Networking;

namespace PenguinDungeon.Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textUGUI;
        [SerializeField] private string dialogueFile;

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
        
        public void Button()
        {
            WriteText();
        }

        private void WriteText()
        {
            if (texts is null)
            {
                var filePath = FilePath + dialogueFile + ".json";

                if (Application.platform == RuntimePlatform.Android)
                {
                    StartCoroutine(LoadDialogueFromStreamingAssets(filePath));
                }
                else
                {
                    if (!File.Exists(filePath))
                    {
                        throw new Exception($"O arquivo {dialogueFile}.json não existe.\n Caminho: {filePath}");
                    }

                    var file = File.ReadAllText(filePath);
                    texts = JsonUtility.FromJson<DialogueFile>(file).text;
                    DisplayText();
                }
            }
            else
            {
                DisplayText();
            }
        }

        private IEnumerator LoadDialogueFromStreamingAssets(string filePath)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(filePath))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Erro ao carregar o arquivo JSON: {request.error}");
                }
                else
                {
                    var file = request.downloadHandler.text;
                    texts = JsonUtility.FromJson<DialogueFile>(file).text;
                    DisplayText();
                }
            }
        }

        private void DisplayText()
        {
            var endDialogue = currentTextIndex >= texts.Length;
            if (endDialogue)
            {
                onDialogueEnds.Invoke();
                Destroy(gameObject);
                return;
            }

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

