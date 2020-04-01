using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;

namespace MyPhotos
{
    [ServiceContract]
    public interface IItemsService
    {
        [OperationContract]
        List<MyItems> GetItems();
        [OperationContract]
        Event AddEvents(string NameEvent);
        [OperationContract]
        Place AddLocation(string NameLocation);
        [OperationContract]
        void MarkToDelete(string path);
        [OperationContract]
        Place GetPlaceByName(string NameLocation);
        [OperationContract]
        Event GetEventByName(string NameEvent);
        [OperationContract]
        void AddItems(MyItems item, Event eveniment, Place loc);
        [OperationContract]
        void Move(string path1, string path2);
        [OperationContract]
        void RemoveWithPath(string path);
        [OperationContract]
        void Remove(MyItems item);
        [OperationContract]
        List<MyItems> GetItemsByPlace(Place place);
        [OperationContract]
        List<MyItems> GetItemsByProperty(Dinamic property);
        [OperationContract]
        List<MyItems> SearchByProperty(string flag, string property);

        [OperationContract]
        MyItems FindItem(string path);

    }

    public class ItemsService : IItemsService
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
            Place localizare = new Place();
            localizare.PName = NameLocation;
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

        public void AddItems(MyItems item, Event eveniment, Place loc)
        {
            item.Event = eveniment;
            item.Place = loc;
            eveniment.MyItems.Add(item);
            loc.MyItems.Add(item);
            this.context.MyItems.Add(item);
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

    }
}
