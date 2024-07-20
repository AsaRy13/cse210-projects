using System;
using System.Drawing;
using System.Windows.Forms;

public partial class TestForm : Form    // inherits from System.Windows.Forms.Form
{
    private Graphics g = null;
    public TestForm(){
        this.Text = "Form Title";           // specify title of the form
        this.Width = 1000;                         // width of the window in pixels
        this.Height = 500;                        // height in pixels
        this.BackColor = Color.Black;
        g = Graphics.FromHwnd(Handle);
        //this.TheLabel();
    }

    public void TestFormLoad(object sender, EventArgs e) {

    }

    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);

        Brush b = new SolidBrush(Color.White);
        Pen pen = new Pen(b, 100);
        Pen pen2 = new Pen(b, 1);
        Rectangle rect = new Rectangle(0, 0, 200, 100);
        float startAngle = 0.0F;
        float endAngle = 45.0F;

        g.FillPie(b, rect, startAngle, endAngle);
    }

    /*public void TheLabel(){
        Label TextLabel = new Label();
        TextLabel.Text = "Bottom Left";
        TextLabel.Location = new Point(0, this.Height - 60);
        TextLabel.Size = new Size(150, 20);
        TextLabel.Font = new Font("Arial", 12);
        TextLabel.ForeColor = Color.White;
        this.Controls.Add(TextLabel);
    }*/
}