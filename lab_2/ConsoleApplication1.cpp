#include <iostream>
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

int main()
{
    Point first(20, 25);
    first.printPoint();

    Point* second = new Point(first);
    second->printPoint();
    delete second;
}
