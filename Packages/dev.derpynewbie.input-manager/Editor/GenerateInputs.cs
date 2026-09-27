using DerpyNewbie.InputMan.Providers.UnityInput;
using DerpyNewbie.InputMan.Providers.VRChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
namespace DerpyNewbie.InputMan.Editor
{
    public class GenerateInputs
    {
        private static readonly Dictionary<string, string> VRChatAxisNames = new Dictionary<string, string>
        {
            { "Oculus_CrossPlatform_PrimaryIndexTrigger", "Left Trigger" },
            { "Oculus_CrossPlatform_SecondaryIndexTrigger", "Right Trigger" },
            { "Oculus_CrossPlatform_PrimaryHandTrigger", "Left Grab" },
            { "Oculus_CrossPlatform_SecondaryHandTrigger", "Right Grab" },
            { "Horizontal", "Left Thumbstick X" },
            { "Vertical", "Left Thumbstick Y" },
            { "Oculus_CrossPlatform_SecondaryThumbstickHorizontal", "Right Thumbstick X" },
            { "Oculus_CrossPlatform_SecondaryThumbstickVertical", "Right Thumbstick Y" },
        };

        private static readonly Dictionary<string, string> VRChatButtonNames = new Dictionary<string, string>
        {
            { "Oculus_CrossPlatform_PrimaryThumbstick", "Left Thumbstick Click" },
            { "Oculus_CrossPlatform_SecondaryThumbstick", "Right Thumbstick Click" },
            { "Jump", "Jump" },
            { "Fire2", "Fire2" },
            { "Oculus_CrossPlatform_Button4", "Left Menu" },
            { "Oculus_CrossPlatform_Button2", "Right Menu" },
        };

        [MenuItem("Tools/DerpyNewbie/InputManager/Generate KeyCode Inputs")]
        public static void GenerateKeyCodeInputs()
        {
            var parent = new GameObject("KeyCodeInputs");
            var keyCodes = (KeyCode[])Enum.GetValues(typeof(KeyCode));
            for (var i = 0; i < keyCodes.Length; i++)
            {
                var keyCode = keyCodes[i];
                var go = new GameObject($"KeyCodeProvider_{keyCode}");
                go.transform.SetParent(parent.transform);
                var keyCodeProvider = go.AddComponent<NewbieInputKeyCodeProvider>();
                var keyCodeProviderSo = new SerializedObject(keyCodeProvider);
                keyCodeProviderSo.FindProperty("keyCode").enumValueIndex = i;
                keyCodeProviderSo.ApplyModifiedProperties();
            }
            EditorGUIUtility.PingObject(parent);
        }

        [MenuItem("Tools/DerpyNewbie/InputManager/Generate VRChat Axis Inputs")]
        public static void GenerateAxisInputs()
        {
            var parent = new GameObject("AxisInputs");
            foreach (var axisNameKvp in VRChatAxisNames)
            {
                var go = new GameObject($"AxisProvider_{axisNameKvp.Key}");
                go.transform.SetParent(parent.transform);
                var axisProvider = go.AddComponent<NewbieInputAxisProvider>();
                var axisProviderSo = new SerializedObject(axisProvider);
                axisProviderSo.FindProperty("axisName").stringValue = axisNameKvp.Key;
                axisProviderSo.FindProperty("displayName").stringValue = axisNameKvp.Value;
                axisProviderSo.ApplyModifiedProperties();
            }
            EditorGUIUtility.PingObject(parent);
        }

        [MenuItem("Tools/DerpyNewbie/InputManager/Generate VRChat Button Inputs")]
        public static void GenerateButtonInputs()
        {
            var parent = new GameObject("ButtonInputs");
            foreach (var buttonNameKvp in VRChatButtonNames)
            {
                var go = new GameObject($"ButtonProvider_{buttonNameKvp.Key}");
                go.transform.SetParent(parent.transform);
                var buttonProvider = go.AddComponent<NewbieInputButtonProvider>();
                var buttonProviderSo = new SerializedObject(buttonProvider);
                buttonProviderSo.FindProperty("buttonName").stringValue = buttonNameKvp.Key;
                buttonProviderSo.FindProperty("displayName").stringValue = buttonNameKvp.Value;
                buttonProviderSo.ApplyModifiedProperties();
            }
            EditorGUIUtility.PingObject(parent);
        }

        [MenuItem("Tools/DerpyNewbie/InputManager/Generate VRChat Input Provider Types")]
        public static void GenerateVRChatInputProviderTypes()
        {
            var parent = new GameObject("VRCInputs");
            var vrcInputProviderTypes = Assembly.GetAssembly(typeof(NewbieInputVRCProvider)).GetTypes().Where(t => t.IsSubclassOf(typeof(NewbieInputVRCProvider))).ToArray();
            foreach (var vrcInputProviderType in vrcInputProviderTypes)
            {
                var go = new GameObject($"VRCInputProvider_{vrcInputProviderType.Name}");
                go.transform.SetParent(parent.transform);
                go.AddComponent(vrcInputProviderType);
            }
            EditorGUIUtility.PingObject(parent);
        }
    }
}
