using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    public class DVDPlayer : IPlayable
    {
        public void Pause()
        {
            Console.WriteLine("Dvd Player is Pushing");
        }
        public void Play()
        {
            Console.WriteLine("The dvd Player is playing");
        }
    }
}
