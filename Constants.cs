using System;
using System.Collections.Generic;

namespace dark_manor
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 1200;
        public const int SCREEN_SECTION_ONE = 400;
        public const int SCREEN_SECTION_THREE = 800;

        public const int LOWER_BOUND = 600;
        public const int MAX_Y = 800;
        public const int FRAME_RATE = 30;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 155;
        public const int DEFAULT_TEXT_OFFSET = 4;

        public const string IMAGE_WALL = "./Assets/wall.png";
        public const string IMAGE_HERO = "./Assets/hero.png";
        public const string IMAGE_LIFE = "./Assets/life.png";
        public const string IMG_CHARACTER = "./Assets/character.png";

        public const string SOUND_START = "./Assets/start.wav";
        public const string SOUND_JUMP = "./Assets/jump.wav";
        public const string SOUND_OVER = "./Assets/game_over.wav";
        public const string SOUND_KILL =  "./Assets/kill.wav";
        public const string SOUND_LOSE_LIFE =  "./Assets/lose_life.wav";
        public const string SOUND_WIN =  "./Assets/win.wav";



        public const int BALL_X = MAX_X / 2;
        public const int BALL_Y = MAX_Y - 125;

        public const int BALL_DX = 8;
        public const int BALL_DY = BALL_DX * -1;

        public const int HERO_X = SCREEN_SECTION_ONE + 25;
        public const int HERO_Y = 100;

        public const int WALL_WIDTH = 200;
        public const int WALL_HEIGHT = 200;

        public readonly static int[][] WALL_SECTIONS = new int[][]
        {
            new int[] {0, 50, 2, 4},
            new int[] {400, 650, 4, 2},
            new int[] {1600, 650, 3, 2},
            new int[] {2200, 450, 2, 3},
            new int[] {2600, 250, 9, 2}
        };

        public const int NUMBER_OF_SECTIONS = 5;


        public const int HERO_SPEED = 30;

        public const int PADDLE_WIDTH = 96;
        public const int PADDLE_HEIGHT = 24;

        public const int HERO_WIDTH = 50;
        public const int HERO_HEIGHT = 125;

        public const int LIFE_WIDTH = 50;
        public const int LIFE_HEIGHT = LIFE_WIDTH;

        public const int LIFE_X = 100;
        public const int LIFE_Y = 125;
    }

}