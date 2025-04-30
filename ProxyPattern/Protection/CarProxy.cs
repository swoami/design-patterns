namespace ProxyPattern.Protection;

public class CarProxy : ICar
{
    private readonly Driver _driver;
    private readonly Car _car;
    public CarProxy(Driver driver)
    {
        _driver = driver;
        _car = new Car();
    }
    public void Drive()
    {
        if (_driver.Age < 18)
        {
            Console.WriteLine("Driver is too young to drive!");
            return;
        }
        _car.Drive();
    }
}
