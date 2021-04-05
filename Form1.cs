using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Confession1
{
    public partial class Form1 : Form
    {
        Boolean EnableClose = false;

        Button newButton;

        public Form1()
        {
            InitializeComponent();

            newButton = new NoFocusCueButton();
            this.Controls.Add(newButton);
            newButton.Name = "buttonX";
            newButton.Text = "不行";
            newButton.BringToFront();
            newButton.Location = new Point(249, 117);
            newButton.Size = new Size(130, 30);
            newButton.BackColor = Color.Transparent;
            newButton.ForeColor = Color.DodgerBlue;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            newButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.MouseEnter += new System.EventHandler(btn_MouseEnter);
                btn.MouseDown += new System.Windows.Forms.MouseEventHandler(btn_MouseDown);
            }


        }

        private void btn_MouseDown(object sender, System.EventArgs e)
        {
            var senderButton = (Button)sender;

            //Console.WriteLine(senderButton);
            if (senderButton.Name == "button1")
            {
                //Do Nothing
                //Console.WriteLine("Button 1 here");
            }
            else
            {
                //Console.WriteLine(newButton.Location);
                Random r = new Random();
                int rxInt = r.Next(0, 400); //for Random X
                int ryInt = r.Next(0, 150); //for Random Y

                newButton.Location = new Point(rxInt, ryInt);
            }
        
        }

        private void btn_MouseEnter(object sender, System.EventArgs e)
        {
            var senderButton = (Button)sender;

            if (senderButton.Name == "button1") {
                //Do Nothing
                //Console.WriteLine("Button 1 here");
            }
            else {
                //Console.WriteLine(newButton.Location);
                Random r = new Random();
                int rxInt = r.Next(0, 400); //for Random X
                int ryInt = r.Next(0, 150); //for Random Y
                
                newButton.Location = new Point(rxInt, ryInt);
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(newButton);
            string message = "同意不就可以啦，么么哒~";
            string title = "亲爱的";
            MessageBox.Show(message, title);
            
            EnableClose = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!EnableClose)
            {
                string message = "不答应我你关不掉的噢~";
                string title = "答应我嘛";
                MessageBox.Show(message, title);
                e.Cancel = true;
            }

        }
    }

    public class NoFocusCueButton : Button
    {
        public NoFocusCueButton() : base()
        {

            this.SetStyle(ControlStyles.Selectable, false);
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}
