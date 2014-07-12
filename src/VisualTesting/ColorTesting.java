package VisualTesting;


import aws.color.toolbox.AWSColorToolbox;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.HeadlessException;
import javax.swing.JComponent;
import javax.swing.JFrame;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Anders
 */
public class ColorTesting extends JFrame{

	public ColorTesting() throws HeadlessException
	{
		setMinimumSize(new Dimension(400,400));
		createColorComponent();
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		pack();
		repaint();
		setVisible(true);
	}
	
	private void createColorComponent()
	{
		JComponent colorComponent = new JComponent() {
			@Override
			public void paint(Graphics g)
			{
				//g.setColor(Color.green);
				g.setColor(AWSColorToolbox.blendAddition(Color.green, Color.blue));
				g.fillRect(0, 0, 400, 400);
				g.setColor(AWSColorToolbox.blendDifference(Color.green, Color.blue));
				g.fillRect(50, 50, 300, 300);
				g.setColor(AWSColorToolbox.blendSimpleEqually(Color.green, Color.blue));
				g.fillRect(100, 100, 200, 200);
				g.setColor(AWSColorToolbox.blendSubtraction(Color.green, Color.blue));
				g.fillRect(150, 150, 100, 100);
				g.setColor(AWSColorToolbox.blendAddition(Color.green, Color.blue));
				
				
				g.setColor(AWSColorToolbox.blendAddition(Color.blue, Color.green));
				g.fillRect(0+400, 0, 400, 400);
				g.setColor(AWSColorToolbox.blendDifference(Color.blue, Color.green));
				g.fillRect(50+400, 50, 300, 300);
				g.setColor(AWSColorToolbox.blendSimpleEqually(Color.blue, Color.green));
				g.fillRect(100+400, 100, 200, 200);
				g.setColor(AWSColorToolbox.blendSubtraction(Color.blue, Color.green));
				g.fillRect(150+400, 150, 100, 100);
				g.setColor(AWSColorToolbox.blendAddition(Color.blue, Color.green));
				
				
				
				for(int i = 0 ; i <=1000 ; i++)
				{
					g.setColor(AWSColorToolbox.blendSimpleByAmt(Color.red, Color.blue, (double)i/(double)1000));
					g.fillRect(0+i, 400+i, 1000*2-(2*i), 1000*2-(2*i));
				}
			}
		};
		colorComponent.setMinimumSize(new Dimension(400,400));
		colorComponent.repaint();
		add(colorComponent);
	}
	private void visualTest()
	{
		
	}
}
