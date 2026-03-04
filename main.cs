using MelonLoader;
using Il2CppRUMBLE.Environment;
using Il2CppRUMBLE.Interactions.InteractionBase;
using RumbleModdingAPI.RMAPI;
using System.Collections;
using UnityEngine;

namespace InstantParkSearcher
{
    public class main : MelonMod
    {
        ParkBoardGymVariant parkBoardGymVariant;
        InteractionSlider interactionSlider;

        public override void OnLateInitializeMelon()
        {
            Actions.onMapInitialized += Init;
        }

        private void Init(string map)
        {
            if (map == "Gym")
            {
                parkBoardGymVariant = GameObjects.Gym.INTERACTABLES.Parkboard.GetGameObject().GetComponent<ParkBoardGymVariant>();
                interactionSlider = GameObjects.Gym.INTERACTABLES.Parkboard.PrimaryDisplay.Gym.ParkMode.InteractionSliderHorizontalGrip.Sliderhandle.GetGameObject().GetComponent<InteractionSlider>();
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
    }
}
