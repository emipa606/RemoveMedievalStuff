using UnityEngine;
using Verse;

namespace RemoveMedievalStuff;

public class Settings : ModSettings
{
    public bool LimitFactions = true;

    public bool LimitItems = true;

    public bool LimitPawns = true;

    public bool LimitResearch = true;

    public bool LogRemovals;

    public void DoWindowContents(Rect canvas)
    {
        const float gap = 8f;
        var listingStandard = new Listing_Standard { ColumnWidth = canvas.width };
        listingStandard.Begin(canvas);
        listingStandard.Gap(gap);
        listingStandard.CheckboxLabeled("ReMe.Items".Translate(), ref LimitItems,
            "ReMe.Items.Tooltip".Translate());
        listingStandard.CheckboxLabeled("ReMe.Research".Translate(), ref LimitResearch,
            "ReMe.Research.Tooltip".Translate());
        listingStandard.CheckboxLabeled("ReMe.Faction".Translate(), ref LimitFactions,
            "ReMe.Faction.Tooltip".Translate());
        listingStandard.CheckboxLabeled("ReMe.Pawnkind".Translate(), ref LimitPawns,
            "ReMe.Pawnkind.Tooltip".Translate());
        listingStandard.Gap(gap);
        listingStandard.CheckboxLabeled("ReMe.Log".Translate(), ref LogRemovals,
            "ReMe.Log.Tooltip".Translate());
        listingStandard.Gap(gap);
        listingStandard.Label("ReMe.Restart".Translate());
        if (ModStuff.CurrentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("ReMe.CurrentModVersion".Translate(ModStuff.CurrentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref LimitItems, "LimitItems", true);
        Scribe_Values.Look(ref LimitResearch, "LimitResearch", true);
        Scribe_Values.Look(ref LimitFactions, "LimitFactions", true);
        Scribe_Values.Look(ref LimitPawns, "LimitPawns", true);
        Scribe_Values.Look(ref LogRemovals, "LogRemovals");
    }
}