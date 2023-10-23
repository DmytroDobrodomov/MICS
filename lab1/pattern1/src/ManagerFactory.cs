

namespace Managers{
    /// <summary>
    /// This class is being used to spawn new magagers using functions;
    /// </summary>
    class ManagerFactory{
        Bank bank;
        public ManagerFactory(Bank b){
            bank = b;
        }
        public Manager CreateInfoManager(){
            Manager manager = new(bank);
            manager.role = "info manager";
            manager.desc = "gives you some info\nand also can register you.";
            return manager;
        }
        public Manager CreateRegisterManager(){
            Manager manager = new(bank);
            manager.role = "register manager";
            manager.desc = "he is here to register you\n";
            return manager;
        }
        public CreditManager CreateCreditManager(){
            return new CreditManager(bank);
        }
        public DepositManager CreateDepositManager(){
            return new DepositManager(bank);
        }

        /// <summary>
        /// make new manager from command string
        /// </summary>
        public Manager GetManager(string service){
            if(service[0] == 'r'){
                return CreateRegisterManager();
            }
            else if(service[0] == 'c'){
                return CreateCreditManager();
            }
            else if(service[0] == 'd'){
                return CreateDepositManager();
            }
            return CreateInfoManager();
        }
        

    }
}