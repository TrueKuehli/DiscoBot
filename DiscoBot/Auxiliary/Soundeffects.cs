﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoBot.Auxiliary
{
    using DiscoBot.Commands;

    public enum Sound
    {
        Ding,
        Nooo,
        Monterkill,
        Finish,
        Wrong
    }

    public static class SoundEffects
    {
        public static Task Play(Sound s)
        {
            string url = string.Empty;
            int vol = 256;
            switch (s)
            {
                case Sound.Ding:
                    url = "https://www.myinstants.com/media/sounds/boxing-bell.mp3";
                    break;
                case Sound.Finish:
                    url = "https://www.myinstants.com/media/sounds/finishhim.swf.mp3";
                    break;
                case Sound.Monterkill:
                    url = "https://www.myinstants.com/media/sounds/announcer_kill_monster_01.mp3";
                    break;
                case Sound.Nooo:
                    url = "https://www.myinstants.com/media/sounds/nooo.swf.mp3";
                    break;
                case Sound.Wrong:
                    url = "https://www.myinstants.com/media/sounds/stupid_dum_03.mp3";
                    vol = 10;
                    break;
            }

            if (url != string.Empty)
            {
                return Voice.SendAsync(url, vol);
            }

            return Dsa.GeneralContext.Channel.SendMessageAsync("Ton Existiert nicht");
        }
    }
}