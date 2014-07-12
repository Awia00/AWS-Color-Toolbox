/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package aws.color.toolbox;
import VisualTesting.ColorTesting;
import java.awt.Color;

/**
 *
 * @author Anders
 */
public class AWSColorToolbox{

	/**
	 * 
	 */
	private AWSColorToolbox()
	{
	}
	
	/**
	 * Darken the given color, by the amtOfDarken.
	 * Will return a 0 RGB value if the Darkening goes below that.
	 * 
	 * @param color
	 * @param amtOfDarken 
	 * @return a darkened version of the color.
	 */
	public static Color darkenByAmt(Color color, int amtOfDarken)
	{
		int red = Math.max(color.getRed()-amtOfDarken,0);
		int green = Math.max(color.getGreen()-amtOfDarken,0);
		int blue = Math.max(color.getBlue()-amtOfDarken,0);
		int alpha = color.getAlpha();
		
		return new Color(red,green,blue,alpha);
	}
	
	/**
	 * Darken the given color, by the amtOfDarken.
	 * Will darken as much but still keep the color ratio intact.
	 * if amtOfDarken = 255, it will return the most dark version of the color.
	 * 
	 * @param color
	 * @param amtOfDarken 
	 * @return a darkened version of the color.
	 */
	public static Color darkenByAmtSafe(Color color, int amtOfDarken)
	{
		
		amtOfDarken = Math.min(amtOfDarken, Math.min(color.getRed(),Math.min(color.getBlue(),color.getGreen())));
		int red = Math.max(color.getRed()-amtOfDarken,0);
		int green = Math.max(color.getGreen()-amtOfDarken,0);
		int blue = Math.max(color.getBlue()-amtOfDarken,0);
		int alpha = color.getAlpha();
		
		return new Color(red,green,blue,alpha);
	}
	
	/**
	 * Lightens the given color, by the amtOfLighten.
	 * Will return a 255 RGB value if the lightening exceeds that.
	 * 
	 * @param color
	 * @param amtOfLighten 
	 * @return a lightened version of the color.
	 */
	public static Color lightenByAmt(Color color, int amtOfLighten)
	{
		int red = Math.max(color.getRed()+amtOfLighten,255);
		int green = Math.max(color.getGreen()+amtOfLighten,255);
		int blue = Math.max(color.getBlue()+amtOfLighten,255);
		int alpha = color.getAlpha();
		
		return new Color(red,green,blue,alpha);
	}
	
	/**
	 * Lightens the given color, by the amtOfLighten.
	 * Will lighten as much but still keep the color ratio intact.
	 * if amtOfLighten = 255, it will return the most bright version of the color.
	 * 
	 * @param color
	 * @param amtOfLighten 
	 * @return a lightened version of the color.
	 */
	public static Color lightenByAmtSafe(Color color, int amtOfLighten)
	{
		amtOfLighten = Math.min(amtOfLighten, Math.min(color.getRed(),Math.min(color.getBlue(),color.getGreen())));
		int red = Math.max(color.getRed()+amtOfLighten,255);
		int green = Math.max(color.getGreen()+amtOfLighten,255);
		int blue = Math.max(color.getBlue()+amtOfLighten,255);
		int alpha = color.getAlpha();
		
		return new Color(red,green,blue,alpha);  // removed alpha
	}
	
	
	/**
	 * Blends the two colors equally by the formula (color1+color2)/2
	 * @param color1
	 * @param color2
	 * @return 
	 */
	public static Color blendSimpleEqually(Color color1, Color color2)
	{
		int red = (color1.getRed()+color2.getRed())/2;
		int green = (color1.getGreen() + color2.getGreen())/2;
		int blue = (color1.getBlue() + color2.getBlue())/2;
		int alpha = (color1.getAlpha() + color2.getAlpha())/2;
		
		return new Color(red,green,blue);  // removed alpha
	}
	
	/**
	 * Blends the two colors where color 1 gets pctBlend of the final
	 * @param color1
	 * @param color2
	 * @param pctBlend
	 * @return 
	 */
	public static Color blendSimpleByAmt(Color color1, Color color2, double pctBlend)
	{
		int red = (int) (color1.getRed()*pctBlend+color2.getRed()*(1-pctBlend));
		int green = (int) (color1.getGreen()*pctBlend+color2.getGreen()*(1-pctBlend));
		int blue = (int) (color1.getBlue()*pctBlend+color2.getBlue()*(1-pctBlend));
		int alpha = (color1.getAlpha() + color2.getAlpha());
		
		return new Color(red,green,blue);  // removed alpha
	}
	
	
	/**
	 * Blends the two colors equally by the addition (color1+color2)
	 * returns white if the RGB values exceed 255.
	 * @param color1
	 * @param color2
	 * @return 
	 */
	public static Color blendAddition(Color color1, Color color2)
	{
		int red = Math.min(color1.getRed() + color2.getRed(),255);
		int green = Math.min(color1.getGreen() + color2.getGreen(),255);
		int blue = Math.min(color1.getBlue() + color2.getBlue(),255);
		int alpha = Math.min(color1.getAlpha() + color2.getAlpha(),255);
		
		return new Color(red,green,blue);  // removed alpha
	}
	
	
	/**
	 * Blends the two colors equally by the subtraction (color1-color2)
	 * returns black if the RGB values goes below 0.
	 * @param color1
	 * @param color2
	 * @return 
	 */
	public static Color blendSubtraction(Color color1, Color color2)
	{
		int red = Math.max(color1.getRed() - color2.getRed(),0);
		int green = Math.max(color1.getGreen() - color2.getGreen(),0);
		int blue = Math.max(color1.getBlue() - color2.getBlue(),0);
		int alpha = Math.max(color1.getAlpha() - color2.getAlpha(),0);
		
		return new Color(red,green,blue);  // removed alpha
	}
	
	
	/**
	 * 
	 * @param color1
	 * @param color2
	 * @return 
	 */
	public static Color blendDifference(Color color1, Color color2)
	{
		
		int red = Math.max(color1.getRed() - color2.getRed(),0);
		int green = Math.max(color1.getGreen() - color2.getGreen(),0);
		int blue = Math.max(color1.getBlue() - color2.getBlue(),0);
		int alpha = Math.max(color1.getAlpha() - color2.getAlpha(),0);
		
		return new Color(red,green,blue); // removed alpha
	}
	
	/**
	 * Picks the lightest RGB values from both colors.
	 * @param color1
	 * @param color2
	 * @return 
	 */
	public static Color lightenOnly(Color color1, Color color2)
	{
		
		int red = Math.max(color1.getRed() , color2.getRed());
		int green = Math.max(color1.getGreen() , color2.getGreen());
		int blue = Math.max(color1.getBlue() , color2.getBlue());
		int alpha = Math.max(color1.getAlpha() , color2.getAlpha());
		
		return new Color(red,green,blue);  // removed alpha
	}
	
	/**
	 * Picks the darkest RGB colors from the two colors.
	 * @param color1
	 * @param color2
	 * @return 
	 */
	public static Color darkenOnly(Color color1, Color color2)
	{
		int red = Math.min(color1.getRed() , color2.getRed());
		int green = Math.min(color1.getGreen() , color2.getGreen());
		int blue = Math.min(color1.getBlue() , color2.getBlue());
		int alpha = Math.min(color1.getAlpha() , color2.getAlpha());
		
		return new Color(red,green,blue);  // removed alpha
	}
	
	/**
	 * Returns the a color with the same RGB values but with a new alpha value.
	 * @param color
	 * @param newAlphaValue
	 * @return 
	 */
	public static Color changeAlpha(Color color, int newAlphaValue)
	{
		int red = color.getRed();
		int green = color.getGreen();
		int blue = color.getBlue();
		int alpha = newAlphaValue;
		
		return new Color(red,green,blue,alpha);
	}
	
	/**
	 * @param args the command line arguments
	 */
	public static void main(String[] args)
	{
		new ColorTesting();
	}
	
}
