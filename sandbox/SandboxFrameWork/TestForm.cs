using System;
using System.Drawing;
using System.Windows.Forms;

public partial class TestForm : Form    // inherits from System.Windows.Forms.Form
{
    private Graphics g = null;
    public TestForm(){
        this.Text = "Form Title";           // specify title of the form
        this.Width = 300;                         // width of the window in pixels
        this.Height = 300;                        // height in pixels
        this.BackColor = Color.Black;
        g = Graphics.FromHwnd(Handle);
    }

    public void TestFormLoad(object sender, EventArgs e) {

    }

    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);

        Brush b = new SolidBrush(Color.White);

        Pen pen = new Pen(b, 20.5f);
        Point p1 = new Point(0, 0);
        Point p2 = new Point(this.Width, this.Height);

        g.DrawLine(pen, p1, p2);
    }
}