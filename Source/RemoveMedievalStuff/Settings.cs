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
        var gap = 8f;
        var listing_Standard = new Listing_Standard { ColumnWidth = canvas.width };
        listing_Standard.Begin(canvas);
        listing_Standard.Gap(gap);
        listing_Standard.CheckboxLabeled("ReMe.Items".Translate(), ref LimitItems,
            "ReMe.Items.Tooltip".Translate());
        listing_Standard.CheckboxLabeled("ReMe.Research".Translate(), ref LimitResearch,
            "ReMe.Research.Tooltip".Translate());
        listing_Standard.CheckboxLabeled("ReMe.Faction".Translate(), ref LimitFactions,
            "ReMe.Faction.Tooltip".Translate());
        listing_Standard.CheckboxLabeled("ReMe.Pawnkind".Translate(), ref LimitPawns,
            "ReMe.Pawnkind.Tooltip".Translate());
        listing_Standard.Gap(gap);
        listing_Standard.CheckboxLabeled("ReMe.Log".Translate(), ref LogRemovals,
            "ReMe.Log.Tooltip".Translate());
        listing_Standard.Gap(gap);
        listing_Standard.Label("ReMe.Restart".Translate());
        if (ModStuff.currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("ReMe.CurrentModVersion".Translate(ModStuff.currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
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