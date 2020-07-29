using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah
{
    public class Board :Panel

    {

        Spot[][] squares;
     

        public Board():base()
        {
         
           this.Name = "boardPanel";
           this.Location = new Point(180, 25);
           this.Size = new Size(400, 400);
           this.BackColor = Color.LightBlue;


            //this.resetBoard();
        }


       protected override void OnPaint(PaintEventArgs e)
        {
            
            
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                int columns = 0, yCoord = 0;
                while (columns < 8)
                {
                    int xCoord = 0; ;
                    for (int i = 0; i < 8; i++)
                    {

                        Rectangle rect = new Rectangle(xCoord, yCoord, 50, 50);
                        if((i+columns)%2==1)
                        {
                            e.Graphics.FillRectangle(Brushes.SaddleBrown, rect);
                           
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.White, rect);
                        }
                       
                       
                        xCoord = xCoord + 50;

                    }
                    yCoord += 50;
                    columns++;
                }
            }
        }

        public void ResetBoard()
        {

        }


    }
}
