package aws.color.toolbox;

import java.awt.Color;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Anders
 */
public interface AWSColorToolBox_Interface {
	
	/**
	 * Darkens the given color, by the amtOfDarken.
	 * Will return a 0 RGB value if the Darkening goes below that.
	 * 
	 * @param color
	 * @param amtOfDarken 
	 * @return a darkened version of the color.
	 */
	public Color darkenByAmt(Color color, int amtOfDarken);
}
