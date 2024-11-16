using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine.UIElements;

namespace Pigeon6.GridTool
{
    [Overlay(typeof(SceneView), "Grid Size Presets", defaultDisplay = true, defaultDockPosition = DockPosition.Bottom, defaultDockZone = DockZone.LeftToolbar)]
    [Icon("Packages/dev.pigeon6.gridsizepresets/Editor/Icon/GridSizePresets.png")]
    class GridSizePresets : Overlay
    {
        public override VisualElement CreatePanelContent()
        {
            var root = new VisualElement();

            var gridSizes = GridSizePresetSettings.instance.GridSizes;
            
            foreach(var i in gridSizes) 
            {
                root.Add(new Button(() => SetGridSize(i)) { text = i.ToString() });
            }
            
            return root;
        }

        private static void SetGridSize(int size)
        {
            var assembly = Assembly.Load("UnityEditor.dll");
            var gridSettings = assembly.GetType("UnityEditor.GridSettings");
            var gridSize = gridSettings.GetProperty("size");
            
            gridSize?.SetValue("size", new Vector3(size,size,size));            
        }        
    }
}