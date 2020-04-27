using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhotos;

namespace ObjectWCF
{
    public class Service : IItemsService

    {
        private ItemsService LocalService;
        public Service()
        {
            LocalService = new ItemsService();
        }

        public Event AddEvents(string NameEvent)
        { 
            return LocalService.AddEvents(NameEvent);
        }

        public void AddItems(MyItems item, String eveniment, String loc)
        {
            LocalService.AddItems(item, eveniment, loc);
        }

        public Place AddLocation(string NameLocation)
        {
            return LocalService.AddLocation(NameLocation);
        }

       

        public MyItems FindItem(string path)
        {
            return LocalService.FindItem(path);
        }

        public Event GetEventByName(string NameEvent)
        {
            return LocalService.GetEventByName(NameEvent);
        }

        public List<MyItems> GetItems()
        {
            return LocalService.GetItems();
        }

        public List<MyItems> GetItemsByPlace(Place place)
        {
            return LocalService.GetItemsByPlace(place);
        }

        public List<MyItems> GetItemsByProperty(Dinamic property)
        {
            return LocalService.GetItemsByProperty(property);
        }

        public Place GetPlaceByName(string NameLocation)
        {
            return LocalService.GetPlaceByName(NameLocation);
        }

        public void MarkToDelete(string path)
        {
            LocalService.MarkToDelete(path);
        }

        public void Move(string path1, string path2)
        {
            LocalService.Move(path1, path2);
        }

        public void Remove(MyItems item)
        {
            LocalService.Remove(item);
        }

        public void RemoveWithPath(string path)
        {
            LocalService.RemoveWithPath(path);
        }

        public List<MyItems> SearchByProperty(string flag, string property)
        {
            return LocalService.SearchByProperty(flag, property);
        }

        public Place getPlaceByItem(string Path)
        {
            return LocalService.getPlaceByItem(Path);
        }

        public Event getEventByItem(string Path)
        {
            return LocalService.getEventByItem(Path);
        }
    }
}
