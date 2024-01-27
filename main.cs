using MelonLoader;
using RUMBLE.Environment;
using UnityEngine;

namespace InstantParkSearcher
{
    public class main : MelonMod
    {
        ParkBoardGymVariant parkBoardGymVariant;
        private string currentScene = "";
        private bool sceneChanged = false;

        public override void OnFixedUpdate()
        {
            if (sceneChanged)
            {
                try
                {
                    if (currentScene == "Gym")
                    {
                        parkBoardGymVariant = GameObject.Find("--------------LOGIC--------------/Heinhouser products/Parkboard").GetComponent<ParkBoardGymVariant>();
                        parkBoardGymVariant.OnHostJoinSliderChanged(1);
                        parkBoardGymVariant.OnFindRandomParkPressed();
                        sceneChanged = false;
                    }
                }
                catch { }
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            currentScene = sceneName;
            sceneChanged = true;
        }
    }
}
