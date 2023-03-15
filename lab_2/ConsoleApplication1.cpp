﻿#include <iostream>
#include <cmath>
using namespace std;



class Point {
protected:
    int _x, _y;
public:
    Point() : _x(0), _y(0) { cout << "Point()\n"; }
    Point(int x, int y): _x(x), _y(y) { cout << "Point(int x, int y)\n"; }
    Point(Point& pnt) : _x(pnt._x), _y(pnt._y) { cout << "Point(Point& pnt)\n"; }
    virtual ~Point() { cout << "~Point()\n"; }

    void printPoint() {
        cout << _x << " " << _y;
    }
};

class Vector {
private:
    Point* _first;
    Point* _second;
public:
    Vector() : _first(new Point), _second(new Point) { cout << "Vector()\n"; }
    Vector(Point& first, Point& second) : _first(new Point(first)), _second(new Point(second)) { cout << "Vector(Point first, Point second)\n"; }
    Vector(Vector& vct) : _first(new Point(*vct._first)), _second(new Point(*vct._second)) { cout << "Vector(Vector& vct)\n"; }

    ~Vector() {
        delete _first;
        delete _second;
        cout << "~Vector()\n";
    }

    void print_vector() {
        _first->printPoint();
        _second->printPoint();
    }
};

int main()
{
    Point first(20, 25);
    first.printPoint();

    Point* second = new Point(first);
    second->printPoint();
    delete second;

    Point third(15, 10);
    Vector vect(first, third);

    vect.print_vector();


}
