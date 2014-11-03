

using System;
using System.Drawing;

namespace Color_Toolbox
{
    public class ColorToolbox
    {
        // DARKEN
        /**
         * Darken the given color, by the amtOfDarken. Will return a 0 RGB value if
         * the Darkening goes below that.
         *
         * @param color
         * @param amtOfDarken
         * @return a darkened version of the color.
         */
        public static Color DarkenByAmt(Color color, int amtOfDarken)
        {
            int red = Math.Max(color.R - amtOfDarken, 0);
            int green = Math.Max(color.G - amtOfDarken, 0);
            int blue = Math.Max(color.B - amtOfDarken, 0);
            int alpha = color.A;

            return Color.FromArgb(alpha, red, green, blue);
        }

        /// <summary>
        /// Intensifies the color
        /// </summary>
        /// <param name="color1"></param>
        /// <param name="intensity"></param>
        /// <returns></returns>
        public static Color ColorIntensify(Color color1, double intensity)
        {
            int red = (int)Math.Min(255, color1.R * (intensity));
            int green = (int)Math.Min(255, color1.G * (intensity));
            int blue = (int)Math.Min(255, color1.B * (intensity));
            return Color.FromArgb(red, green, blue);
        }

        /**
         * Darken the given color, by the amtOfDarken. Will darken as much but still
         * keep the color ratio intact. if amtOfDarken = 255, it will return the
         * most dark version of the color.
         *
         * @param color
         * @param amtOfDarken
         * @return a darkened version of the color.
         */
        public static Color DarkenByAmtSafe(Color color, int amtOfDarken)
        {

            amtOfDarken = Math.Min(amtOfDarken, Math.Min(color.R, Math.Min(color.B, color.G)));
            int red = Math.Max(color.R - amtOfDarken, 0);
            int green = Math.Max(color.G - amtOfDarken, 0);
            int blue = Math.Max(color.B - amtOfDarken, 0);
            int alpha = color.A;

            return Color.FromArgb(alpha, red, green, blue);
        }

        // LIGHTEN
        /**
         * Lightens the given color, by the amtOfLighten. Will return a 255 RGB
         * value if the lightening exceeds that.
         *
         * @param color
         * @param amtOfLighten
         * @return a lightened version of the color.
         */
        public static Color LightenByAmt(Color color, int amtOfLighten)
        {
            int red = Math.Max(color.R + amtOfLighten, 255);
            int green = Math.Max(color.G + amtOfLighten, 255);
            int blue = Math.Max(color.B + amtOfLighten, 255);
            int alpha = color.A;

            return Color.FromArgb(alpha, red, green, blue);
        }

        /**
         * Lightens the given color, by the amtOfLighten. Will lighten as much but
         * still keep the color ratio intact. if amtOfLighten = 255, it will return
         * the most bright version of the color.
         *
         * @param color
         * @param amtOfLighten
         * @return a lightened version of the color.
         */
        public static Color LightenByAmtSafe(Color color, int amtOfLighten)
        {
            amtOfLighten = Math.Min(amtOfLighten, Math.Min(color.R, Math.Min(color.B, color.G)));
            int red = Math.Max(color.R + amtOfLighten, 255);
            int green = Math.Max(color.G + amtOfLighten, 255);
            int blue = Math.Max(color.B + amtOfLighten, 255);
            int alpha = color.A;

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        // BLENDS
        /**
         * multiplies the two colors and divides them by 255
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendMultiply(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }

            int red = color1.R * color2.R / 255;
            int green = color1.G * color2.G / 255;
            int blue = color1.B * color2.B / 255;
            int alpha = color1.A * color2.A / 255;

            return Color.FromArgb(alpha, red, green, blue); // removed alpha
        }

        /**
         * DOES NOT WORK YET
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendDivide(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red;
            int green;
            int blue;
            int alpha;
            if (color2.R != 0) red = Math.Min(color1.R / Math.Max((int) color2.R, 1) * 255, 255);
            else red = 0;
            if (color2.G != 0) green = Math.Min(color1.G / Math.Max((int) color2.G, 1) * 255, 255);
            else green = 0;
            if (color2.B != 0) blue = Math.Min(color1.B / Math.Max((int) color2.B, 1) * 255, 255);
            else blue = 0;
            if (color2.A != 0) alpha = Math.Min(color1.A / Math.Max((int) color2.A, 1) * 255, 255);
            else alpha = 0;

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        /**
         * Blends the two colors equally by the formula (color1+color2)/2
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendSimpleEqually(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = (color1.R + color2.R) / 2;
            int green = (color1.G + color2.G) / 2;
            int blue = (color1.B + color2.B) / 2;
            int alpha = (color1.A + color2.A) / 2;

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        /**
         * Blends the two colors where color 1 gets pctBlend of the final
         *
         * @param color1
         * @param color2
         * @param pctBlend
         * @return
         */
        public static Color BlendSimpleByAmt(Color color1, Color color2, double pctBlend)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = (int)(color1.R * pctBlend + color2.R * (1.0 - pctBlend));
            int green = (int)(color1.G * pctBlend + color2.G * (1.0 - pctBlend));
            int blue = (int)(color1.B * pctBlend + color2.B * (1.0 - pctBlend));
            int alpha = (int)(color1.A * pctBlend + color2.A * (1.0 - pctBlend));

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        /**
         * Blends the two colors equally by the addition (color1+color2) returns
         * white if the RGB values exceed 255.
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendAddition(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = Math.Min(color1.R + color2.R, 255);
            int green = Math.Min(color1.G + color2.G, 255);
            int blue = Math.Min(color1.B + color2.B, 255);
            int alpha = Math.Min(color1.A + color2.A, 255);

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        /**
         * Blends the two colors equally by the subtraction (color1-color2) returns
         * black if the RGB values goes below 0.
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendSubtraction(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = Math.Max(color1.R - color2.R, 0);
            int green = Math.Max(color1.G - color2.G, 0);
            int blue = Math.Max(color1.B - color2.B, 0);
            int alpha = Math.Max(color1.A - color2.A, 0);

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        /**
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendDifference(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = Math.Abs(color1.R - color2.R);
            int green = Math.Abs(color1.G - color2.G);
            int blue = Math.Abs(color1.B - color2.B);
            int alpha = Math.Abs(color1.A - color2.A);

            return Color.FromArgb(alpha, red, green, blue); // removed alpha
        }

        /**
         * blends with low contrast. For values close to white, the blend is
         * inverted, for values near black nothing changes.
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendExclusion(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = (int)Math.Round((double) (color1.R + color2.R - 2 * color1.R * color2.R / 255));
            int green = (int)Math.Round((double) (color1.G + color2.G - 2 * color1.G * color2.G / 255));
            int blue = (int)Math.Round((double) (color1.B + color2.B - 2 * color1.B * color2.B / 255));
            int alpha = (int)Math.Round((double) (color1.A + color2.A - 2 * color1.A * color2.A / 255));

            return Color.FromArgb(alpha, red, green, blue); // removed alpha
        }


        /**
         * DOES NOT WORK YET
         * @param color1
         * @param color2
         * @return 
         */
        public static Color BlendBurn(Color color1, Color color2)
        {
            if (color1 == null || color2 == null) throw new Exception();

            int red;
            int green;
            int blue;
            int alpha;
            if (color1.R != 0) red = (int)(255 * (1 - (1 - Normalize(color2.R) / Normalize(color1.R))));
            else red = 0;
            if (color1.G != 0) green = (int)(255 * (1 - (1 - Normalize(color2.G) / Normalize(color1.G))));
            else green = 0;
            if (color1.B != 0) blue = (int)(255 * (1 - (1 - Normalize(color2.B) / Normalize(color1.B))));
            else blue = 0;
            if (color1.A != 0) alpha = (int)(255 * (1 - (1 - Normalize(color2.A) / Normalize(color1.A))));
            else alpha = 0;

            return Color.FromArgb((red <= 0) ? 0 : red, (green <= 0) ? 0 : green, (blue <= 0) ? 0 : blue);
        }

        /**
         * Picks the lightest RGB values from both colors.
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendLightenOnly(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = Math.Max(color1.R, color2.R);
            int green = Math.Max(color1.G, color2.G);
            int blue = Math.Max(color1.B, color2.B);
            int alpha = Math.Max(color1.A, color2.A);

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        /**
         * Picks the darkest RGB colors from the two colors.
         *
         * @param color1
         * @param color2
         * @return
         */
        public static Color BlendDarkenOnly(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
            {
                throw new Exception();
            }
            int red = Math.Min(color1.R, color2.R);
            int green = Math.Min(color1.G, color2.G);
            int blue = Math.Min(color1.B, color2.B);
            int alpha = Math.Min(color1.A, color2.A);

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        // MISC
        /**
         * Inverts the color
         *
         * @param color
         * @return
         */
        public static Color Invert(Color color)
        {
            int red = 255 - color.R;
            int green = 255 - color.G;
            int blue = 255 - color.B;
            int alpha = 255 - color.A;

            return Color.FromArgb(alpha, red, green, blue);  // removed alpha
        }

        /**
         * Returns the a color with the same RGB values but with a new alpha value.
         *
         * @param color
         * @param newAlphaValue
         * @return
         */
        public static Color ChangeAlpha(Color color, int newAlphaValue)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            int alpha = newAlphaValue;

            return Color.FromArgb(alpha, red, green, blue);
        }

        /**
         * takes a RGB value (has to be between 0 and 255) and divides it by 255.
         * @param RGBValue
         * @return 
         */
        private static double Normalize(int RGBValue)
        {
            return RGBValue / 255;
        }
    }
}
