#include <iostream>
#include <cmath>
using namespace std;



class Point {
protected:
    int _x, _y;
public:
    int get_x() { return _x; }
    int get_y() { return _y; }

    Point() : _x(0), _y(0) { cout << "Point()\n"; }
    Point(int x, int y): _x(x), _y(y) { cout << "Point(int x, int y)\n"; }
    Point(Point& pnt) : _x(pnt._x), _y(pnt._y) { cout << "Point(Point& pnt)\n"; }
    virtual ~Point() { cout << "~Point()\n"; }

    void printPoint() {
        cout << _x << " " << _y <<"\n";
    }
};


class Vector {
private:
    Point* _first;
    Point* _second;
public:
    double length();

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

double Vector::length() {
    return (double)sqrt(pow(double(abs(_second->get_x() - _first->get_x())), double(2)) + pow((double)(abs(_second->get_y() - _first->get_y())), (double)2));
}


class Point3D : public Point {
private:
    int _z;

public:
    void printPoint() {
        Point::printPoint();
        cout << " " << _z;
    }
    Point3D() : Point(), _z(0) { cout << "Point3D()\n"; }
    Point3D(int x, int y, int z) : Point(x, y), _z(z) { cout << "Point3D(int x, int y, int z)\n"; }
    Point3D(Point3D& pnt) : Point(pnt), _z(pnt._z) { cout << "Point3D(Point3D& pnt)\n"; }
    ~Point3D() override { cout << "~Point3D()\n"; }
};


class Vector_v2 {
private:
    Point _first;
    Point _second;
public:
    Vector_v2() { cout << "Vector_v2()\n"; }
    Vector_v2(Point& first, Point& second) : _first(first), _second(second) { cout << "Vector_v2(Point first, Point second)\n"; }
    Vector_v2(Vector_v2& vct) : _first(vct._first), _second(vct._second) { cout << "Vector_v2(Vector_v2& vct)\n"; }
    ~Vector_v2() { cout << "~Vector_v2()\n"; }
};


int main()
{
    Point first(20, 15);
    first.printPoint();

    Point* second = new Point(first);
    second->printPoint();
    delete second;

    Point third(15, 10);
    Vector vect(first, third);

    vect.print_vector();
    cout << vect.length() << "\n";

    Point3D x1(1, 2, 3);
    Point3D x2 = x1;


    Point* x = new Point3D();
    static_cast <Point3D*> (x)->printPoint();
    delete x;

    Point m(1, 1);
    Point n(2, 2);

    Vector_v2 k(m, n);
}
