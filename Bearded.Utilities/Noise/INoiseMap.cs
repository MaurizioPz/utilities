namespace Bearded.Utilities.Noise
{
    public interface INoiseMap
    {
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// Returns the value of the noise map at the given coordinates in the noise map.
        /// This method only works for values within the [0, Width) x [0, Height) range only. That is, the upper bound
        /// of x and y respectively are Width and Height exclusive.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double ValueAt(double x, double y);

        /// <summary>
        /// Transforms the noise map to a 2D array by dividing the entire noise map in a grid of width by height tiles.
        /// We then sample the center of each of the grid tiles to get the discrete value.
        /// </summary>
        /// <param name="sizeX">The width of the resulting array. That is, its size in the first dimension.</param>
        /// <param name="sizeY">The height of the resulting array. That is, its size in the second dimension.</param>
        /// <returns>A 2D array with the given width and height with evaluated values based on the noise map.</returns>
        public double[,] ToArray(int sizeX, int sizeY)
        {
            var tileWidth = (double) Width / sizeX;
            var tileHeight = (double) Height / sizeY;
            var halfTileWidth = 0.5 * tileWidth;
            var halfTileHeight = 0.5 * tileHeight;

            var result = new double[sizeX, sizeY];

            for (var y = 0; y < sizeY; y++)
            {
                for (var x = 0; x < sizeX; x++)
                {
                    result[x, y] = ValueAt(x * tileWidth + halfTileWidth, y * tileHeight + halfTileHeight);
                }
            }

            return result;
        }
    }
}