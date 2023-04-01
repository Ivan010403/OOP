#include <iostream>
using namespace std;

class Car {
private:
    string classname = "Car";

public:
    void redefinedMethod() {
        cout << "Method of Car class\n";
    }
};

class passengerCar : public Car {
public:
    void redefinedMethod() {
        cout << "Method of passengerCar class\n";
    }
};

class Niva4x4 : public passengerCar{

};

class Truck : public Car {

};


int main()
{
    
    //-----------------------
    passengerCar obj;
    obj.redefinedMethod();
    obj.Car::redefinedMethod();
    //----------------------
}
