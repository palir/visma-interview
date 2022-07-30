using PubSubService.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Interfaces
{
    public interface IMessagePresenter
    {
        public void PresentData<T>(string subscriberName, T messageData) where T: class;
    }
}
