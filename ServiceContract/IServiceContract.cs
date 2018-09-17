using SqlModel;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceContract
{
    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        DateTime GetDateTime();
        [OperationContract]
        List<Accounts> GetAllUserInfos();
        [OperationContract]
        Accounts GetAUserInfo(int id);
        [OperationContract]
        Accounts Login();
        [OperationContract]
        bool DeleteUserInfo(Accounts userInfo);
        [OperationContract]
        int EditUserInfo(Accounts userInfo);
        [OperationContract]
        bool AddUserInfo(Accounts userInfo);
        [OperationContract]
        string GetOrder();
        [OperationContract]
        Accounts GetNoneAddr();
        [OperationContract]
        Accounts Test();
    }
}
