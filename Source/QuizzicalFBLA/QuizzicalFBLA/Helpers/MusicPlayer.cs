using System;
using System.Collections.Generic;
using Plugin.SimpleAudioPlayer;

namespace QuizzicalFBLA.Helpers
{
    public class MusicPlayer
    {
        private static MusicPlayer musicPlayer;
        private Dictionary<string, ISimpleAudioPlayer> sounds;
        private string currentSong = "";

        private MusicPlayer()
        {
            // Load sound effects
            sounds = new Dictionary<string, ISimpleAudioPlayer>();

            sounds.Add("tenseMusic", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            sounds.Add("daftCat", CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());


            sounds["tenseMusic"].Load("tenseMusic.mp3");
            sounds["tenseMusic"].Loop = true;

            sounds["daftCat"].Load("daftcat.mp3");
            sounds["daftCat"].Loop = true;
        }

        public static MusicPlayer Current
        {
            get
            {
                if (musicPlayer == null)
                {
                    musicPlayer = new MusicPlayer();
                }
                return musicPlayer;
            }
        }

        public void Pause ()
        {
            foreach (string song in sounds.Keys)
            {
                if (sounds[song].IsPlaying)
                    sounds[song].Pause();
            }
        }

        public void Resume()
        {
            if (sounds.ContainsKey(currentSong))
            {
                if (!sounds[currentSong].IsPlaying)
                sounds[currentSong].Play();
            }
        }

        public void Play (string songKey)
        {
            if (sounds.ContainsKey(songKey))
            {
                currentSong = songKey;

                if (sounds[currentSong].IsPlaying)
                    return;
            }
            else
            {
                currentSong = "";
            }

            // Pause every other song and then continue with the new song
            Pause();
            Resume();
        }
    }
}
