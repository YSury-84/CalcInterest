namespace CalcInterest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account[] account_old = new Account[5];
            account_old[0] = new Account(); account_old[0].Type = "Обычный"; account_old[0].Balance = 500;
            account_old[1] = new Account(); account_old[1].Type = "Зарплатный"; account_old[1].Balance = 1500;
            account_old[2] = new Account(); account_old[2].Type = "Обычный"; account_old[2].Balance = 1300;
            account_old[3] = new Account(); account_old[3].Type = "Зарплатный"; account_old[3].Balance = 900;
            account_old[4] = new Account(); account_old[4].Type = "Обычный"; account_old[4].Balance = 2500;
            foreach (var item in account_old) { Calculator.CalculateInterest(item); }
            Console.WriteLine("Расчет по старому алгоритму:");
            foreach (var item in account_old) { Console.WriteLine(item.Type + " ("+item.Balance+" rub.)" + " procent="+item.Interest); }

            Account[] account = new Account[5];
            account[0] = new Account(); account[0].Type = "Обычный"; account[0].Balance = 500;
            account[1] = new Account(); account[1].Type = "Зарплатный"; account[1].Balance = 1500;
            account[2] = new Account(); account[2].Type = "Обычный"; account[2].Balance = 1300;
            account[3] = new Account(); account[3].Type = "Зарплатный"; account[3].Balance = 900;
            account[4] = new Account(); account[4].Type = "Обычный"; account[4].Balance = 2500;
            CalcObichnyj co = new CalcObichnyj();
            CalcZarplata za = new CalcZarplata();
            foreach (var item in account) 
            {
                if (item.Type == "Обычный") co.CalculateInterest(item);
                if (item.Type == "Зарплатный") za.CalculateInterest(item);
            }
            Console.WriteLine("\nРасчет по новому алгоритму:");
            foreach (var item in account) { Console.WriteLine(item.Type + " (" + item.Balance + " rub.)" + " procent=" + item.Interest); }
        }

        //Задание 4 без изменения (для сравнения результата)

        public class Account
        {
            // тип учетной записи
            public string Type { get; set; }

            // баланс учетной записи
            public double Balance { get; set; }

            // процентная ставка
            public double Interest { get; set; }
        }

        public static class Calculator
        {
            // Метод для расчета процентной ставки
            public static void CalculateInterest(Account account)
            {
                if (account.Type == "Обычный")
                {
                    // расчет процентной ставки обычного аккаунта по правилам банка
                    account.Interest = account.Balance * 0.4;

                    if (account.Balance < 1000)
                        account.Interest -= account.Balance * 0.2;

                    if (account.Balance >= 1000)
                        account.Interest -= account.Balance * 0.4;
                }
                else if (account.Type == "Зарплатный")
                {
                    // расчет процентной ставк зарплатного аккаунта по правилам банка
                    account.Interest = account.Balance * 0.5;
                }
            }
        }

        //Задание 4 с изменениями (с Принципом открытости-закрытости)

        public interface IInterest
        {
            void CalculateInterest(Account account);
        }

        public class CalcObichnyj: IInterest
        {
            // Метод для расчета процентной ставки
            public void CalculateInterest(Account account)
            {
            // расчет процентной ставки обычного аккаунта по правилам банка
            account.Interest = account.Balance * 0.4;

            if (account.Balance < 1000)
                account.Interest -= account.Balance * 0.2;

            if (account.Balance >= 1000)
                account.Interest -= account.Balance * 0.4;
            }
        }

        public class CalcZarplata : IInterest
        {
            // Метод для расчета процентной ставки
            public void CalculateInterest(Account account)
            {
                // расчет процентной ставк зарплатного аккаунта по правилам банка
                account.Interest = account.Balance * 0.5;
            }
        }


    }
}