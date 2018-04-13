using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollPrj2018
{
    /*--
    Предворительная версия родительского класск
    --*/
    abstract class ParentObject
    {
        protected string name;
        /*bool CursorFromAbove;   //true - курсор над объектом, false - нет.
        bool ObjectSelected;    //true - объект выделен(по нему кликнули), false - объект не выделен. 
        //
        //координаты местоположения объекта на доске
        int X;  
        int Y;
        int ID; //идентификатор объекта. получается при создании нового объекта на доске. Уникален.
        //*/
        public ParentObject(string name)
        {
            this.name = name;
        }
        //
        public virtual void Add(ParentObject _object) { }
        public virtual void Remove(ParentObject _object) { }
        public virtual void Print()
        {

        }
    }
    /*
    Предварительная версия класса агрегатора, 
    хранящего весь пул объектов с доски.
     */
    class BoardPool : ParentObject
    {
        private List<ParentObject> _objects = new List<ParentObject>();
        public BoardPool(string name) : base(name) { }
        public override void Add(ParentObject _object)
        {
            _objects.Add(_object);
        }
        public override void Remove(ParentObject _object)
        {
            _objects.Remove(_object);
        }
        public override void Print()
        {
            base.Print();
        }
        public void SaveToFile(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream writer = new FileStream(filename, FileMode.Create))
            {
                bf.Serialize(writer, _objects);
            }
        }
        public void LoadFromFile(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                _objects = (List<ParentObject>)bf.Deserialize(reader);
            }
        }


    }   
}
