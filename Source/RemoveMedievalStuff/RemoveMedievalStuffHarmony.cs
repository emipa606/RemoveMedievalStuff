using System.Reflection;
using HarmonyLib;
using Verse;

namespace RemoveMedievalStuff;

[StaticConstructorOnStartup]
public static class RemoveMedievalStuffHarmony
{
    static RemoveMedievalStuffHarmony()
    {
        new Harmony("Mlie.RemoveMedievalStuff").PatchAll(Assembly.GetExecutingAssembly());
    }
}