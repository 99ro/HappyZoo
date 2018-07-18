using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Zoo
{
    class Map
    {
        private int tileWidth;
        private int tileHeight;
        private int width;
        private int height;

        private Camera2D camera;

        public Camera2D Camera {
            get {
                return camera;
            }
        }

        public Map(GraphicsDevice pDevice, int pTileWidth, int pTileHeight, int pWidth, int pHeight) {
            tileWidth = pTileWidth;
            tileHeight = pTileHeight;
            width = pWidth;
            height = pHeight;

            camera = new Camera2D(pDevice);
        }

        public void draw(SpriteBatch pSpriteBatch) {
            Vector2 tilePosition = Vector2.Zero;

            pSpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pSpriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);
                    pSpriteBatch.FillRectangle(tilePosition + new Vector2(1,1), new Size2(tileWidth - 2, tileHeight - 2), Color.Black);
                    tilePosition.Y += tileHeight;
                }
                tilePosition.Y = 0;
                tilePosition.X += tileWidth;
            }
            pSpriteBatch.End();
        }

        public void readLevelText() {
            string line = string.Empty;
            using (StreamReader sr = new StreamReader("level")) {
                while ((line = sr.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
