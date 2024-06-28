using System;

public class EternalQuestSword {
    private List<object> swordStrings = new List<object>();

    public EternalQuestSword() {
        this.swordStrings.Add($"                                        __");
        this.swordStrings.Add($"      ╔═══════       ═════════         /  \\");
        this.swordStrings.Add($"  ____║_____________║_________║_______|    \\__________");
        this.swordStrings.Add($" /    ║             ║         ║       |               \\");
        this.swordStrings.Add($"<-----╠═══════------║---------║-------|               |");
        this.swordStrings.Add($" \\____║_____________║_________║_______|     __________/");
        this.swordStrings.Add($"      ║             ║         ║       |    /");
        this.swordStrings.Add($"      ╚═══════       ════════\\\\        \\__/");
        this.swordStrings.Add($"            Eternal Quest     \\\\");
    }

    public void PrintSword(){
        Console.Clear();
        for(int i = 0; i < swordStrings.Count(); i++) {
            Console.WriteLine(swordStrings[i]);
        }
    }
}