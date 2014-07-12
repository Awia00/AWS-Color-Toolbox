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
		setMinimumSize(new Dimension(1800,1024));
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
				// draw the different blend modes in squares
				//g.setColor(Color.green);
				g.setColor(AWSColorToolbox.blendAddition(Color.green, Color.blue));
				g.fillRect(0, 0, 500, 500);
				g.setColor(AWSColorToolbox.blendDifference(Color.green, Color.blue));
				g.fillRect(50, 50, 400, 400);
				g.setColor(AWSColorToolbox.blendSimpleEqually(Color.green, Color.blue));
				g.fillRect(100, 100, 300, 300);
				g.setColor(AWSColorToolbox.blendSubtraction(Color.green, Color.blue));
				g.fillRect(150, 150, 200, 200);
				g.setColor(AWSColorToolbox.blendDifference(Color.green, Color.blue));
				g.fillRect(200, 200, 100, 100);
				
				g.setColor(AWSColorToolbox.blendAddition(Color.blue, Color.green));
				g.fillRect(0+500, 0, 500, 500);
				g.setColor(AWSColorToolbox.blendDifference(Color.blue, Color.green));
				g.fillRect(50+500, 50, 400, 400);
				g.setColor(AWSColorToolbox.blendSimpleEqually(Color.blue, Color.green));
				g.fillRect(100+500, 100, 300, 300);
				g.setColor(AWSColorToolbox.blendSubtraction(Color.blue, Color.green));
				g.fillRect(150+500, 150, 200, 200);
				g.setColor(AWSColorToolbox.blendDifference(Color.blue, Color.green));
				g.fillRect(200+500, 200, 100, 100);
				
				
				// draw the blending boxes
				for(int i = 0 ; i <=250 ; i++)
				{
					g.setColor(AWSColorToolbox.blendSimpleByAmt(Color.red, Color.blue, (double)i/(double)250));
					g.fillRect(0+i, 500+i, 250*2-(2*i), 250*2-(2*i));
					g.setColor(AWSColorToolbox.invert(g.getColor()));
					g.fillRect(500+i, 500+i, 250*2-(2*i), 250*2-(2*i));
				}
				
				// create the color box
				Color[][] colorPic = new Color[518][518];
				int col = 0;
				for(int i = 0 ; i <=255 ; i+=3)
				{
					for(int k = 0 ; k < 518 ; k++) colorPic[col][k] = new Color(255,0,i);
					col++;
				}
				for(int i = 255 ; i >=0 ; i-=3)
				{
					for(int k = 0 ; k < 518 ; k++) colorPic[col][k] = new Color(i,0,255);
					col++;
				}
				for(int i = 0 ; i <=255 ; i+=3)
				{
					for(int k = 0 ; k < 518 ; k++) colorPic[col][k] = new Color(0,i,255);
					col++;
				}
				for(int i = 255 ; i >=0 ; i-=3)
				{
					for(int k = 0 ; k < 518 ; k++) colorPic[col][k] = new Color(0,255,i);
					col++;
				}
				for(int i = 0 ; i <=255 ; i+=3)
				{
					for(int k = 0 ; k < 518 ; k++) colorPic[col][k] = new Color(i,255,0);
					col++;
				}
				for(int i = 255 ; i >=0 ; i-=3)
				{
					for(int k = 0 ; k < 518 ; k++) colorPic[col][k] = new Color(255,i,0);
					col++;
				}
				
				// draw the color box
				for(int i = 0 ; i <518 ; i++)
				{
					for(int j = 0 ; j <518 ; j++)
					{
						g.setColor(colorPic[i][j]);
						g.fillRect(1000+i, 0+j, 1, 1);
					}
				}
				
				// create the black to white box
				Color[][] blackWhite = new Color[518][518];
				col = 0;
				for(double i = 0 ; i <=255 ; i+= 1/1.99999)
				{
					for(int k = 0 ; k < 518 ; k++) blackWhite[k][col] = new Color((int)i,(int)i,(int)i);
					col++;
				}
				
				// draw the black to white box
				for(int i = 0 ; i <518 ; i++)
				{
					for(int j = 0 ; j <518 ; j++)
					{
						g.setColor(blackWhite[i][j]);
						g.fillRect(1000+i, 518+j, 1, 1);
					}
				}
				
				// draw the blending
				for(int i = 0 ; i <518 ; i++)
				{
					for(int j = 0 ; j <518 ; j++)
					{
						g.setColor(AWSColorToolbox.blendDifference(colorPic[i][j], blackWhite[i][j]));
						g.fillRect(1518+i, 0+j, 1, 1);
						g.setColor(AWSColorToolbox.blendExclusion(colorPic[i][j], blackWhite[i][j]));
						g.fillRect(1518+i, 518+j, 1, 1);
					}
				}
				
			}
		};
		colorComponent.setMinimumSize(new Dimension(1800,400));
		colorComponent.repaint();
		add(colorComponent);
	}
}
