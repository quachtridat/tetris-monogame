using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleTetris.Core.Graphics {
    static class Helpers {
        // https://stackoverflow.com/a/32429364
        public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Func<int, Color> paint) {
            // Initialize a texture
            Texture2D texture = new Texture2D(device, width, height);

            // The array holds the color for each pixel in the texture
            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < data.Count(); ++pixel) {
                // The function applies the color according to the specified pixel
                data[pixel] = paint(pixel);
            }

            // Set the color
            texture.SetData(data);

            return texture;
        }
    }
}
