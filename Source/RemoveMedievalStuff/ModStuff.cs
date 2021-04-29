using UnityEngine;
using Verse;

namespace RemoveMedievalStuff
{
    public class ModStuff : Mod
    {
        public static Settings Settings;

        public ModStuff(ModContentPack content) : base(content)
        {
            Settings = GetSettings<Settings>();
        }

        public override string SettingsCategory()
        {
            return "Remove Medieval Stuff";
        }

        public override void DoSettingsWindowContents(Rect canvas)
        {
            Settings.DoWindowContents(canvas);
        }
    }
}