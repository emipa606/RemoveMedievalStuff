using HarmonyLib;
using RimWorld;

namespace RemoveMedievalStuff;

[HarmonyPatch(typeof(ThingSetMaker), nameof(ThingSetMaker.Generate), typeof(ThingSetMakerParams))]
public static class ThingSetMaker_Generate
{
    public static void Prefix(ref ThingSetMakerParams parms)
    {
        if (parms.techLevel is null or > RemoveMedievalStuff.MaxTechlevel)
        {
            parms.techLevel = RemoveMedievalStuff.MaxTechlevel;
        }
    }
}