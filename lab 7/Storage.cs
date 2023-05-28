using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7
{
    public class _Array
    {
        List<CObserver> observers = new List<CObserver>();

        private AbstractFactory factory = new current_factory();

        private CFigure[] array;
        private int _size;
        private bool abildraw = true;


        public void addObserver(CObserver obs)
        {
            observers.Add(obs);
        }


        public bool ClickOnScreen(int x, int y, bool CtrlPress)
        {
            bool summ = false;
            for (int i = 0; i < _size; i++)
            {
                if ((array[i] != null) && (array[i].CheckInsideOrNot(x, y)))
                {
                    array[i].SetStatusClicking(true);
                    summ = true;
                }
                else if ((array[i] != null) && (!array[i].CheckInsideOrNot(x, y)) && (!CtrlPress))
                {
                    array[i].SetStatusClicking(false);
                }
            }
            return summ;
        }

        public bool drawed()
        {
            return abildraw;
        }

        public void setStatusOfDrawing(bool result)
        {
            abildraw = result;
        }

        private void UnselectPrevious()
        {
            for (int i = 0; i < _size - 1; i++)
            {
                array[i].SetStatusClicking(false);
            }
        }
        public int size()
        {
            return _size;
        }

        public _Array()
        {
            array = new CFigure[0];
            Console.WriteLine("_Array()\n");
        }

        public CFigure getObject(int pozition)
        {
            return array[pozition];
        }

        public void SetObject(int pozition, CFigure crc)
        {
            array[pozition] = crc; //работаем с указателями
        }

        public void RemoveObj(int pozition)
        {
            array[pozition] = null;
        }


        public void AddObject(CFigure crc)
        {
            CObserver obs = new CObserver_curr();

            abildraw = false;
            for (int i = 0; i < _size; i++)
            {
                if (array[i] == null)
                {
                    SetObject(i, crc);

                    array[i].addObserver(obs);
                    

                    return;
                }
            }

            _size += 1;
            CFigure[] arr_copy = new CFigure[_size];
            for (int i = 0; i < _size - 1; i++)
            {
                arr_copy[i] = array[i];
            }
            arr_copy[_size - 1] = crc;

            array = arr_copy;

            array[_size-1].addObserver(obs);
            

            UnselectPrevious();

            notifyTree();
            return;
        }

        public void notifyTree()
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i]!=null)
                {
                    array[i].notify();
                }
            }
        }

        public void loadFigures(string path, _Array array)
        {
            StreamReader fstream = new StreamReader(path);
            string line = fstream.ReadLine();
            int count_load = Convert.ToInt32(line);

            string code;
            CFigure fig;

            for (int i = 0; i < count_load; i++)
            {
                code = fstream.ReadLine();

                fig = factory.createFigure(code);

                if (fig != null)
                {
                    fig.load(fstream, factory);

                    array.AddObject(fig);
                }
            }
        }
    }
}
