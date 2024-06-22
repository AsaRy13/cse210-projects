using System;

public class LoadingAnimation {
    private List<string> defaultStrings = new List<string>();
    private List<string> blankSides = new List<string>();
    private List<string> arrowSides = new List<string>();
    private List<string> arrowTop = new List<string>();
    private List<string> arrowBottom = new List<string>();

    public LoadingAnimation() {
        defaultStrings.Add("<^v^v^v^v^v^v^>");
        defaultStrings.Add(" >           < ");
        defaultStrings.Add("<             >");
        defaultStrings.Add(" v^v^v^v^v^v^v ");

        blankSides.Add(" >             ");
        blankSides.Add("<              ");
        blankSides.Add("             < ");
        blankSides.Add("              >");

        arrowSides.Add(" >            ^");
        arrowSides.Add("<             ^");
        arrowSides.Add(" v           < ");
        arrowSides.Add("v             >");

        arrowTop.Add("v^v^v^v^v^v^v^>");
        arrowTop.Add(" <v^v^v^v^v^v^>");
        arrowTop.Add("  <^v^v^v^v^v^>");
        arrowTop.Add("<  <v^v^v^v^v^>");
        arrowTop.Add("<^  <^v^v^v^v^>");
        arrowTop.Add("<^v  <v^v^v^v^>");
        arrowTop.Add("<^v^  <^v^v^v^>");
        arrowTop.Add("<^v^v  <v^v^v^>");
        arrowTop.Add("<^v^v^  <^v^v^>");
        arrowTop.Add("<^v^v^v  <v^v^>");
        arrowTop.Add("<^v^v^v^  <^v^>");
        arrowTop.Add("<^v^v^v^v  <v^>");
        arrowTop.Add("<^v^v^v^v^  <^>");
        arrowTop.Add("<^v^v^v^v^v  <>");
        arrowTop.Add("<^v^v^v^v^v^  ^");
        arrowTop.Add("<^v^v^v^v^v^v  ");
        arrowTop.Add("<^v^v^v^v^v^v^ ");

        arrowBottom.Add("  ^v^v^v^v^v^v ");
        arrowBottom.Add("   v^v^v^v^v^v ");
        arrowBottom.Add(" v  ^v^v^v^v^v ");
        arrowBottom.Add(" v>  v^v^v^v^v ");
        arrowBottom.Add(" v^>  ^v^v^v^v ");
        arrowBottom.Add(" v^v>  v^v^v^v ");
        arrowBottom.Add(" v^v^>  ^v^v^v ");
        arrowBottom.Add(" v^v^v>  v^v^v ");
        arrowBottom.Add(" v^v^v^>  ^v^v ");
        arrowBottom.Add(" v^v^v^v>  v^v ");
        arrowBottom.Add(" v^v^v^v^>  ^v ");
        arrowBottom.Add(" v^v^v^v^v>  v ");
        arrowBottom.Add(" v^v^v^v^v^>   ");
        arrowBottom.Add(" v^v^v^v^v^v>  ");
        arrowBottom.Add(" v^v^v^v^v^v^^ ");
    }

    public void loadAnimation() {
        
    }
}