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
            var parent = CreateParent("KeyCodeInputs");
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                var provider = CreateProvider<NewbieInputKeyCodeProvider>(parent, $"KeyCodeProvider_{keyCode}");
                var so = new SerializedObject(provider);
                so.FindProperty("keyCode").intValue = (int)keyCode;
                so.ApplyModifiedPropertiesWithoutUndo();
            }

            EditorGUIUtility.PingObject(parent);
        }

        [MenuItem("Tools/DerpyNewbie/InputManager/Generate VRChat Axis Inputs")]
        public static void GenerateAxisInputs()
        {
            GenerateNamedInputs<NewbieInputAxisProvider>("AxisInputs", "AxisProvider", "axisName", VRChatAxisNames);
        }

        [MenuItem("Tools/DerpyNewbie/InputManager/Generate VRChat Button Inputs")]
        public static void GenerateButtonInputs()
        {
            GenerateNamedInputs<NewbieInputButtonProvider>("ButtonInputs", "ButtonProvider", "buttonName", VRChatButtonNames);
        }

        [MenuItem("Tools/DerpyNewbie/InputManager/Generate VRChat Input Provider Types")]
        public static void GenerateVRChatInputProviderTypes()
        {
            var parent = CreateParent("VRCInputs");
            var vrcInputProviderTypes = Assembly.GetAssembly(typeof(NewbieInputVRCProvider))
                .GetTypes()
                .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(NewbieInputVRCProvider)));
            foreach (var vrcInputProviderType in vrcInputProviderTypes)
            {
                var go = new GameObject($"VRCInputProvider_{vrcInputProviderType.Name}");
                go.transform.SetParent(parent.transform);
                go.AddComponent(vrcInputProviderType);
            }

            EditorGUIUtility.PingObject(parent);
        }

        private static void GenerateNamedInputs<T>(string parentName, string objectPrefix, string namePropertyPath, Dictionary<string, string> names)
            where T : NewbieInputProvider
        {
            var parent = CreateParent(parentName);
            foreach (var kvp in names)
            {
                var provider = CreateProvider<T>(parent, $"{objectPrefix}_{kvp.Key}");
                var so = new SerializedObject(provider);
                so.FindProperty(namePropertyPath).stringValue = kvp.Key;
                so.FindProperty("displayName").stringValue = kvp.Value;
                so.ApplyModifiedPropertiesWithoutUndo();
            }

            EditorGUIUtility.PingObject(parent);
        }

        private static GameObject CreateParent(string name)
        {
            var parent = new GameObject(name);
            Undo.RegisterCreatedObjectUndo(parent, $"Generate {name}");
            return parent;
        }

        private static T CreateProvider<T>(GameObject parent, string name) where T : Component
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent.transform);
            return go.AddComponent<T>();
        }
    }
}
