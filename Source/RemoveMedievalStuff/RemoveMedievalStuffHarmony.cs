using System;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RemoveMedievalStuff
{
    [StaticConstructorOnStartup]
    public static class RemoveMedievalStuffHarmony
    {
        static RemoveMedievalStuffHarmony()
        {
            var harmony = new Harmony("Mlie.RemoveMedievalStuff");
            harmony.Patch(AccessTools.Method(typeof(ThingSetMaker), "Generate", new[] {typeof(ThingSetMakerParams)}), new HarmonyMethod(typeof(RemoveMedievalStuffHarmony), nameof(ItemCollectionGeneratorGeneratePrefix)));

            // Log.Message("AddToTradeables");
            harmony.Patch(AccessTools.Method(typeof(TradeDeal), "AddToTradeables"), new HarmonyMethod(typeof(RemoveMedievalStuffHarmony), nameof(PostCacheTradeables)));

            // Log.Message("CanGenerate");
            harmony.Patch(AccessTools.Method(typeof(ThingSetMakerUtility), nameof(ThingSetMakerUtility.CanGenerate)), null, new HarmonyMethod(typeof(RemoveMedievalStuffHarmony), nameof(ThingSetCleaner)));
            harmony.Patch(AccessTools.Method(typeof(FactionManager), "FirstFactionOfDef", new[] {typeof(FactionDef)}), new HarmonyMethod(typeof(RemoveMedievalStuffHarmony), nameof(FactionManagerFirstFactionOfDefPrefix)));

            harmony.Patch(AccessTools.Method(typeof(BackCompatibility), "FactionManagerPostLoadInit", Array.Empty<Type>()), new HarmonyMethod(typeof(RemoveMedievalStuffHarmony), nameof(BackCompatibilityFactionManagerPostLoadInitPrefix)));
        }

        public static bool BackCompatibilityFactionManagerPostLoadInitPrefix()
        {
            return !ModStuff.Settings.LimitFactions;
        }

        public static bool FactionManagerFirstFactionOfDefPrefix(ref FactionDef facDef)
        {
            return !ModStuff.Settings.LimitFactions || facDef == null || facDef.techLevel <= RemoveMedievalStuff.MAX_TECHLEVEL;
        }

        public static void ItemCollectionGeneratorGeneratePrefix(ref ThingSetMakerParams parms)
        {
            if (!parms.techLevel.HasValue || parms.techLevel > RemoveMedievalStuff.MAX_TECHLEVEL)
            {
                parms.techLevel = RemoveMedievalStuff.MAX_TECHLEVEL;
            }
        }

        public static bool PostCacheTradeables(Thing t)
        {
            return !RemoveMedievalStuff.things.Contains(t.def);
        }

        public static void ThingSetCleaner(ThingDef thingDef, ref bool __result)
        {
            __result &= !RemoveMedievalStuff.things.Contains(thingDef);
        }
    }
}