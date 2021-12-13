using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;
using System;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class ManageLivesService
    {

        List<Actor> _lives = new List<Actor>();
        AudioService _audioService = new AudioService();
        public ManageLivesService()
        {
        }


        public void AddLife()
        {
            if (_lives.Count > 0)
            {
                int lastIndex = _lives.Count - 1;
                Actor lastLife = _lives[lastIndex];
                Actor newLife = new Life (lastLife.GetX() + 100, lastLife.GetY());
                _lives.Add(newLife);
            }

            else 
            {
                Actor newLife = new Life (Constants.LIFE_X, Constants.LIFE_Y);
                _lives.Add(newLife);
            }
        }

        public void RemoveLife()
        {
            if (_lives.Count > 0)
            {
                _audioService.PlaySound(Constants.SOUND_LOSE_LIFE);
                _lives.RemoveAt(_lives.Count - 1);
            }
        }

        public List<Actor> GetLives()
        {
            return _lives;
        }
        

    }
}