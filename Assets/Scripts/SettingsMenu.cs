using UnityEngine;
using UnityEngine.UI;

namespace PenguinDungeon
{
    public class SettingsMenu : MonoBehaviour
    {
        public Dropdown DResolution;

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        // ReSharper disable once UnusedMember.Global
        public void SetResolution()
        {
            switch (DResolution.value)
            {
                case 0:
                    Screen.SetResolution(640, 360, true);
                    break;
            
                case 1:
                    Screen.SetResolution(1280, 720, true);
                    break;

                case 2:
                    Screen.SetResolution(1366, 768, true);
                    break;
            }
        }
    }
}
