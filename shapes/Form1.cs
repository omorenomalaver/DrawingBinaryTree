using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            drawTree(6);
        }

        public void drawTree(int levels)
        {
            int panelW = DrawingPanel.Size.Width;
            int panelH = DrawingPanel.Size.Height;

            SolidBrush sb = new SolidBrush(Color.Green);
            Pen myPen = new Pen(Color.Red);
            Graphics g = DrawingPanel.CreateGraphics();

            int xPos = panelW / 2;
            int yPos = 60;
            int width = 20;
            int height = 20;
            int number_nodes = 1;
            int space = xPos;
            int startPosition = xPos;
            

            for (int i = 1; i<= levels; i++)
            {
                number_nodes = number_nodes * 2;
            }
            number_nodes = number_nodes - 1;
            Console.WriteLine("******* number nodes" + number_nodes);
            int counter = 1;
            int number_nodes_by_level = 2;

            
            int[,] values = new int [number_nodes, 2];

            while (number_nodes != 0)
            {
                if (counter > 1)
                {
                    
                    if (number_nodes_by_level == counter)
                    {
                        yPos = yPos + 100;
                        space = panelW / (number_nodes_by_level + 1);
                        xPos = space;
                        number_nodes_by_level = number_nodes_by_level * 2;
                    }
                    else
                    {
                        xPos = xPos + space;
                    }
                }
                Label node = new Label();
                node.Location = new Point(xPos, yPos);
                node.Text = "(x:" + xPos + ") (y:" + yPos+")";

                //DrawingPanel.Controls.Add(node);
                Rectangle rectangle = new Rectangle(xPos, yPos, width, height);
                g.DrawEllipse(myPen, rectangle);
                values[counter - 1, 0] = xPos;
                values[counter - 1, 1] = yPos;

                counter++;
                number_nodes--;
            }
            /*
            int maxLines = (values.Length / 2) -1;
            int yPoxS = 0,xPosS = 0;
            for (int i = 0; i<= maxLines; i++)
            {
                if (yPoxS == 0)
                {
                    xPosS = values[i, 0];
                    yPoxS = values[i, 1];
                }
                else
                {

                    System.Drawing.Graphics graphicsObj;

                    graphicsObj = this.CreateGraphics();

                    g.DrawLine(myPen, xPosS, yPoxS, values[i, 0], values[i, 1]);
                    if (yPoxS != values[i, 1] && i>2)
                    {
                        xPosS = values[i, 0];
                        yPoxS = values[i, 1];
                    }
                    else
                    {
                        xPosS = values[i, 0];
                    }
                }
                Console.WriteLine("x:" + values[i, 0]);
                Console.WriteLine("y:" + values[i, 1]);

                

            }
            */
            /*for (int i = 1; i<=levels; i++)
            {
                int tempNumberNodes = number_nodes;
                
                while (tempNumberNodes != 0)
                {
                    Rectangle rectangle = new Rectangle(xPos, yPos, width, height);
                    g.DrawEllipse(myPen, rectangle);
                    xPos = xPos + (startPosition * number_nodes);
                    tempNumberNodes--;
                }
                yPos = yPos + 100;
                xPos = startPosition / 2;
                startPosition = xPos;
                number_nodes = number_nodes * 2;
                
            }
            */


        }
    }
}
