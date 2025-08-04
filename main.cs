using MelonLoader;
using Il2CppRUMBLE.Environment;
using Il2CppRUMBLE.Interactions.InteractionBase;
using RumbleModdingAPI;
using System.Collections;
using UnityEngine;

namespace InstantParkSearcher
{
    public class main : MelonMod
    {
        ParkBoardGymVariant parkBoardGymVariant;
        InteractionSlider interactionSlider;
        private string currentScene = "Loader";

        public override void OnLateInitializeMelon()
        {
            Calls.onMapInitialized += Init;
        }

        private void Init()
        {
            if (currentScene == "Gym")
            {
                parkBoardGymVariant = Calls.GameObjects.Gym.LOGIC.Heinhouserproducts.Parkboard.GetGameObject().GetComponent<ParkBoardGymVariant>();
                interactionSlider = Calls.GameObjects.Gym.LOGIC.Heinhouserproducts.Parkboard.PrimaryDisplay.GetGameObject().transform.GetChild(1).GetChild(0).GetChild(2).GetChild(8).gameObject.GetComponent<InteractionSlider>();
                interactionSlider.SetStep(1, false, false);
                MelonCoroutines.Start(ParkSearch());
            }
        }

        public IEnumerator ParkSearch()
        {
            yield return new WaitForSeconds(1);
            parkBoardGymVariant.OnFindRandomParkPressed();
            yield break;
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            currentScene = sceneName;
        }
    }
}
