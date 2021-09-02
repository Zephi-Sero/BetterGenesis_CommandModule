using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TheGenesisProjectModPatcher;
using TheGenesisProjectModPatcher.Chat;

namespace BetterGenesis_CommandModule {
    public class PlayerTPCommand : ChatCommand {
        public PlayerTPCommand(string cmd) : base(cmd) {
            SetHelp("/tpto <playerid|handle>\nExamples: /tpto exampleHandle\n/tpto EH\n/tpto 1234567");
            SetSafe(true);
        }
        public override bool RunCommand(string args) {
            string[] array = args.Trim().Split(' ');
            if(array.Length == 2) {
                Player local = Player.player;
                if(int.TryParse(array[1], out int id)) {
                    Player remote = NetcodeManager.Instance.GetPlayer(id);
                    if(remote != null) {
                        local.SetPosition(remote.GetPosition());
                        return true;
                    } else {
                        GlobalChat.WriteCommandMessage("<color=red>Error teleporting to player by ID '" + array[1] + "', player by that ID not found</color>");
                    }
                } else {
                    int playerid = -1;
                    Regex r = new Regex("(?!^)[^A-Z]");
                    foreach(NetworkPlayer np in NetcodeManager.Instance.GetPlayers()) {
                        if(np.name.ToLowerInvariant() == array[1].ToLowerInvariant() || r.Replace(np.name, "").ToLowerInvariant() == array[1].ToLowerInvariant()) {
                            playerid = np.id;
                            break;
                        }
                    }
                    Player remote = NetcodeManager.Instance.GetPlayer(playerid);
                    if(playerid == 0) remote = Player.player;
                    if(remote != null) {
                        local.SetPosition(remote.GetPosition());
                        return true;
                    } else {
                        GlobalChat.WriteCommandMessage("<color=red>Error teleporting to player '" + array[1] + "', player by that handle not found</color>");
                    }
                }
            } else {
                GlobalChat.WriteCommandMessage("<color=red>Invalid usage</color>\n" + this.help);
            }
            return false;
        }
    }
}
