class Account {
    private float balance = 12;

    public float Withdraw(){
        Console.Write("How much would you like to withdraw?: ");
        float amount = float.Parse(Console.ReadLine());

        if (amount > this.balance || amount < 0){
            return 0;
        }
        this.balance -= amount;

        return amount;
    }

    public float GetAccountBalance(){
        return this.balance;
    }
}