using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MyPhotos;

namespace ObjectWCF
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
        void AddItems(MyItems item, String eveniment, String loc);

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

        [OperationContract]
        Place getPlaceByItem(string Path);

        [OperationContract]
        Event getEventByItem(string Path);
    }

}