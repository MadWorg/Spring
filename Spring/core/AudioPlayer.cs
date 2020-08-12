using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class AudioPlayer
    {

        private const float _maxVolume = 1f;

        private const float _minVolume = 0f;

        private float _volume = 0.5f;

        public void PlaySong(Song song)
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
        }

        public void PlaySound(SoundEffect soundEffect)
        {
            soundEffect.Play(_volume, 0f, 0f);
        }

        public void SetVolume(bool increase)
        {
            if(increase)
            {
                if(_volume < _maxVolume)
                {
                _volume += 0.05f;
                }
            }
            else
            {
                if(_volume > _minVolume)
                {
                _volume -= 0.05f;
                }
            }

            MediaPlayer.Volume = _volume;
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
        }

    }
}
