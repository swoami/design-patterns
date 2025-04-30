using ProxyPattern.Protection;

var car = new CarProxy(new Driver(12));
car.Drive();
