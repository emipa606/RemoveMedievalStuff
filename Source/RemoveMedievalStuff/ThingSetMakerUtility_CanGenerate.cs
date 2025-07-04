using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RemoveMedievalStuff;

[HarmonyPatch(typeof(ThingSetMakerUtility), nameof(ThingSetMakerUtility.CanGenerate))]
public static class ThingSetMakerUtility_CanGenerate
{
    public static void Prefix(ThingDef thingDef, ref bool __result)
    {
        __result &= !RemoveMedievalStuff.Things.Contains(thingDef);
    }
}