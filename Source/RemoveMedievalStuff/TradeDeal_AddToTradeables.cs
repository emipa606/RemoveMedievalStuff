using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RemoveMedievalStuff;

[HarmonyPatch(typeof(TradeDeal), "AddToTradeables")]
public static class TradeDeal_AddToTradeables
{
    public static bool Prefix(Thing t)
    {
        return !RemoveMedievalStuff.Things.Contains(t.def);
    }
}