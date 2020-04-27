using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;

namespace MyPhotos
{

    public class ItemsService 
    {
        private readonly Model1Container context;



        public ItemsService()
        {
            this.context = Model1Container.getContainer();
        }

        public List<MyItems> GetItems()
        {
            return context.MyItems.ToList();
        }

        public Event AddEvents(string NameEvent)
        {
            Event eveniment = new Event();
            eveniment.EName = NameEvent;
            this.context.Events.Add(eveniment);
            this.context.SaveChanges();
            return eveniment;
        }
        public Place AddLocation(string NameLocation)
        {
            Place localizare = new Place() {PName = NameLocation};
            this.context.Places.Add(localizare);
            this.context.SaveChanges();
            return localizare;

        }
        public void MarkToDelete(string path)
        {
            var item = context.MyItems.FirstOrDefault(i => i.IPath == path);
            if (item != null)
            {
                if (item.IMark == "false")
                {
                    item.IMark = "true";
                }
                else
                { item.IMark = "false";
                }
            }
            //Trimiti asa?
            //da
            //Poti face documentatia intre timp si mai vedem
            //e aproape gata
            //Deci trimiti asa?
            //yees
            // imi pregatesti tu folderul care trebuie arhivat ? :D
            // te rooog :D, stiu ca sunt acolo
            //Ii aratam Biancai
            //Oook
            //Te saluta Bianca
            //si eu pe ea :*
            //E ok daca ma duc la o tigara si fac alea dupa?
            //siguuur
            //A zis Bianca sa intri pe skype si iti explica ea cat fumez
            //pai iesi din pc :))
            //Bine....daca ma dai afara...
            //
            //\Paaaaa
            //stam pe skype 
        }
        public Place GetPlaceByName(string NameLocation)
        {
            var item = this.context.Places.FirstOrDefault(i => i.PName == NameLocation);
            return item;
        }

        public Event GetEventByName(string NameEvent)
        {
            var item = this.context.Events.FirstOrDefault(i => i.EName == NameEvent);
            return item;
        }

        public void AddItems(MyItems item, String eveniment, String loc)
        {
            MyItems item1 = new MyItems()
                {IPath = item.IPath, IDelete = item.IDelete, IDate = item.IDate, IDescription = item.IDescription};
            if (eveniment != string.Empty)
            {
                var event1 = AddEvents(eveniment);
                item1.Event = event1;
                event1.MyItems.Add(item1);
            }

            if (loc != string.Empty)
            {
                var place = AddLocation(loc);
                item1.Place = place;
                place.MyItems.Add(item1);

            }

            this.context.MyItems.Add(item1);
            this.context.SaveChanges();
        }

        public void Move(string path1, string path2)
        {
            var item = context.MyItems.FirstOrDefault(i => i.IPath == path1);
            File.Move(path1, path2);
            item.IPath = path2;
            this.context.SaveChanges();
        }
        public void RemoveWithPath(string path)
        {
            var item = context.MyItems.FirstOrDefault(i => i.IPath == path);
            if (item != null)
            {
                this.context.MyItems.Remove(item);
                if(item.Event!=null)
                item.Event.MyItems.Remove(item);
                if(item.Place!=null)
                item.Place.MyItems.Remove(item);
                this.context.SaveChanges();
            }
        }
        public void Remove(MyItems item)
        {
            this.context.MyItems.Remove(item);
            this.context.SaveChanges();
        }

        public List<MyItems> GetItemsByPlace(Place place)
        {
            List<MyItems> items = this.context.MyItems.Where(i => i.Place.PName == place.PName).ToList();
            return items;
        }

        public List<MyItems> GetItemsByProperty(Dinamic property)
        {
            List<MyItems> items = this.context.MyItems.Where(i => i.Dinamics.Any(p => p.DDescription == property.DDescription)).ToList();
            return items;
        }
        public List<MyItems> SearchByProperty(string flag, string property)
        {
            if( flag == "3")
            {
                List<MyItems> items = this.context.MyItems.Where(i => i.IDescription.Contains(property)).ToList();
                return items;
            }
            else
            if
            (flag == "2")
            {
                List<MyItems> items = this.context.MyItems.Where(i => i.Event.EName.Contains(property)).ToList();
                return items;
            }

            else 
            {
                List<MyItems> items = this.context.MyItems.Where(i => i.Place.PName.Contains(property)).ToList();
                return items;
            }
        }

        public MyItems FindItem(string path)
        {
            var item = this.context.MyItems.FirstOrDefault(i => i.IPath == path);
            return item;
        }

        public Place getPlaceByItem(string Path)
        {
            return context.Places.Where(p => p.MyItems.Any(i => i.IPath == Path)).FirstOrDefault();
        }

        public Event getEventByItem(string Path)
        {
            return context.Events.Where(p => p.MyItems.Any(i => i.IPath == Path)).FirstOrDefault();
        }

    }
}
