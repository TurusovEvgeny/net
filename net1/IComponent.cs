namespace net1
{
    interface IComponent
    {
        // Текущая сумма на счету
        int CurrentSum { get; }
        // Положить деньги на счет
        void Put(int sum);
        // Взять со счета
        void Withdraw(int sum);
        // Процент начислений
        int Bonus { get; }
        // Отображение информации о счете
        void Display();
    }

    interface IComponentName<out T> : IComponent
    {
        T ReturnName();
    }

    interface IComponentInfo<in T> : IComponent
    {
        void Info(T obj);
    }
}
