using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGenesisProjectModPatcher;
using TheGenesisProjectModPatcher.Chat;

namespace BetterGenesis_CommandModule {
    public class BetterGristCommand : ChatCommand {
            public static List<string> grists = new string[] {
                "build"      ,"artifact" ,"zillium"    ,"garnet"      ,"jasper"     ,"caulk"   ,"titanium"  ,
                "quartz"     ,"turquoise","blueagate"  ,"tar"         ,"cinnabar"   ,"sapphire","sard"      ,
                "mercury"    ,"cyanide"  ,"malachite"  ,"diamond"     ,"alexandrite","francium","blood"     ,
                "lapislazuli","opal"     ,"ruby"       ,"spiritite"   ,"honey"      ,"gold"    ,"rosequartz",
                "uranium"    ,"pearl"    ,"hydrogen"   ,"polychromite","emerald"    ,"cobalt"  ,"greymatter",
                "nectar"     ,"marble"   ,"peridot"    ,"saccharite"  ,"ichor"      ,"rain"    ,"chalk"     ,
                "solar"      ,"onyx"     ,"null"       ,"starlight"   ,"generic"    ,"obsidian","shale"     ,
                "darkness"   ,"dew"      ,"rust"       ,"sugilite"    ,"amethyst"   ,"wax"     ,"xenon"     ,
                "sulfur"     ,"topaz"    ,"smokyquartz","iodine"      ,"amber"      ,"mahogany","bloodstone"
            }.ToList();
        public BetterGristCommand(string cmd) : base(cmd) {
            SetHelp("/grist <amount> <ID|gristname>\nExamples: /grist 10 garnet\n/grist 10 3");
            SetSafe(true);
        }
        public override bool RunCommand(string args) {
            string[] array = args.Trim().Split(' ');
            if(array.Length > 1) {
                Player.GristHolder grist = Player.player.Grist;
                if(int.TryParse(array[1], out int amount)) {
                    if(int.TryParse((array.Length == 3) ? array[2] : "0", out int index)) {
                        grist[index] += amount;
                        return true;
                    } else {
                        int index2 = grists.IndexOf(array[2].ToLowerInvariant());
                        if(index2 != -1) {
                            grist[index2] += amount;
                            return true;
                        } else {
                            GlobalChat.WriteCommandMessage("<color=red>Error adding grist: No such grist type '" + array[2] + "'</color>\n");
                        }
                    }
                } else {
                    GlobalChat.WriteCommandMessage("<color=red>Error adding grist: '" + array[1] + "' is not a valid amount</color>\n");
                }
            } else {
                GlobalChat.WriteCommandMessage("<color=red>Invalid usage</color>\n" + this.help);
            }
            return false;
        }
    }
}
