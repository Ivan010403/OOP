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

class Desc2 : public Base {
public:
    string getInfo() override {
        return "Desc2 object\n";
    }

    Desc2() { cout << "Desc2()\n"; }

    ~Desc2() { cout << "~Desc2()\n"; }
};


class _Array {
private:
    Base** array;
    int _size;
public:

    _Array() { 
        array = new Base*;
        cout << "_Array()\n"; 
    }

    _Array(int size) : _size(size) {
        array = new Base* [size];
        cout << "_Array(int size)\n"; 
    }

    _Array(_Array& arr){
        array = arr.array; //reference semantics, если вызовется деструктор arr, то array не будет иметь доступ к памяти по этому адресу. Надо сделать глубокое копирование
        cout << "_Array(_Array& arr)\n"; 
    } 

    ~_Array() { 
        for (int i = 0; i < _size; i++)
        {
            if (array[i]) delete[] array[i];
        }
        delete[] array;
        cout << "~_Array()\n"; 
    }

    void SetObject(int pozition, Base* base) {
        array[pozition] = base; //работаем с указателями
    }

    void ObjectInfo(int pozition) {
        cout << array[pozition]->getInfo();
    }

    void RemoveObj(int pozition) {
        delete array[pozition];
        array[pozition] = nullptr;
    }
};

int main()
{
    const int size = 3;
    _Array arr(size);

    int random_number;
    for (int i = 0; i < size; i++)
    {
        random_number = rand() % 3;
        if (random_number == 0) arr.SetObject(i, new Desc1);
        if (random_number == 1) arr.SetObject(i, new Desc1_1);
        if (random_number == 2) arr.SetObject(i, new Desc2);
    }

    for (int i = 0; i < size; i++)
    {
        random_number = rand() % 3;
        if (random_number == 0) arr.ObjectInfo(i);
        if (random_number == 1) arr.RemoveObj(i);
    }
}
