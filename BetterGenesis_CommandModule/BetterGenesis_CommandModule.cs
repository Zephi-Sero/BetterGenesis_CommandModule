using System;
using System.Collections.Generic;
using TheGenesisProjectModPatcher.Chat;
using TheGenesisProjectModPatcher.Mod;

namespace BetterGenesis_CommandModule {
    public class BetterGenesis_CommandModule : TGPMod {
        public override string ModName => "BetterGenesis_CommandModule";
        public override string ModVersion => "1.0.0";
        public override string ModAuthor => "zephyrouSerotonin";
        public override Pair<string,string>[] Dependencies => new Pair<string,string>[] {
            new Pair<string, string>("TheGenesisProjectModPatcher", "[0.2.0,0.3.0)")
        };
        private static List<string> modtags = new List<string>(new string[] { "commands" });
        private static List<string> loadafter = new List<string>(new string[] { "grist" });
        private static List<ChatCommand> cmds = new List<ChatCommand>();
        public override void PatchMod() {
            cmds.Add(new BetterGristCommand("grist"));
            cmds.Add(new PlayerTPCommand("tpto"));
            CommandAlias.RegisterAlias("pos", "position");
            CommandAlias.RegisterAlias("teleport", "position");
            CommandAlias.RegisterAlias("tp", "position");
            CommandAlias.RegisterAlias("xyz", "position");
            CommandAlias.RegisterAlias("exp", "xp");
            CommandAlias.RegisterAlias("experience", "xp");
            CommandAlias.RegisterAlias("money", "boon");
            CommandAlias.RegisterAlias("goto", "tpto");
            CommandAlias.RegisterAlias("visit", "tpto");
        }
    }
}
