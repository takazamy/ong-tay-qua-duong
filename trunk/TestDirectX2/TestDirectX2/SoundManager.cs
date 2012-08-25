using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectSound;
using Microsoft.DirectX.AudioVideoPlayback;

namespace TestDirectX2
{
    class SoundManager
    {
        Audio music = new Audio("intro.wav");
        music = new Audio("intro.wav",true);
    }
}
