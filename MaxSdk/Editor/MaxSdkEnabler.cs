using System.Collections.Generic;
using System.Linq;
using UnityEditor;

[InitializeOnLoad]
public class MaxSdkEnabler : Editor
{
    /// <summary>
    /// Symbols that will be added to the editor
    /// </summary>
    public static readonly string [] Symbols = new string[] {
        "MaxSdk_Enabled",
    };
 
    /// <summary>
    /// Add define symbols as soon as Unity gets done compiling.
    /// </summary>
    static MaxSdkEnabler ()
    {
        string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup ( EditorUserBuildSettings.selectedBuildTargetGroup );
        List<string> allDefines = definesString.Split ( ';' ).ToList ();
        allDefines.AddRange ( Symbols.Except ( allDefines ) );
        PlayerSettings.SetScriptingDefineSymbolsForGroup (
            EditorUserBuildSettings.selectedBuildTargetGroup,
            string.Join ( ";", allDefines.ToArray () ) );
    }
    [DidReloadScripts]
    private static void OnScriptsReloaded()
    {
        string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup ( EditorUserBuildSettings.selectedBuildTargetGroup );
        List<string> allDefines = definesString.Split ( ';' ).ToList ();
        allDefines.AddRange ( Symbols.Except ( allDefines ) );
        PlayerSettings.SetScriptingDefineSymbolsForGroup (
        EditorUserBuildSettings.selectedBuildTargetGroup,
        string.Join ( ";", allDefines.ToArray () ) );
    }

}
