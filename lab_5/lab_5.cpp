#include <iostream>
using namespace std;

class Car {
public:
    string classname = "Car";


    void redefinedMethod() {
        cout << "Method of Car class\n";
    }

    virtual void overridenMethod() {
        cout << "Method of Car class\n";
    }

    Car() { cout << "Car()\n"; }
    virtual ~Car() { cout << "~Car()\n"; }
};

class passengerCar : public Car {
public:
    string classname = "passengerCar";

    void redefinedMethod() {
        cout << "Method of passengerCar class\n";
    }

    void overridenMethod() override {
        cout << "Method of passengerCar class\n";
    }

    passengerCar() { cout << "passengerCar()\n"; }
    ~passengerCar() override { cout << "~passengerCar()\n"; }
};

class Niva4x4 : public passengerCar{
public:
    string classname = "Niva4x4";
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
    Car* test = new passengerCar();
    test->overridenMethod();
    delete test;
    //----------------------
}
