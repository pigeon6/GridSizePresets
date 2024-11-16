using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Pigeon6.GridTool
{
    [FilePath("GridSizePresetSettings.asset", FilePathAttribute.Location.PreferencesFolder)]
    public class GridSizePresetSettings : ScriptableSingleton<GridSizePresetSettings>
    {
        [SerializeField] private List<int> _gridSizes = new List<int> { 1, 5, 20 };

        public List<int> GridSizes => _gridSizes;

        [SettingsProvider]
        public static SettingsProvider CreateGridSizePresetSettingsProvider()
        {
            var provider = new SettingsProvider("Preferences/Grid Size Presets", SettingsScope.User)
                           {
                               label = "Grid Size Presets",
                               // Create the SettingsProvider and initialize its drawing (IMGUI) function in place:
                               guiHandler = (searchContext) =>
                               {
                                   var settings = new SerializedObject(instance);
                                   EditorGUILayout.PropertyField(settings.FindProperty("_gridSizes"), new GUIContent("Grid Sizes"), true);
                                   if (settings.ApplyModifiedPropertiesWithoutUndo())
                                   {
                                       instance.Save(false);
                                   }
                               },

                               // Populate the search keywords to enable smart search filtering and label highlighting:
                               keywords = new HashSet<string>(new[] { "Grid", "Size", "Presets" })
                           };

            return provider;
        }
    }
}