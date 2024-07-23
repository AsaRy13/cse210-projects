using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

public partial class ChartCreatorForm : Form {
    private Graphics g = null;
    private bool pie = false;
    private int total;
    private List<int> amounts;
    private List<string> categories;
    private List<string> distinctCategories = new List<string>();
    private List<int> categoryTotals = new List<int>();
    private List<Label> labels = new List<Label>();
    private List<Color> colors = new List<Color>();

    public ChartCreatorForm(List<int> amounts, bool pie, List<string> categories) {
        this.amounts = amounts;
        this.pie = pie;
        this.categories = categories;
        this.Text = "Chart";
        this.Width = 1000;
        this.Height = 500;
        this.BackColor = Color.FromArgb(255, 128, 128, 128);
        g = Graphics.FromHwnd(Handle);
        colors.Add(Color.Purple);
        colors.Add(Color.Red);
        colors.Add(Color.Orange);
        colors.Add(Color.Yellow);
        colors.Add(Color.Lime);
        colors.Add(Color.Blue);
        this.SetDistinctCategories();
        this.SetCategoryTotals();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if(!pie){
            Brush b = new SolidBrush(Color.Black);
            Pen pen = new Pen(b, 100);
            Brush b2 = new SolidBrush(Color.Red);
            Pen pen2 = new Pen(b2, 100);

            for(int i = 0; i < amounts.Count(); i++){
                if(amounts[i] >= 0){
                    g.DrawLine(pen, new Point((55 * i * 2) + 55, this.Height - amounts[i] - 40), new Point((55 * i * 2) + 55, this.Height - 40));
                }
                else if(amounts[i] < 0){
                    g.DrawLine(pen2, new Point((55 * i * 2) + 55, this.Height + amounts[i] - 40), new Point((55 * i * 2) + 55, this.Height - 40));
                }
            }
            labels.Clear();
            for(int i = 0; i < amounts.Count(); i++){
            labels.Add(new Label());
            labels[i].Text = $"~${amounts[i]}";
            labels[i].Size = new Size(60, 20);
            labels[i].Font = new Font("Arial", 12);
            labels[i].BackColor = Color.Empty;
            if(amounts[i] >= 0){
                labels[i].Location = new Point((55 * i * 2) + 55, this.Height - amounts[i] - 60);
                labels[i].ForeColor = Color.Black;
            }
            else if(amounts[i] < 0){
                labels[i].Location = new Point((55 * i * 2) + 55, this.Height + amounts[i] - 60);
                labels[i].ForeColor = Color.Red;
            }
            this.Controls.Add(labels[i]);
            }
        }
        else{
            int colorIndex = 0;
            Rectangle rect = new Rectangle(this.Width/2 - 200, this.Height/2 - 200, 400, 400);
            float startLine = 0;
            float endLine = 0;
            Brush black = new SolidBrush(Color.Black);
            g.FillEllipse(black, rect);

            for(int i = 0; i < distinctCategories.Count(); i++){
                if(i == 0 && categoryTotals[i] >= 0){
                    Brush b = new SolidBrush(colors[colorIndex]);
                    endLine = (float)categoryTotals[i]/total * 360;
                    g.FillPie(b, rect, 0F, endLine);
                    colorIndex++;
                }
                else if(categoryTotals[i] >= 0 && categoryTotals[i - 1] >= 0){
                    Brush b = new SolidBrush(colors[colorIndex]);
                    startLine += (float)categoryTotals[i - 1]/total * 360;
                    endLine = (float)categoryTotals[i]/total * 360;
                    g.FillPie(b, rect, startLine, endLine);
                    if(colorIndex == 5){
                        colorIndex = 0;
                    }
                    else{
                        colorIndex++;
                    }
                }
                /*else if(i == 0 && categoryTotals[i] < 0){
                    Brush b = new SolidBrush(colors[colorIndex]);
                    endLine = (float)-categoryTotals[i]/total * 360;
                    g.FillPie(b, rect, 0F, endLine);
                    colorIndex++;
                }
                else if(categoryTotals[i] < 0 && categoryTotals[i - 1] >= 0){
                    Brush b = new SolidBrush(colors[colorIndex]);
                    startLine = (float)categoryTotals[i - 1]/total * 360;
                    endLine = (float)-categoryTotals[i]/total * 360;
                    g.FillPie(b, rect, startLine, endLine);
                    if(colorIndex == 5){
                        colorIndex = 0;
                    }
                    else{
                        colorIndex++;
                    }
                }
                else if(categoryTotals[i] >= 0 && categoryTotals[i - 1] < 0){
                    Brush b = new SolidBrush(colors[colorIndex]);
                    startLine = (float)-categoryTotals[i - 1]/total * 360;
                    endLine = (float)categoryTotals[i]/total * 360;
                    g.FillPie(b, rect, startLine, endLine);
                    if(colorIndex == 5){
                        colorIndex = 0;
                    }
                    else{
                        colorIndex++;
                    }
                }
                else if(categoryTotals[i] < 0 && categoryTotals[i - 1] < 0){
                    Brush b = new SolidBrush(colors[colorIndex]);
                    startLine = (float)-categoryTotals[i - 1]/total * 360;
                    endLine = (float)-categoryTotals[i]/total * 360;
                    g.FillPie(b, rect, startLine, endLine);
                    if(colorIndex == 5){
                        colorIndex = 0;
                    }
                    else{
                        colorIndex++;
                    }
                }*/
            }
        }
    }
    public void SetDistinctCategories(){
        int colorIndex = 1;
        for(int i = 0; i < categories.Count(); i++){
            bool inList = false;
            if(distinctCategories.Count() == 0){
                distinctCategories.Add("Legend:");
                categoryTotals.Add(0);
                labels.Add(new Label());
                labels[i].Text = "Legend:";
                labels[i].Location = new Point(this.Width - 300, 0);
                labels[i].Size = new Size(150, 20);
                labels[i].Font = new Font("Arial", 12);
                labels[i].ForeColor = Color.Black;
                this.Controls.Add(labels[i]);
            }
            for(int j = 0; j < distinctCategories.Count(); j++){
                if(categories[i] == distinctCategories[j]){
                    inList = true;
                }else if(inList == false){
                    if(j == distinctCategories.Count() - 1){
                        distinctCategories.Add(categories[i]);
                        categoryTotals.Add(1);
                        labels.Add(new Label());
                        labels[j + 1].Location = new Point(this.Width - 300, (j + 1) * 20);
                        labels[j + 1].Size = new Size(300, 20);
                        labels[j + 1].Font = new Font("Arial", 12);
                        labels[j + 1].ForeColor = this.colors[colorIndex];
                        if(colorIndex == 5){
                            colorIndex = 0;
                        }else{
                            colorIndex++;
                        }
                    }
                }
            }
        }
    }
    public void SetCategoryTotals(){
        for(int i = 0; i < amounts.Count(); i++){
            for(int j = 0; j < distinctCategories.Count(); j++){
                if(categories[i] == distinctCategories[j]){
                    if(amounts[i] >= 0){
                        categoryTotals[j] += amounts[i];
                    }
                    else{
                        categoryTotals[j] -= amounts[i];
                    }
                }
            }
        }
        for(int i = 0; i < categoryTotals.Count(); i++){
            if(categoryTotals[i] >= 0){
                this.total += categoryTotals[i];
            }
            else{
                this.total -= categoryTotals[i];
            }
        }
        for(int i = 0; i < categoryTotals.Count(); i++){
            if(i > 0){
                labels[i].Text = distinctCategories[i] + $" - %{(float)categoryTotals[i]/total * 100}";
                this.Controls.Add(labels[i]);
            }
        }
    }
}