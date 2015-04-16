using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerCoreLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ICoreService" в коде и файле конфигурации.
    [ServiceContract]
    public interface ICoreService
    {
        [OperationContract]
        void DoWork();
    }
}
