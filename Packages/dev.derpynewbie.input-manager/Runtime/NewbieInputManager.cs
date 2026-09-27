using DerpyNewbie.Common;
using UdonSharp;
using UnityEngine;
namespace DerpyNewbie.InputMan
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class NewbieInputManager : UdonSharpBehaviour
    {
        [SerializeField] [NewbieInject]
        private NewbieInputProvider[] inputProviders;
        
        public NewbieInputProvider[] InputProviders => inputProviders;
    }
}
