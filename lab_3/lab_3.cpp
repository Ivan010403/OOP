#include <iostream>
#include <typeinfo>
using namespace std;


class Base {
public:
    virtual string getInfo() {
        return "Base object\n";
    }

    Base() { cout << "Base()\n"; }

    virtual ~Base() { cout << "~Base()\n"; }
};


class Desc1 : public Base {
public:
    string getInfo() override {
        return "Desc1 object\n";
    }

    Desc1() { cout << "Desc1()\n"; }

    ~Desc1() { cout << "~Desc1()\n"; }
};

class Desc1_1 : public Desc1 {
public:
    string getInfo() override {
        return "Desc1_1 object\n";
    }

    Desc1_1() { cout << "Desc1_1()\n"; }

    ~Desc1_1() { cout << "~Desc1_1()\n"; }
};


class _Array {
private:
    Base** array;
public:

    _Array() { 
        array = new Base*;
        cout << "_Array()\n"; 
    }

    _Array(int size) { 
        array = new Base* [size];
        cout << "_Array(int size)\n"; 
    }

    _Array(_Array& arr){
        array = arr.array;
        cout << "_Array(_Array& arr)\n"; 
    } // должны скопировать всё содержимое arr;

    ~_Array() { cout << "~_Array()\n"; }

    void SetObject(int pozition, Base& base) {
        array[pozition] = &base;
    }

    void ObjectInfo(int pozition) {
        cout << array[pozition]->getInfo();
    }
};

int main()
{
    _Array arr(2);

    Desc1_1 p;

    arr.SetObject(0, p);
    arr.ObjectInfo(0);
}
