﻿namespace DiscoBot.Commands
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    
    using DiscoBot.DSA_Game;
    using DiscoBot.DSA_Game.Characters;

    using Discord.Commands;

    public class FileHandler : ModuleBase
    {
        [Command("send"), Summary("fügt Helden hinzu")]
        public async Task AddChar()
        {
            var msg = this.Context.Message;
            if (msg.Attachments == null)
            {
                throw new ArgumentException("Es wurde keine Datei angehängt");
            }

            var attachments = msg.Attachments.ToList();

            if (!attachments.Any(x => x.Filename.EndsWith(".xml")))
            {
                throw new ArgumentException("Es wurde kein xml Held mitgeschickt");
            }

            foreach (var attachment in attachments.Where(x => x.Filename.EndsWith(".xml")))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(attachment.Url, "helden\\" + attachment.Filename);
                }

                Dsa.Chars.Add(new Character("helden\\" + attachment.Filename));
                (Dsa.Chars.Last() as Character)?.Talente.Select(x => new Talent(x.Name, x.Probe, 0))
                    .Where(c => !Dsa.Talente.Exists(v => v.Name.Equals(c.Name))).ToList().ForEach(v => Dsa.Talente.Add(v));
            }
        }
    }
}