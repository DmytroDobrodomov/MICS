namespace Services{
    
    enum CreditType{
        fast,
        standard,
        longterm
    }
    enum DepositType{
        lowPrecent,
        standard,
        highPrecent
    }
    //------------------------------------------------------------
    struct Credit{
        public float money;
        public Guid client;
        public CreditType creditType;

        public Credit(float money, CreditType creditType, Clients.Client client){
            this.money = money;
            this.creditType = creditType;
            this.client = client.guid;
        }
    }

    struct Deposit{
        public bool interruptible;
        public float money;
        public Guid client;
        public DepositType depositType;

        public Deposit(float money, DepositType depositType, Clients.Client client, bool interruptible){
            this.money = money;
            this.depositType = depositType;
            this.client = client.guid;
            this.interruptible = interruptible;
        }
    }

}