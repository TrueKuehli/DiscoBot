﻿namespace DiscoBot.Audio
{
    using System;
    using System.Threading.Tasks;

    using DiscoBot.Commands;

    public enum Sound
    {
        Bell,
        Ding,
        Nooo,
        Monsterkill,
        Finish,
        Wrong,
        Magic,
        Stupid,
        Police,
        Roblox
    }

    public static class SoundEffects
    {
        public static int Volume { get; set; } = 50;

        public static async Task Play(Sound s)
        {
            string url = string.Empty;
            int volume = 256;
            switch (s)
            {
                case Sound.Bell:
                case Sound.Ding:
                    url = "https://www.myinstants.com/media/sounds/boxing-bell.mp3";
                    break;
                case Sound.Finish:
                    url = "https://www.myinstants.com/media/sounds/finishhim.swf.mp3";
                    break; 
                case Sound.Magic:
                    url = "https://www.myinstants.com/media/sounds/dream-harp-sound-effect.mp3";
                    break;
                case Sound.Monsterkill:
                    url = "https://www.myinstants.com/media/sounds/announcer_kill_monster_01.mp3";
                    break;
                case Sound.Nooo:
                    url = "https://www.myinstants.com/media/sounds/nooo.swf.mp3";
                    break;
                case Sound.Roblox:
                    url = "https://www.myinstants.com/media/sounds/roblox-death-sound_ytkBL7X.mp3";
                    break;
                case Sound.Stupid:
                    url = "https://www.myinstants.com/media/sounds/stupid_dum_03.mp3";
                    volume = 10;
                    break;
                case Sound.Police:
                    url = "https://www.myinstants.com/media/sounds/sound-of-the-police.mp3";
                    break;
                case Sound.Wrong:
                    url = "https://www.myinstants.com/media/sounds/wrong-answer-sound-effect.mp3";
                    volume = 50;
                    break; 
            }

            volume = (int)(volume * (Volume / 100.0));


            if (url != string.Empty)
            {
                // await Dsa.Service.SendAudioAsync(url, vol);
                Voice.SendAsync(url, volume);
                return;
            }

            throw new Exception("Ton Existiert nicht");
        }
    }
}
