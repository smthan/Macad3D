﻿using Macad.Common;

namespace Macad.Interaction;

[ParameterSet]
public sealed partial class ViewportParameterSet
{
    Parameter<int> _SketchSelectionSensitivity = new()
    {
        Name = "SketchSelectionSensitivity",
        DefaultValue = 1,
        Description = "Adjusts the sensitivity of selecting sketch entities. Higher values make selection easier but may lead to unintended selections.",
        EditorHints = new() { { "MinValue", 1 }, { "MaxValue", 20 } },
        Flags = Parameter.ParameterFlags.NeedsRestart
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<int> _SelectionPixelTolerance = new()
    {
        Name = "SelectionPixelTolerance",
        DefaultValue = 5,
        Description = "Defines the pixel tolerance for selecting elements in the viewport. Higher values make selection easier but may lead to unintended selections.",
        EditorHints = new() { { "Units", "Pixel" }, { "MinValue", 1 }, { "MaxValue", 20 } },
        Flags = Parameter.ParameterFlags.NeedsRestart
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<bool> _ShowViewCube = new()
    {
        Name = "ShowViewCube",
        DefaultValue = true,
        Description = "Toggles the visibility of the view cube in the viewport."
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<uint> _ViewCubeSize = new()
    {
        Name = "ViewCubeSize",
        DefaultValue = 100u,
        Description = "Sets the size of the view cube in the viewport.",
        EditorHints = new() { { "Units", "Percent" }, { "MinValue", 10u }, { "MaxValue", 200u }, { "IncDecStep", 10 } }
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<double> _ViewCubeAnimationDuration = new()
    {
        Name = "ViewCubeAnimationDuration",
        DefaultValue = 0.3,
        Description = "Defines the duration of the view cube rotation animation in seconds.",
        EditorHints = new() { { "Units", "Seconds" }, { "MinValue", 0.1 }, { "MaxValue", 10.0 }, { "Precision", 1 } }
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<bool> _ShowTrihedron = new()
    {
        Name = "ShowTrihedron",
        DefaultValue = true,
        Description = "Toggles the visibility of the trihedron (axis indicator) in the viewport."
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<uint> _VisualGridStepMinPixel = new()
    {
        Name = "VisualGridStepMinPixel",
        DisplayName = "Minimum Grid Pixel Size",
        DefaultValue = 10u,
        Description = "Sets the minimum pixel size for each step of the grid before the grid step is automatically increased.",
        EditorHints = new() { { "Units", "Pixel" }, { "MinValue", 1u }, { "MaxValue", 50u } }
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<uint> _VisualGridMinStepsOnScreen = new()
    {
        Name = "VisualGridMinStepsOnScreen",
        DisplayName = "Minimum Visible Grid Steps",
        DefaultValue = 10u,
        Description = "Defines the minimum number of grid steps that should be visible on the screen before the grid step is automatically subdivided.",
        EditorHints = new() { { "MinValue", 5u }, { "MaxValue", 50u } }
    };

    //--------------------------------------------------------------------------------------------------

    Parameter<bool> _EnableAntialiasing = new()
    {
        Name = "EnableAntialiasing",
        DefaultValue = true,
        Description = "Enables or disables antialiasing in the viewport for improved visual quality for the cost of performance.",
        Flags = Parameter.ParameterFlags.NeedsRestart
    };

    //--------------------------------------------------------------------------------------------------

}