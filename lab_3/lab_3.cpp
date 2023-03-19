#include <iostream>
using namespace std;


class Base {
public:
    string message;

    Base() : message("Hello") { cout << "Base()\n"; }
    Base(int size) { cout << "Base(int size)\n"; }
    Base(Base& arr) : message(arr.message) { cout << "Base(Base& arr)\n"; }

    virtual ~Base() {}
};


class Desc1 : public Base {

};




class _Array {
private:
    Base* array;
public:

    int _size;
    _Array() : _size(0)  { 
        array = new Base[0];
        cout << "_Array()\n"; 
    }
    _Array(int size) : _size(size) { 
        array = new Base[_size];
        cout << "_Array(int size)\n"; 
    }
    //_Array(_Array& arr) : ptr(arr.ptr) { cout << "_Array(_Array& arr)\n"; } // должны скопировать всё содержимое arr;

    virtual ~_Array() {
        delete[] array;
        cout << "~_Array()\n";
    }

    void Add(int pozition, Base& base) {
        array[pozition] = base;
        cout << array->message << "\n";
    }
};

int main()
{
    Base test;


    _Array massive(2);

    massive.Add(0, test);
    massive.Add(1, test);

}
