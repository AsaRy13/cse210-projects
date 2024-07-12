using System;

public class TOMOLogo {
    private List<string> logoArtList = new List<string>();

    public TOMOLogo() {
        logoArtList.Add("      ________    ");
        logoArtList.Add("     /       /|   ");
        logoArtList.Add("    /_______/ |   ");
        logoArtList.Add("    |___=___|/|   ");
        logoArtList.Add("    |       | /   ");
        logoArtList.Add("    |_______|/    ");
        logoArtList.Add("Treasury of My Own");
    }
    
    public void DisplayArt(){
        Console.Clear();
        foreach(string line in logoArtList){
            Console.WriteLine(line);
        }
        Thread.Sleep(5000);
    }
}