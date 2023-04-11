#include <iostream>
using namespace std;

class Car {
public:
    virtual string classname() {
        return "Car";
    }

    virtual bool isA(const string& who) {
        return who == "Car";
    }



    //-------------------------------------
    void redefinedMethod() {
        cout << "Method of Car class\n";
    }

    virtual void overridenMethod() {
        cout << "Method of Car class\n";
    }
    //-------------------------------------


    Car() { cout << "Car()\n"; }
    virtual ~Car() { cout << "~Car()\n"; }
};

class passengerCar : public Car {
public:
    string classname() override {
        return "passengerCar";
    }

    bool isA(const string& who) override {
        return ((who == "passengerCar") || (Car::isA(who)));
    }


    //------------------------------------
    void redefinedMethod() {
        cout << "Method of passengerCar class\n";
    }

    void overridenMethod() override {
        cout << "Method of passengerCar class\n";
    }
    //-------------------------------------


    passengerCar() { cout << "passengerCar()\n"; }
    ~passengerCar() override { cout << "~passengerCar()\n"; }
};

class Niva4x4 : public passengerCar{
public:
    string classname() override {
        return "Niva4x4";
    }


    bool isA(const string& who) override {
        return ((who == "Niva4x4") || (passengerCar::isA(who)));
    }
};

class Truck : public Car {
public:
    string classname() override {
        return "Truck";
    }

    bool isA(const string& who) override {
        return ((who == "Truck") || (Car::isA(who)));
    }
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

    Car* test1 = new Niva4x4();
    if (test1->classname() == "Niva4x4") { cout << "classname() is working!!!\n"; }

    if (test1->isA("Niva4x4")) { cout << "isA() is working!!!\n"; }
    delete test1;


}
